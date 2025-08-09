const productSwiper = new Swiper('.product-swiper', {
    slidesPerView: 4,
    spaceBetween: 20,
    navigation: {
        nextEl: '.product-carousel-next',
        prevEl: '.product-carousel-prev',
    },
    breakpoints: {
        992: { slidesPerView: 4 },
        768: { slidesPerView: 3 },
        576: { slidesPerView: 2 },
        0: { slidesPerView: 1 }
    }
});
