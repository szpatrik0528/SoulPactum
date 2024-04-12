<div class="container-fluid d-flex align-items-center justify-content-center" style="height: 100vh;">
    <div class="col-lg-6">
        <article class="card">
            <div class="card-body p-5">
                <div class="tab-content">
                    <div class="tab-pane fade show active" id="nav-tab-card">
                        <form role="form">
                            <div class="form-group">
                                <label for="username">Teljesnév</label>
                                <input type="text" class="form-control" name="username" placeholder="" required="">
                            </div>
                            <div class="form-group">
                                <label for="cardNumber">Kártyaszám</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" name="cardNumber" placeholder="" pattern="[0-9]{16}" inputmode="numerical">
                                    <div class="input-group-append">
                                        <span class="input-group-text text-muted">
                                            <i class="fab fa-cc-visa"></i>   <i class="fab fa-cc-amex"></i>   
                                            <i class="fab fa-cc-mastercard"></i> 
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <label><span class="hidden-xs">Lejárati Dátum</span> </label>
                                        <div class="input-group">
                                            <input type="number" class="form-control" placeholder="MM" name="" maxlength="2">
                                            <input type="number" class="form-control" placeholder="YY" name="" maxlength="4">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label data-toggle="tooltip" title="" data-original-title="3 digits code on back side of the card">CVV <i class="fa fa-question-circle"></i></label>
                                        <input type="number" class="form-control" required="" maxlength="3">
                                    </div>
                                </div>
                            </div> 
                            <div class="form-group mt-3">
                                <button class="subscribe btn btn-primary btn-block" type="submit">Véglegesítés</button>
                            </div>
                        </form>
                    </div>
                </div>
                <p class="text-center">Fizetendő összeg:
                    <?php
                    echo $_SESSION['total_price'] . ' Ft';
                    ?>
                </p>
            </div>
        </article>
    </div>
</div>
