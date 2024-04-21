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
        // Prepare the SQL statement to update user data
        $stmt = $this->db->prepare("UPDATE `users` SET `teljesnev`= ? ,`emailcim`= ? ,`adoszam`= ? ,`iranyitoszam`= ? ,`telepules`= ? ,`cim`= ? ,`telefonszam`= ?  WHERE `userid` =?");

        // Check if the statement was prepared successfully
        if (!$stmt) {
            die('Error: ' . $this->db->error);
        }

        // Bind parameters to the prepared statement
        $stmt->bind_param("ssissssi", $teljesnev, $emailcim, $adoszam, $iranyitoszam, $telepules, $cim, $telefonszam, $_SESSION['userid']);

        try {
            // Execute the prepared statement
            if ($stmt->execute()) {
                // Update the session variable indicating the user is logged in
                $_SESSION['login'] = true;
                // Redirect the user to the profile page after successful update
                header("location: profile.php");
            }
        } catch (Exception $e) {
            // Handle exceptions if any
            echo 'Error: ' . $e->getMessage();
        }
    }


    public function Rendeles($userid, $termekid, $datum, $osszeg)
    {
        // SQL lekérdezés előkészítése
        $stmt = $this->db->prepare("INSERT INTO `rendeles` (`rendeles_id`, `userid`, `termekid`, `datum`, `osszeg`) VALUES (NULL, ?, ?, ?, ?);");
        if (!$stmt) {
            die('Error: ' . $this->db->error);
        }

        // Paraméterek kötése a prepared statement-hez
        $stmt->bind_param("iisd", $userid, $termekid, $datum, $osszeg);

        // Lekérdezés végrehajtása
        if ($stmt->execute()) {
            // Sikeres beszúrás esetén
            $_SESSION['login'] = true;
            header("location: index.php");
            exit; // Add this line to prevent further execution after redirection
        } else {
            // Sikertelen beszúrás esetén
            echo "Error: " . $stmt->error;
        }
    }
}
