$(document).ready(function ()
{

    $(".full-screen").mousemove(function(event) {
        const eye = $(".eye");
        const x = (eye.offset().left) + (eye.width() / 2);
        const y = (eye.offset().top) + (eye.height() / 2);
        const rad = Math.atan2(event.pageX - x, event.pageY - y);
        const rot = (rad * (180 / Math.PI) * -1) + 180;
        eye.css({
            '-webkit-transform': 'rotate(' + rot + 'deg)',
            '-moz-transform': 'rotate(' + rot + 'deg)',
            '-ms-transform': 'rotate(' + rot + 'deg)',
            'transform': 'rotate(' + rot + 'deg)'
        });
    });


})

