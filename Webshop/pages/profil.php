<?php
// Assuming you have already included the necessary files and initialized your database connection

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Handle form submission
    $teljesnev = $_POST['teljesnev'];
    $emailcim = $_POST['emailcim'];
    $adoszam = $_POST['adoszam'];
    $iranyitoszam = $_POST['iranyitoszam'];
    $telepules = $_POST['telepules'];
    $cim = $_POST['cim'];
    $telefonszam = $_POST['telefonszam'];

    // Assuming you have the user ID stored in a session variable named 'userid'
    $userid = $_SESSION['userid'];

    // Call the EditProfile function to update user data
    $db->EditProfile($userid, $teljesnev, $emailcim, $adoszam, $iranyitoszam, $telepules, $cim, $telefonszam);

    // Redirect back to profile.php after form submission
    header("Location: profile.php");
    exit(); // Ensure that subsequent code is not executed after redirection
}

// Fetch user data to populate the form
$row = $db->Profil();

?>

<form method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>">
    <div>
        <label for="teljesnev">Teljes név:</label>
        <input type="text" id="teljesnev" name="teljesnev" value="<?php echo $row['teljesnev']; ?>">
    </div>
    <div>
        <label for="emailcim">Email cím:</label>
        <input type="email" id="emailcim" name="emailcim" value="<?php echo $row['emailcim']; ?>">
    </div>
    <div>
        <label for="adoszam">Adószám:</label>
        <input type="text" id="adoszam" name="adoszam" value="<?php echo $row['adoszam']; ?>">
    </div>
    <div>
        <label for="iranyitoszam">Irányítószám:</label>
        <input type="text" id="iranyitoszam" name="iranyitoszam" value="<?php echo $row['iranyitoszam']; ?>">
    </div>
    <div>
        <label for="telepules">Település:</label>
        <input type="text" id="telepules" name="telepules" value="<?php echo $row['telepules']; ?>">
    </div>
    <div>
        <label for="cim">Cím:</label>
        <input type="text" id="cim" name="cim" value="<?php echo $row['cim']; ?>">
    </div>
    <div>
        <label for="telefonszam">Telefonszám:</label>
        <input type="tel" id="telefonszam" name="telefonszam" value="<?php echo $row['telefonszam']; ?>">
    </div>
    <div>
        <button type="submit">Mentés</button>
    </div>
</form>