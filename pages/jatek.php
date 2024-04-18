<?php
// FILEPATH: /c:/xampp1/htdocs/SoulPactum/pages/jatek.php

// Set the file path and name of your game
$gameFilePath = 'game/game.zip';
$gameFileName = 'SoulPactum.zip';

// Check if the file exists
if (file_exists($gameFilePath)) {
    // Set the appropriate headers for the download
    header('Content-Description: File Transfer');
    header('Content-Type: application/octet-stream');
    header('Content-Disposition: attachment; filename="' . $gameFileName . '"');
    header('Expires: 0');
    header('Cache-Control: must-revalidate');
    header('Pragma: public');
    header('Content-Length: ' . filesize($gameFilePath));
    readfile($gameFilePath);
    exit;
} else {
    // Display an error message if the file does not exist
    echo 'Sorry, the game file is not available for download.';
}
?>
