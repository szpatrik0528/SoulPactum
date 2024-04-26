<?php
require_once("Connect.php");
$username = $_POST["jatekosnev"];
$halalokszama = $_POST["halalokszama"];

$namecheckquery = "SELECT username FROM users WHERE username = '" . $username . "';";

$response = mysqli_query($con, $namecheckquery) or die("Name check failed.");
if (mysqli_num_rows($response) != 1) {
  echo "1";
  exit();
}


$insertuserquery = "UPDATE `users` SET `halalokszama` = '" .$halalokszama."' WHERE `users`.`username` = '" .$username."';";
mysqli_query($con, $insertuserquery) or die("Insert player query failed");

echo ("0");
