<div id="myModal" class="modal">
    <span class="close">&times;</span>
    <img class="modal-content" id="img">
</div>

<div class="-fluid" style="height: 30vh;">
    <form id="card" action="index.php?menu=cart" method="post">
        <div class="row d-flex align-items-center justify-content-center">
            <?php
            foreach ($db->osszesTermek() as $row) {
                $imageData = base64_encode($row['img']);
                $imageSrc = 'data:image/jpeg;base64,' . $imageData;
                $card = '<div class="col-md-2">
                            <div class="card" style="margin-bottom: 10px; background-color: #C8B6A6;">
                                <img src="' . $imageSrc . '" class="card-img-top" style="height: 200px; object-fit: cover;" alt="Product Image" onclick="openModal(this)">
                                <div class="card-body">
                                    <input type="hidden" name="termekid[]" value="' . $row['termekid'] . '">
                                    <input type="hidden" name="termek_nev[]" value="' . $row['termeknev'] . '">
                                    <input type="hidden" name="ar[]" value="' . $row['ar'] . '">
                                    <h5 class="card-title">' . $row['termeknev'] . '</h5>
                                    <p class="card-text">Ár: ' . $row['ar'] . ' Ft</p>
                                    <input type="checkbox" value="' . $row['termekid'] . '" name="kivalasztva[]">
                                </div>
                            </div>
                        </div>';
                echo $card;
            }
            ?>
        </div>
        <div class="col-md-1 justify-content-center">
            <button type="submit" class="btn btn-primary">Kosárba</button>
        </div>
    </form>
</div>
