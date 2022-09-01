/*
    1. if - else
    2. switch
 */

// if - else
let currentTime:number = 22;
let wishMessage:string = '';
if(currentTime >= 0 && currentTime <= 12){
    wishMessage='Good Morning';
}else if(currentTime >= 13 && currentTime <= 17){
    wishMessage='Good afternoon';
}else if(currentTime >= 18 && currentTime <= 23){
    wishMessage='Good evening'
}else{
    wishMessage='Good night';
}
console.log(`Message : ${wishMessage}`);

// switch
let day:number=new Date().getDay();
let today:string='';
switch(day){
    case 1 : today='Monday'; break;
    case 2 : today='Tuesday'; break;
    case 3 : today='Wednesday'; break;
    case 4 : today='Thursday'; break;
    case 5 : today='Friday'; break;
    case 6 : today='Saturday'; break;
    case 7 : today='Sunday'; break;
    default : today='This day is not valid'; break;
}
console.log(`Today is ${today}`);