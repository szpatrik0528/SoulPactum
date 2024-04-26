<?php

class Database
{

    private $db = null;

    public function __construct($host, $username, $passwor, $db)
    {
        $this->db = new mysqli($host, $username, $passwor, $db);
    }

    public function login($username, $password)
    {
        $stmt = $this->db->prepare('SELECT `userid`, `username`, `password` FROM `users` WHERE username = ? and  password = ?');
        $stmt->bind_param("ss", $username, $password);
        if ($stmt->execute()) {
            $stmt->bind_result($getuserid, $getusername, $getpassword);
            $stmt->store_result();
            if ($stmt->num_rows > 0) {
                $_SESSION['login'] = true;
                $stmt->fetch();
                $_SESSION['username'] = $getusername;
                $_SESSION['userid'] = $getuserid;
                header("Location: index.php");
            }
        }
        $stmt->close();
    }

    public function getSalt($username)
    {
        $stmt = $this->db->prepare('SELECT `salt`, `password` FROM `users` WHERE username = ?');
        $stmt->bind_param("s", $username);
        if ($stmt->execute()) {
            $stmt->bind_result($getsalt, $getpasswordh);
            $stmt->store_result();
            if ($stmt->num_rows > 0) {
                $_SESSION['login'] = true;
                $stmt->fetch();
                $_SESSION['passwordh'] = $getpasswordh;
                $_SESSION['salt'] = $getsalt;
                header("Location: index.php");
            }
        }
        $stmt->close();
    }

    public function register($teljesnev, $emailcim, $username, $password)
    {
        //$namecheckquery = "SELECT username FROM users WHERE username = '" . $username . "'";

        $stmt = $this->db->prepare("INSERT INTO `users`(`userid`, `teljesnev`, `emailcim`, `username`, `password`) VALUES (NULL,?,?,?,?)");

        if (!$stmt) {
            die('Error: ' . $this->db->error);
        }

        $stmt->bind_param("ssss", $teljesnev, $emailcim, $username, $password);

        try {
            if ($stmt->execute()) {
                $_SESSION['login'] = true;
                header("location: index.php");
            }
        } catch (Exception $e) {

            echo 'Error: ' . $e->getMessage();
        }
    }

    public function osszesTermek()
    {
        $result = $this->db->query("SELECT * FROM `termek`");
        $termekLista = $result->fetch_all(MYSQLI_ASSOC);

        // Létrehozzuk a termékek azonosítóinak tömbjét
        $termekIdList = array();
        foreach ($termekLista as $termek) {
            $termekIdList[] = $termek['termekid'];
        }

        // Tároljuk el a termék azonosítók tömbjét a $_SESSION-ben
        $_SESSION['termekid'] = $termekIdList;

        // Visszaadjuk az összes terméket
        return $termekLista;
    }


    public function getUsername()
    {
        $result = $this->db->query("SELECT `username` FROM `users` WHERE `userid` = " . $_SESSION['login']['userid']);
        return $result->fetch_assoc();
    }

    public function Profil()
    {
        $stmt = $this->db->prepare("SELECT * FROM users WHERE username = ?");
        $stmt->bind_param("s", $_SESSION['username']);
        $stmt->execute();
        $result = $stmt->get_result();
        if ($result->num_rows === 0) {
            return null;
        }
        return $result->fetch_assoc();
    }

    public function EditProfile($teljesnev, $emailcim, $adoszam, $iranyitoszam, $telepules, $cim, $telefonszam)
    {

        $stmt = $this->db->prepare("UPDATE `users` SET `teljesnev`= ? ,`emailcim`= ? ,`adoszam`= ? ,`iranyitoszam`= ? ,`telepules`= ? ,`cim`= ? ,`telefonszam`= ?  WHERE `userid` =?");


        if (!$stmt) {
            die('Error: ' . $this->db->error);
        }


        $stmt->bind_param("ssissssi", $teljesnev, $emailcim, $adoszam, $iranyitoszam, $telepules, $cim, $telefonszam, $_SESSION['userid']);

        try {

            if ($stmt->execute()) {

                $_SESSION['login'] = true;

                header("Location: index.php");
            }
        } catch (Exception $e) {

            echo 'Error: ' . $e->getMessage();
        }
    }


    public function Rendeles($userid, $termekid, $osszeg)
    {
        // SQL lekérdezés előkészítése
        $stmt = $this->db->prepare("INSERT INTO `rendeles` (`rendeles_id`, `userid`, `termekid`, `datum`, `osszeg`) VALUES (NULL, ?, ?, current_timestamp(), ?)");
        if (!$stmt) {
            die('Error: ' . $this->db->error);
        }

        // Paraméterek kötése a prepared statement-hez
        $stmt->bind_param("iii", $userid, $termekid, $osszeg);

        // Lekérdezés végrehajtása
        if ($stmt->execute()) {
            // Sikeres beszúrás esetén
        } else {
            // Sikertelen beszúrás esetén
            echo "Error: " . $stmt->error;
        }
    }
}