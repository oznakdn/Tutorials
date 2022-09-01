
$(document).ready(function () { 

    $("#btn").click(function(){
        $("#img1").animate({
            left:'150px',
            opacity:'1',
            height:'400px',
            with:'400px'
        },2000,function(){
            $("#img1").slideUp(3000)
        });
    });
 });


