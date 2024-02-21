<?php
// Check if the form is submitted
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Retrieve the form data
    $teljesnev = htmlspecialchars(filter_input(INPUT_POST, 'teljesnev'));
    $emailcim = filter_input(INPUT_POST, "emailcim", FILTER_VALIDATE_EMAIL);
    $telefonszam = filter_input(INPUT_POST, "telefonszam");

    // Insert or update the user information in the database
    $db = "INSERT INTO users (teljesnev, emailcim, telefonszam) VALUES ('$teljesnev', '$emailcim', '$telefonszam')
            ON DUPLICATE KEY UPDATE name='$teljesnev', email='$emailcim', phone='$telefonszam'";
    if ($conn->query($db) === TRUE) {
        echo "User information saved successfully.";
    } else {
        echo "Error: " . $db . "<br>" . $conn->error;
    }
}

// Retrieve the user information from the database
$db = "SELECT * FROM users";
if ($result->num_rows > 0) {
    $result->fetch_assoc();
    $teljesnev = htmlspecialchars(filter_input(INPUT_POST, 'teljesnev'));
    $emailcim = filter_input(INPUT_POST, "emailcim", FILTER_VALIDATE_EMAIL);
    $telefonszam = filter_input(INPUT_POST, "telefonszam");
} else {
    $teljesnev = "";
    $emailcim = "";
    $telefonszam = "";
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>User Profile</title>
</head>
<body>
    <h1>User Profile</h1>
    <form method="POST" action="<?php echo $_SERVER["PHP_SELF"]; ?>">
        <label for="teljesnev">Name:</label>
        <input type="text" name="teljesnev" value="<?php echo $teljesnev; ?>"><br><br>
        <label for="emailcim">Email:</label>
        <input type="email" name="emailcim" value="<?php echo $emailcim; ?>"><br><br>
        <label for="telefonszam">Phone:</label>
        <input type="text" name="telefonszam" value="<?php echo $telefonszam; ?>"><br><br>
        <input type="submit" value="Save">
    </form>
</body>
</html>
