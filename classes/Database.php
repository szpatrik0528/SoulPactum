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
            $stmt->store_result();
            if ($stmt->num_rows > 0) {
                $_SESSION['login'] = true;
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

    public function getUsername(){
        $result = $this->db->query("SELECT `username` FROM `users` WHERE `userid` = " . $_SESSION['login']['userid']);
        return $result->fetch_assoc();
    }
    
}
