<div class="row justify-content-center align-items-center" style="height: 100vh;">
    <div class="col">
        <?php
        $row = $db->Profil();
        if ($row !== null) {
            $card = '<div class="card mx-auto" style="width: 18rem;">
                    <div class="card-body">
                        <h5 class="card-title align-items-center">' . $row['username'] . '</h5>' .
                    '<p class="card-text">Email cím: ' . $row['emailcim'] . '</p>' .
                    '<p class="card-text">Teljes név: ' . $row['teljesnev'] . '</p>' .
                    '<p class="card-text">Telefonszám: ' . $row['telefonszam'] . '</p>' .
                    '<p class="card-text">Irányítószám: ' . $row['iranyitoszam'] . '</p>' .
                    '<p class="card-text">Település: ' . $row['telepules'] . '</p>' .
                    '<p class="card-text">Cím: ' . $row['cim'] . '</p>
                    </div>
                </div>';
            echo $card;
        }
        ?>
    </div>
</div>
