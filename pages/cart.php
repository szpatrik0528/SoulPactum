<?php

// Adatbázis kapcsolat létrehozása
// Például:
include '/database.php';
$db = new mysqli('localhost', 'root', '', 'soulpactum');

// Ellenőrizzük, hogy van-e kiválasztott termék
if (isset($_POST['kivalasztva']) && !empty($_POST['kivalasztva'])) {
    // Kiválasztott termékek lekérdezése az adatbázisból
    $kivalasztott_termekidk = $_POST['kivalasztva'];
    $kivalasztott_termekidk_string = implode(', ', $kivalasztott_termekidk);
    $query = "SELECT * FROM termek WHERE termekid IN ($kivalasztott_termekidk_string)";
    $result = $db->query($query);

    // Ellenőrizzük, hogy van-e eredmény
    if ($result->num_rows > 0) {
        // Kiírjuk a termékeket
        while ($row = $result->fetch_assoc()) {
            $imageData = base64_encode($row['img']);
            $imageSrc = 'data:image/jpeg;base64,' . $imageData;

            echo '<img src="' . $imageSrc . '" style="width: 100px ;">';
            echo '<div class="termek">';
            echo '<h2>' . $row['termeknev'] . '</h2>';
            echo '<p>Ár: ' . $row['ar'] . ' Ft</p>';
            // Itt további adatokat jeleníthetsz meg a termékekről
            echo '</div>';
        }
    } else {
        echo 'Nincs találat.';
    }
} else {
    echo 'Nincs kiválasztva termék.';
}
?>
