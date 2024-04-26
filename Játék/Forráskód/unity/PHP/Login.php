<?php
require_once("Connect.php");
$username = $_POST["jatekosnev"];
$password = $_POST["jatekosjelszo"];

  $namecheckquery="SELECT userid, username, password, salt FROM users WHERE username = '".$username."';";

  $namecheck=mysqli_query($con,$namecheckquery) or die("Name check failed.");
  if(mysqli_num_rows($namecheck)!=1)
  {
    echo "Either no user with name or more than one";
    exit();
  }

  $existinginfo=mysqli_fetch_assoc($namecheck);
  $salt =$existinginfo["salt"]; 
  $hash =$existinginfo["password"];
  $loginhash=crypt($password, $salt);
  if($hash != $loginhash)
  {
    echo "Incorrect password";
    exit();
  }
    echo "0"; 
    