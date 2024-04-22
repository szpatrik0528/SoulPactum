document.addEventListener("DOMContentLoaded", function () {
    const slider = document.querySelector('.slider');
    let counter = 0;
    const slides = document.querySelectorAll('.slide');

    if (slides.length > 0) { 
        const slideWidth = slides[0].clientWidth;

        function slide() {
            counter++;
            if (counter === slides.length) {
                counter = 0;
            }
            slider.style.transform = 'translateX(' + (-slideWidth * counter) + 'px)';
        }

        setInterval(slide, 6000);
    } else {
        console.error("No slides found.");
    }
});


var modal = document.getElementById("myModal");

var modalImg = document.getElementById("img01");
function openModal(img) {
    modal.style.display = "block";
    modalImg.src = img.src;
    modalImg.classList.add('zoom'); 
}

var span = document.getElementsByClassName("close")[0];

