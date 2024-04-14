/*Home page img slide*/
document.addEventListener("DOMContentLoaded", function () {
    const slider = document.querySelector('.slider');
    let counter = 0;
    const slides = document.querySelectorAll('.slide');
    const slideWidth = slides[0].clientWidth;

    function slide() {
        counter++;
        if (counter === slides.length) {
            counter = 0;
        }
        slider.style.transform = 'translateX(' + (-slideWidth * counter) + 'px)';
    }

    setInterval(slide, 6000);
});


// Get the modal
var modal = document.getElementById("myModal");

// Get the image and insert it inside the modal
var modalImg = document.getElementById("img01");
function openModal(img) {
    modal.style.display = "block";
    modalImg.src = img.src;
    modalImg.classList.add('zoom'); // Add zoom animation
}

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
/*span.onclick = function () {
    modal.style.display = "none";
    modalImg.classList.remove('zoom'); // Remove zoom animation
}*/


document.getElementById('cardNumber');

var cardNumber_mask = new IMask(cardNumber, {
    mask: [
        {
            mask: '0000 000000 00000',
            regex: '^3[47]\\d{0,13}',
            cardtype: 'american express'
        },
        {
            mask: '0000 0000 0000 0000',
            regex: '^(5[1-5]\\d{0,2}|22[2-9]\\d{0,1}|2[3-7]\\d{0,2})\\d{0,12}',
            cardtype: 'mastercard'
        },
        {
            mask: '0000 0000 0000 0000',
            regex: '^4\\d{0,15}',
            cardtype: 'visa'
        },
        {
            mask: '0000 0000 0000 0000',
            cardtype: 'Unknown'
        }
    ],
});

