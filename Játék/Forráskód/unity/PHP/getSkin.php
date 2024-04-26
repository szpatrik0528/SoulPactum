<?php
require_once("Connect.php");
$username = $_POST["jatekosnev"];
$namecheckquery = "SELECT skin FROM users WHERE username = '" . $username . "';";

$response = mysqli_query($con, $namecheckquery) or die("Name check failed.");
if (mysqli_num_rows($response) != 1) {
  echo "00";
  exit();
}

$existinginfo = mysqli_fetch_assoc($response);
$Skin = $existinginfo["skin"];


echo $Skin;