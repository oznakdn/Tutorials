/*
    * string
    * number
    * boolean
    * null
    * undefined
    * any
    * object
    * array
    * void
    * enum
*/

// string
let employeeName:string = 'John';
console.log(`Employee Name: ${employeeName}`);

// number
let employeeAge:number = 45;
console.log(`Employee Age : ${employeeAge}`);

// boolean
let isManager:boolean = true;
console.log(`Is Manager : ${isManager ? 'Yes' : 'No'}`);

// null (we don't use)
let test:null=null; 
console.log(`Test: ${test}`);

// undefined (we don't use)
let test2:undefined=undefined;
console.log(`Test2: ${test2}`);

// any (we don't use)
let a:any ='test';
a = 30;
a = {};
a = [];
a= true;

// object
let mobile:object = {
    brand:'Apple',
    color:'Silver',
    price:35000
};
console.log(mobile);

// array
let colors:string[]=['Red','Blue','Green','Purple'];
colors.forEach(item=>console.log(item));

// void
let greet=(name:string)=>{
    console.log(`Hello ${name}`)
}
greet('John');

// enum
enum Month{
    Jan = 'January',
    Feb='February'
}
console.log(Month.Feb);


