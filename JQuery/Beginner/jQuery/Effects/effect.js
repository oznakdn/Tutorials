


/**** hide - show - toggle ****/
function Hide(){
    $("#img1").hide();
}

function Show(){
    $("#img1").show();
}

function Toggle() {

    $("#img1").toggle();
}

/**** fadeIn - fadeOut - fadeToggle ****/
function FadeOut(){
    $("#img1").fadeOut();

}

function FadeIn(){
    $("#img1").fadeIn();

}

function FadeToggle(){
    $("#img1").fadeToggle();

}

/**** slideUp - slideDown - slideToggle ****/
function SlideUp(){
    $("#img1").slideUp();

}

function SlideDown(){
    $("#img1").slideDown();

}

function SlideToggle(){
    $("#img1").slideToggle(3000);
}

/**** stop ****/

function Stop(){
    $("#img1").stop();
    
}

/**** Animate ****/

$("#btn").click(function(){
    $("#img2").animate({
        left:'150px',
        opacity:'1',
        height:'400px',
        with:'400px'
    },2000)
});