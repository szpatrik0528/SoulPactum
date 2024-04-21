<?php
$maker = array(
    array(
        "img" => "szivos_patrik_david.jpg",
        "name" => "Szivós Patrik Dávid",
        "email" => "szivospatrikdavid@gmail.com",
        "work" => "Webshop készítő"
    ),
    array(
        "img" => "demeter_istvan.jpg",
        "name" => "Demter István Tamás",
        "email" => "pistipisti57@gmail.com",
        "work" => "Játék készítő"
    ),
    array(
        "img" => "sandor_norbert.jpg",
        "name" => "Sándor Norbert",
        "email" => "sandornorbi7@gmail.com",
        "work" => "Admin felület készítő"
    )
);
?>
<body>
    <div class="card-container">
    <?php foreach ($maker as $maker): ?>
        <div class="card-rolunk">
            <?php if (!empty($maker["img"]) && file_exists($maker["img"])): ?>
                <img class="rolunk" src="<?php echo $maker["img"]; ?>" alt="<?php echo $maker["name"]; ?> Image">
            <?php else: ?>
                <p>No Image Available</p>
            <?php endif; ?>
            <p><?php echo $maker["name"]; ?></p>
            <p>Email: <br><?php echo $maker["email"]; ?></p>
            <p>Munkakör: <?php echo $maker["work"]; ?></p>
        </div>
    <?php endforeach; ?>
</div>
</body>
