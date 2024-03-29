<?php

class Database {

    private $db = null;

    public function __construct($host, $username, $passwor, $db) {
        $this->db = new mysqli($host, $username, $passwor, $db);
    }

    public function login($username, $password) {
        $stmt = $this->db->prepare('SELECT `userid`, `username`, `password` FROM `users` WHERE username = ? and  password = ?');
        $stmt->bind_param("ss", $username, $password);
        if ($stmt->execute()) {
            $stmt->bind_result($getuserid, $getusername, $getpassword);
            $stmt->store_result();
            if ($stmt->num_rows > 0) {
                $_SESSION['login'] = true;
                $stmt->fetch();
                $_SESSION['username']=$getusername;
                //$_SESSION['userid'] = ['userid'];
                header("Location: index.php");
            }
        }
        $stmt->close();
    }

    public function register($teljesnev, $emailcim, $username, $password) {
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

    public function osszesTermek() {
        $result = $this->db->query("SELECT * FROM `termek`");
        return $result->fetch_all(MYSQLI_ASSOC);
    }

    public function getUsername() {
        $result = $this->db->query("SELECT `username` FROM `users` WHERE `userid` = " . $_SESSION['login']['userid']);
        return $result->fetch_assoc();
    }

    public function Profil() {
        $stmt = $this->db->prepare("SELECT * FROM users WHERE username = ?");
        $stmt->bind_param("s", $_SESSION['username']);
        $stmt->execute();
        $result = $stmt->get_result();
        if ($result->num_rows === 0) {
            return null;
        }
        return $result->fetch_assoc();
    }
}
