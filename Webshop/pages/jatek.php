<?php
// FILEPATH: /c:/xampp1/htdocs/SoulPactum/pages/jatek.php

// Define the path to the game folder
$gameFolderPath = 'game/';

// Set the filename of your game installer
$gameFileName = 'SoulPactum Setup.exe';

// Combine the folder path and filename to get the full path to the installer
$gameFilePath = $gameFolderPath . $gameFileName;

// Check if the file exists before attempting to download it
if (file_exists($gameFilePath)) {
    // Force download of the file
    header('Content-Type: application/octet-stream');
    header('Content-Disposition: attachment; filename="' . $gameFileName . '"');
    readfile($gameFilePath);
    exit;
} else {
    // If the file doesn't exist, display an error message
    echo "A játék telepítőfájlja nem található.";
}
?>
