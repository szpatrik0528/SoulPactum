<?php
if (filter_input(
    INPUT_POST,
    'belepesiAdatok',
    FILTER_VALIDATE_BOOLEAN,
    FILTER_NULL_ON_FAILURE
)) {
    $username = htmlspecialchars(filter_input(INPUT_POST, 'username'));
    $db->getSalt($username);
    $userid = $_SESSION['userid'];
    $salt = $_SESSION['salt'];
    $passwordh = $_SESSION['passwordh'];
    $password = htmlspecialchars(filter_input(INPUT_POST, 'password'));
    $db->login($username, $password);

    if ($db->login($username, $password)) {
        $_SESSION['login'] = true;
        $_SESSION['username'] = '';
        $_SESSION['password'] = '';
    } else {
        $loginhash = crypt($password, $salt, $userid);
        if ($passwordh != $loginhash) {
            echo "Incorrect password";
            exit();
        }
        $_SESSION['username'] = '';
        $_SESSION['userid'] = '';
    }
}
?>

<div class="container">
    <form action="#" method="post">
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="username" class="form-label">Felhasználó név</label>
                    <input type="text" class="form-control" id="username" name="username" minlength="5" maxlength="50"
                        aria-describedby="emailHelp">
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="password" class="form-label">Jelszó</label>
                    <input type="password" class="form-control" id="password" minlength="2" name="password">
                </div>
            </div>
        </div>
        <button type="submit" class="btn btn-primary" name="belepesiAdatok" value="true">Belépés</button>
    </form>
</div>