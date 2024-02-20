<div id="myModal" class="modal">
    <span class="close">&times;</span>
    <img class="modal-content" id="img">
</div>

<div class="-fluid" style="height: 30vh;">
    <div class="row d-flex align-items-center justify-content-center">
        <?php
        foreach ($db->osszesTermek() as $row) {
            $imageData = base64_encode($row['img']); 
            $imageSrc = 'data:image/jpeg;base64,' . $imageData; 
            $card = '<div class="card" style="width: 18rem; margin: 10px; background-color: #C8B6A6;">
                        <img src="' . $imageSrc . '" class="card-img-top" alt="Product Image" onclick="openModal(this)">
                        <div class="card-body">
                            <form id="addToCartForm" action="cart.php" method="post">
                                <input type="hidden" name="termekid" value="' . $row['termekid'] . '">
                                <input type="hidden" name="termek_nev" value="' . $row['termeknev'] . '">
                                <input type="hidden" name="ar" value="' . $row['ar'] . '">
                                <h5 class="card-title">' . $row['termeknev'] . '</h5>
                                <p class="card-text">Ár: ' . $row['ar'] . ' Ft</p>
                                <button type="submit" class="btn btn-outline-light" onclick="addToCartButton(event)">Kosárba</button>                            
                            </form>
                        </div>
                    </div>';
            echo $card;
        }
        ?>
    </div>
</div>
