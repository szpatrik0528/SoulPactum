<?php
if (filter_input(INPUT_POST, 'regisztraciosAdatok', FILTER_VALIDATE_BOOLEAN, FILTER_NULL_ON_FAILURE)) {
    $password = filter_input(INPUT_POST, "password");
    $password2 = filter_input(INPUT_POST, "password2");
    $username = htmlspecialchars(filter_input(INPUT_POST, 'username'));
    $emailcim = filter_input(INPUT_POST, "emailcim", FILTER_VALIDATE_EMAIL);
    $teljesnev = htmlspecialchars(filter_input(INPUT_POST, 'teljesnev'));
    if (empty($emailcim) || empty($username) || empty($password) || empty($password2)) {
        echo '<p>Minden mezőt ki kell tölteni!</p>';
    } else {
        if ($password != $password2) {
            echo '<p>Nem egyeznek a jelszavak!</p>';
        } else {
            $db->register($teljesnev, $emailcim, $username, $password);
            header("Location: index.php");
        }
    }
}
?>
<div class="container">
    <form action="#" method="post">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="teljesnev" class="form-label">Teljes név:</label>
                    <input type="text" class="form-control" id="fullname" name="teljesnev" minlength="1" aria-describedby="emailHelp">
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="username" class="form-label">Felhasználó név</label>
                    <input type="text" class="form-control" id="username" name="username" minlength="1" aria-describedby="emailHelp">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="password" class="form-label">Jelszó</label>
                    <input type="password" class="form-control" id="password" minlength="2" name="password">
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="password2" class="form-label">Jelszó megerősítés</label>
                    <input type="password" class="form-control" id="password2" minlength="2" name="password2">
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="emailcim" class="form-label">Email cím</label>
                    <input type="text" class="form-control" id="emailcim" name="emailcim" minlength="1" aria-describedby="emailHelp">
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="telefonszam" class="form-label">Telefonszám</label>
                    <input type="text" class="form-control" id="telefonszam" name="telefonszam" minlength="11" >
                </div>
            </div>
        </div>
        <button type="submit" class="btn btn-primary" name="regisztraciosAdatok" value="true">Regisztráció</button>
    </form>
</div>


