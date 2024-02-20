<?php
require_once("Connect.php");
$username = $_POST["jatekosnev"];
$password = $_POST["jatekosjelszo"];

$namecheckquery = "SELECT jatekosnev FROM players WHERE jatekosnev = '" . $username . "';";

$namecheck = mysqli_query($con, $namecheckquery) or die("Name check failed.");

if (mysqli_num_rows($namecheck) > 0) {
  echo "3: Name already exists";
  exit();
}

$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
$hash = crypt($password, $salt);
$insertuserquery = "INSERT INTO players (jatekosnev, jatekosjelszo, salt) values ('" . $username . "','" . $hash . "','" . $salt . "');";
mysqli_query($con, $insertuserquery) or die("Insert player query failed");

echo ("0");
