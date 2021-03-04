(function () {
    "use strict";

    //scrollspy menu
    //    $('body').scrollspy({
    //        target: '#full_header',
    //        offset: 100,
    //    });
    
    // affix js
    $('#full_header').affix({
        offset: 200,
    });
    // banner slick js
    $('#slid_item').slick({
        dots: true,
        infinite: true,
        speed: 3000,
        fade: true,
        cssEase: 'linear',
        showNextPrev: false,
        autoplay: true,
        autoplaySpeed: 1000,
        arrows: false,
    });
    // features tabs js
    $('#myTabs a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    })
    // screenshot js
    $('.ftrs_cont').slick({
        dots: true,
        infinite: true,
        speed: 300,
        arrows: false,
        slidesToShow: 5,
        slidesToScroll: 1,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: true
                }
    },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                }
    },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
    }
    // You can unslick at a given breakpoint now by adding:
    // settings: "unslick"
    // instead of a settings object
  ]
    });
    // slick slider for team
    $('.team_team').slick({
        dots: false,
        infinite: true,
        arrows: false,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 1,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: false
                }
    },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                }
    },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
    }
    // You can unslick at a given breakpoint now by adding:
    // settings: "unslick"
    // instead of a settings object
  ]
    });
    // user feedback js
    $('.fdbck_for').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
        asNavFor: '.fdbck_itm'
    });
    $('.fdbck_itm').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.fdbck_for',
        dots: true,
        autoplay: true,
        autoplaySpeed: 3000,
        centerPadding: 0,
        centerMode: true,
        arrows: false,
        centerMode: true,
        focusOnSelect: true,
        responsive: [
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    autoplay: true,
                    infinity: true,
                    dots: true,
                    slidesToScroll: 1
                }
			}
		]
    });

})(jQuery);
////////////
$(document).ready(function () {
        // Add scrollspy to <body>
        $('body').scrollspy({
            target: "#full_header",
            offset: 50
        });

        // Add smooth scrolling on all links inside the navbar
        $(".full_header li a").on('click', function (event) {
            // Make sure this.hash has a value before overriding default behavior
            if (this.hash !== "") {
                // Prevent default anchor click behavior
                event.preventDefault();

                // Store hash
                var hash = this.hash;

                // Using jQuery's animate() method to add smooth page scroll
                // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
                $('html, body').animate({
                    scrollTop: $(hash).offset().top
                }, 800, function () {

                    // Add hash (#) to URL when done scrolling (default click behavior)
                    window.location.hash = hash;
                });
            } // End if
        });
    });



// back to top
$(document).ready(function () {

    $offset = 50;

    $(".bttop").click(function () {

        $("html,body").animate({
            scrollTop: 0
        }, 500)

    });

});
$(window).scroll(function () {
    $dis = $(this).scrollTop();

    if ($dis > $offset) {
        $(".bttop").fadeIn('slow');
    } else {
        $(".bttop").fadeOut('slow');
    }


});
