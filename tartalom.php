<?php

switch ($menu) {
    case 'login':
        require_once './pages/login.php';
        break;
    case 'regisztracio':
        require_once './pages/regisztracio.php';
        break;
    case 'logout':
        require_once './pages/logout.php';
        break;
    case 'rolunk':
        require_once './pages/rolunk.php';
        break;
    case 'termekek':
        require_once './pages/termekek.php';
        break;
    case 'cart':
        require_once './pages/cart.php';
        break;
    case 'jatek':
        require_once './pages/jatek.php';
        break;
    case 'profil':
        require_once './pages/profil.php';
        break;
    case 'cart':
        require_once './pages/cart.php';
        break;
    case 'fizetes':
        require_once './pages/fizetes.php';
        break;
    default:
        require_once './pages/home.php';
        break;
}

