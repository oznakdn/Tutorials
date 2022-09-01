

/*** html() ***/
$(".div1").click(function () { 

    var x=$(".p1").html();
    $("#span1").text(x);

 });

/*** text() ***/
 $("#btn1").click(function () { 
    alert($(".p1").text());
});


/*** attr() ***/
//Get
$(".p1").click(function(){
    alert($(".p1").attr("class")); 
});

//Set
$("#img1").click(function(){
    $(this).attr("src","https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTeOZDGEJT-ssoe25tmA1ex_ZUuACugzuwikQ&usqp=CAU");
});

/*** append() ***/
$("#btn2").click(function(){

    $(".div1").append("<p>This is paragraph append</p>");

});

/*** prepend() ***/
$("#btn3").click(function () { 

    $(".div1").prepend("<p>This is paragraph prepend</p>");
});

/*** before() ***/
$("#btn4").click(function(){

    $(".div1").before("<p>This is paragraph before</p>");
});

/*** after() ***/
$("#btn4").click(function(){

    $(".div1").after("<p>This is paragraph after</p>");

});

/*** remove() ***/
$("#btn6").click(function(){

    $(".div1").remove();
});

/*** empty() ***/
$("#btn7").click(function(){

    $(".div1").empty();
});