<?php
require_once("Connect.php");
$username = $_POST["jatekosnev"];
$pontszam = $_POST["pontszam"];

$namecheckquery = "SELECT username FROM users WHERE username = '" . $username . "';";

$response = mysqli_query($con, $namecheckquery) or die("Name check failed.");
if (mysqli_num_rows($response) != 1) {
  echo "1";
  exit();
}


$insertuserquery = "UPDATE `users` SET `pontszam` = '" .$pontszam."' WHERE `users`.`username` = '" .$username."';";
mysqli_query($con, $insertuserquery) or die("Insert player query failed");

echo ("0");
