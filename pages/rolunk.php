<?php
$maker = array(
    array(
        "img" => "szivos_patrik_david.jpg",
        "name" => "Szivós Patrik Dávid",
        "email" => "szivospatrikdavid@gmail.com"
    ),
    array(
        "img" => "demeter_istvan.jpg",
        "name" => "Demter István",
        "email" => "pistipisti57@gmail.com"
    ),
    array(
        "img" => "sandor_norbert.jpg",
        "name" => "Sándor Norbert",
        "email" => "sandornorbi7@gmail.com"
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
            <p>Email: <?php echo $maker["email"]; ?></p>
            <button class="cute-button" onclick="sendEmail('<?php echo $maker["email"]; ?>')">Send Email</button>
        </div>
    <?php endforeach; ?>
</div>
</body>


<script>
    function sendEmail(email) {
        window.location.href = "mailto:" + email;
    }
</script>
