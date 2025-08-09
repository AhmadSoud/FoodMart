document.addEventListener('DOMContentLoaded', function () {
    new Swiper('.category-swiper', {
        slidesPerView: 3,
        spaceBetween: 20,
        navigation: {
            nextEl: '.category-carousel-next',
            prevEl: '.category-carousel-prev',
        },
        loop: true,
        breakpoints: {
            576: { slidesPerView: 1 },
            768: { slidesPerView: 2 },
            992: { slidesPerView: 3 },
            1200: { slidesPerView: 4 }
        }
    });
});
