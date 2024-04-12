<nav class="navbar navbar-expand-lg navbar-light" style="background-color: #A4907C;">
    <div class="container-fluid">
        <a class="navbar-brand" href="#"></a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse justify-content-center" id="navbarSupportedContent">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" aria-current="page" href="index.php">Home</a>
                </li>
                <?php
                if ($_SESSION['login']) {
                    echo '<li class="nav-item">
                <a class="nav-link ' . ($menu == 'logout' ? ' active' : '') . '" href="index.php?menu=logout">Kilépés</a>
                </li>' . '<li class="nav-item">
                    <a class="nav-link' . ($menu == 'termekek' ? ' active' : '') . '" href="index.php?menu=termekek" >Termékek</a>
                  </li>' . /*'<li class="nav-item">
                  <a class="nav-link' . ($menu == 'jatek' ? ' active' : '') . '" href="index.php?menu=jatek" >Játék Letöltés</a>
                </li>' .*/ '<li class="nav-item">
                  <a class="nav-link' . ($menu == 'cart' ? ' active' : '') . '" href="index.php?menu=cart" >Kosár</a>
                </li>' . '<li class="nav-item">
                  <a class="nav-link' . ($menu == 'profil' ? ' active' : '') . '" href="index.php?menu=profil" >Profil</a>
                </li>';
                } else {
                    echo '<li class = "nav-item">
                    <a class = "nav-link ' . ($menu == 'login' ? ' active' : '') . '" href = "index.php?menu=login">Belépés</a>
                </li>
                <li class = "nav-item">
                    <a class = "nav-link ' . ($menu == 'regisztracio' ? ' active' : '') . '" href = "index.php?menu=regisztracio">Regisztráció</a>
                </li>';
                }
                ?>
                <li class="nav-item">
                    <a class="nav-link <?php echo ($menu == 'rolunk' ? ' active' : ''); ?>" href="index.php?menu=rolunk">Rólunk</a>
                </li>
            </ul>
        </div>
    </div>
</nav>