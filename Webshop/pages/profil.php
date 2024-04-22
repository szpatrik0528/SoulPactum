<?php
if (isset($_POST['editadatok']) && $_POST['editadatok'] == 'true') {
    // Ellenőrizheted a POST adatokat a biztonság kedvéért

    // Felhasználó adatainak frissítése az adatbázisban
    $teljesnev = $_POST['teljesnev'];
    $emailcim = $_POST['emailcim'];
    $adoszam = $_POST['adoszam'];
    $iranyitoszam = $_POST['iranyitoszam'];
    $telepules = $_POST['telepules'];
    $cim = $_POST['cim'];
    $telefonszam = $_POST['telefonszam'];

    // A $db->EditProfile() függvény hívása a módosítások mentéséhez az adatbázisban
    $editsuccess = $db->EditProfile($teljesnev, $emailcim, $adoszam, $iranyitoszam, $telepules, $cim, $telefonszam);

    if ($editsuccess) {
        // Sikeres módosítás esetén
        echo "Az adatok sikeresen módosítva lettek!";
    } else {
        // Sikertelen módosítás esetén
        echo "Hiba történt az adatok módosítása közben.";
        // Vagy más műveletet végzel, például megjeleníted a hibaüzenetet a felhasználónak
    }
}

// Az előző rész marad ugyanaz, azaz a felhasználó adatainak megjelenítése az űrlapon
$userData = $db->Profil();
if (isset($userData) && !empty($userData)) {
    $teljesnev = $userData['teljesnev'];
    $emailcim = $userData['emailcim'];
    $adoszam = $userData['adoszam'];
    $iranyitoszam = $userData['iranyitoszam'];
    $telepules = $userData['telepules'];
    $cim = $userData['cim'];
    $telefonszam = $userData['telefonszam'];
}
?>

<div class="container">
    <form action="#" method="post">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="teljesnev" class="form-label">Teljes név:</label>
                    <input type="text" class="form-control" id="teljesnev" name="teljesnev" minlength="1" value="<?php echo $teljesnev; ?>">
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="emailcim" class="form-label">Email cím:</label>
                    <input type="text" class="form-control" id="emailcim" name="emailcim" minlength="1" aria-describedby="emailHelp" value="<?php echo $emailcim; ?>">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="adoszam" class="form-label">Adószám:</label>
                    <input type="text" class="form-control" id="adoszam" name="adoszam" value="<?php echo $adoszam; ?>">
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="iranyitoszam" class="form-label">Irányítószám:</label>
                    <input type="number" class="form-control" id="iranyitoszam" minlength="4" name="iranyitoszam" value="<?php echo $iranyitoszam; ?>">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="telepules" class="form-label">Település</label>
                    <input type="text" class="form-control" id="telepules" name="telepules" value="<?php echo $telepules; ?>">
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="cim" class="form-label">Cím:</label>
                    <input type="text" class="form-control" id="cim" name="cim" value="<?php echo $cim; ?>">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="telefonszam" class="form-label">Telefonszám:</label>
                    <input type="number" class="form-control" id="telefonszam" name="telefonszam" minlength="11" value="<?php echo $telefonszam; ?>">
                </div>
            </div>
        </div>
        <button id="updateButton" type="submit" class="btn btn-primary" name="editadatok" value="true">Update</button>
    </form>
</div>