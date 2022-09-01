// This is command
/* This is  multiple command */


/******* Gloabal *********/
var map="Turkiye";

/******* Local (scope) *******/
let city="Samsun"

/****** Constant ********/
const pi=3.14;

/******* Data Types *******/
let name="John"; // string
let number=30;   // number
let answer=true; // boolean
let what=null;   // object

/****** Undefined *******/
let thing;
console.log(thing);

/******** Nan *********/
let x="anyThing";
let y=20;
console.log(x*y);

/****** Cast ********/
let temp1=Number('40'); // convert to number
let temp2=String(40);  // convert to string

/****** Date *******/
let today=new Date();
console.log(today);
console.log(today.getFullYear());
console.log(today.getHours());
console.log(today.getMinutes());

/***** Math ******/
let Pi=Math.PI;
let random=Math.random();
let round=Math.round(6.5);  // 7
let ceil=Math.ceil(6.4);    // 7
let floor=Math.floor(6.4); // 6
let sqrt=Math.sqrt(81);    // 9
let pow=Math.pow(2,5);    // 25
let abs=Math.abs(-44);    // 44
let max=Math.max(10,20,40,30); // 40
let min=Math.min(10,20,40,30); // 10


/******** string methods ********/
let feature="Javascript, isn't type safety language."
console.log("length: "+feature.length);
console.log("lowerCase: "+feature.toLowerCase());
console.log("upperCase: "+feature.toUpperCase());
console.log("concat: "+feature.concat("Tamam."));  // add end
console.log("replace: "+feature.replace("Javascript","Js")); // changed word
console.log("replace: "+feature.replace(/a/g,"e")); //  Jevescript, isn't type sefety lenguege.
console.log("replace: "+feature.replace(/a/g,"e").replace(/t/g,"f")); //  Jevescripf, isn'f fype sefefy lenguege.
console.log("search: "+feature.search("a")); // 1
console.log("search: "+feature.search("z")); // -1
console.log("trim: "+feature.trim());
console.log("split: "+feature.split(" ")); // ["Javascript","isn't","type","safety","language"]
console.log("substring: "+feature.substring(0,10)); // Javascript
console.log("startsWith: "+feature.startsWith("Javascript")); // true
console.log("endsWith: "+feature.endsWith(",")); // false

/******** Template Strings ********/
let escape="Hello, This is a \n js tutorial"
console.log(escape);

let backtick="Js: `Javascript`";
console.log(backtick);

let literal="Javascript"
console.log(`This is a ${literal} tutorial`);

/********** Conditional ************/
/* If-Else */
let num1=10; let num2=20;
if(num1<num2) console.log(`${num1} less than ${num2}`);
else console.log(`${num2} greater than ${num1}`);

/* Ternary */
let ternary=num2>num1 ? console.log(`${num2} greater than ${num1}`) : console.log(`${num1} less than ${num2}`);

/* Switch-Case */
switch (num1) {
    case 1: console.log("num1 is 1"); break;
    case 2: console.log("num1 is 2"); break;
    case 3: console.log("num1 is 3"); break;

    default: console.log("num1 is zero");break;
}

/********** Loops ************/

/* For */
let myArray=[1,2,3,4,5,6,7];
for(let i=0;myArray.length;i++) console.log(myArray[i]);

/* While */
let number1=1;
while(number1<11) 
{
    console.log("number is 10");
    number1++;
}

/* Do-While */
do {
    console.log("number is 10");
} while (number1>12);

/* For-In */
for(let item in myArray){
    console.log(item);
}

/* For-Each */
myArray.forEach(function(item){
    console.log(item);
});

/* Map */
var newArray=myArray.map(function(item){
    return item;
});
console.log(newArray);


/********** Arrays and Methods ************/
let array=["Istanbul","Ankara","Izmir","Samsun"];

/* Push, Unshift, Pop, Shift, Reverse, Sort */
array.push("Trabzon"); // sona ekler
array.unshift("Eskisehir"); // basa ekler
array.pop(); // sondan siler
array.shift(); // bastan siler
array.reverse(); // tersten yazar
array.sort(); // siralar

/* Find, Filter, Concat, Splice */
array.find("Trabzon"); // true

/********** Object ************/
let software={
    html:'table',
    dizi:[1,2,3,],
    Object:{eleman:sayi}
}
console.log(software.html);


/******** Functions without parameters ********/
function myFunction(){
    console.log("This a without parameters function");
}
myFunction();

/* Arrow functions */
const xyz=()=>"Hello, This is arrow function";
console.log(xyz);

/* Functions with parameters */
const b=function sum(a,b){
    return a+b;
}
let result=b(10,20);
console.log(result);