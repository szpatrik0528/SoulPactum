<?php

// Check if the cart session variable exists, if not, create it
if (!isset($_SESSION['cart'])) {
    $_SESSION['cart'] = [];
}

// Add item to cart
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (isset($_POST['item'])) {
        $item = $_POST['item'];
        $_SESSION['cart'][] = $item;
        echo "Item added to cart: $item";
    }
}

// Display cart items
echo "Cart items: ";
foreach ($_SESSION['cart'] as $item) {
    echo "$item, ";
}

// Buy items
if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    if (isset($_GET['buy'])) {
        // Process the purchase logic here
        // ...
        echo "Purchase successful!";
    }
}
?>
