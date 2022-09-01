

/****** click *********/
$("buttun").click(func1);

function func1(){
    $("#img1").toggle();
}

// or
$("#btn").click(function(){
    $("#img1").toggle();
});

/****** dblclick *********/
$("button").dblclick(func2);
function func2(){
    $("#img1").css("width","50");
}


/****** mouseenter *********/
$("img").mouseenter(func3);

function func3(){
    $("#img1").css("width","400");
}

/****** mouseleave *********/
$("img").mouseleave(func4);

function func4(){
    $("#img1").css("width","100");
}

/****** hover *********/

$("#img2").hover(func5,func6);

function  func5() {
    $("img").css("width","300");
}

function  func6() {
    $("img").css("width","50");
    
}