<?php
$_SESSION['total_price'] = 0;
// Adatbázis kapcsolat létrehozása
// Például:
$db = new mysqli('localhost', 'root', '', 'soulpactum');

// Ellenőrizzük, hogy van-e kiválasztott termék
// Ha a kosár már létezik a session-ben, használjuk azt, különben létrehozzuk
if (!isset($_SESSION['kosar'])) {
    $_SESSION['kosar'] = array();
}

if (isset($_POST['kivalasztva']) && !empty($_POST['kivalasztva'])) {
    // Kiválasztott termékek lekérdezése az adatbázisból
    $kivalasztott_termekidk = $_POST['kivalasztva'];
    $kivalasztott_termekidk_string = implode(', ', $kivalasztott_termekidk);
    $query = "SELECT * FROM termek WHERE termekid IN ($kivalasztott_termekidk_string)";
    $result = $db->query($query);

    // Ellenőrizzük, hogy van-e eredmény
    if ($result->num_rows > 0) {
        // Új termékek hozzáadása a kosárhoz
        while ($row = $result->fetch_assoc()) {
            $imageData = base64_encode($row['img']);
            $imageSrc = 'data:image/jpeg;base64,' . $imageData;

            $termek = array(
                'id' => $row['termekid'],
                'nev' => $row['termeknev'],
                'ar' => $row['ar'],
                'kep' => $imageSrc
            );

            // Ellenőrizzük, hogy ez a termék már szerepel-e a kosárban
            $termek_megtalalva = false;
            foreach ($_SESSION['kosar'] as $kosar_termek) {
                if ($kosar_termek['id'] == $termek['id']) {
                    $termek_megtalalva = true;
                    break;
                }
            }

            // Ha nem találtuk meg a terméket, adjuk hozzá a kosárhoz
            if (!$termek_megtalalva) {
                $_SESSION['kosar'][] = $termek;
            }
        }
    } else {
        echo 'Nincs találat.';
    }
}


if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (isset($_POST['delete_item'])) {
        $delete_index = $_POST['delete_index'];
        unset($_SESSION['kosar'][$delete_index]);
        $_SESSION['kosar'] = array_values($_SESSION['kosar']);
    }
}



// Kosár tartalmának megjelenítése
if (!empty($_SESSION['kosar'])) {
    foreach ($_SESSION['kosar'] as $index => $termek) {
        echo '<div class="termek">';
        echo '<img src="' . $termek['kep'] . '" style="width: 100px; float: left; margin-right: 10px;">';
        echo '<div class="termek-info">';
        echo '<h2>' . $termek['nev'] . '</h2>';
        '<p>Termék azonosítója: ' . $termek['id'] . '</p>'; // Termék azonosítójának kiírása
        echo '<p>Ár: ' . $termek['ar'] . ' Ft</p>';
        echo '</div>';
        echo '<form method="post">';
        echo '<input type="hidden" name="delete_index" value="' . $index . '">';
        echo '<button class="delete-button" type="submit" name="delete_item">Törlés</button>';
        echo '</form>';
        echo '</div>';
        echo '<div style="clear:both;"></div>';
    
        // Számoljuk össze a teljes árat
        $_SESSION['total_price'] += $termek['ar'];
    }
    

    // Összesített ár megjelenítése
    echo '<p>Összesen: ' . $_SESSION['total_price'] . ' Ft</p>';

    // Fizetés gomb
?>
<form method="post" action="index.php?menu=fizetes">
    <button type="submit" name="fizetes">Fizetés</button>
</form>
<?php
} else {
    echo 'A kosár üres.';
}
?>