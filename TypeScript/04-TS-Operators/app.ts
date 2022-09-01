/* 
    1. Aritmetic operators               --------> + , - , * , / , %
    2. Shorthand math operators          --------> += , -=, *=, /=
    3. Increment / Decrement operators   --------> ++ , --
    4. Conditional operators             --------> < , > , <= , => , === , !==
    5. Logical operators                 --------> && , || , ^
    6. Ternary operators                 --------> ? :
*/

//  1. Aritmetic operators               --------> + , - , * , / , %
let num1:number = 20;
let num2:number = 12;
console.log(`Sum = ${num1 + num2}`);
console.log(`Sub = ${num1 - num2}`);
console.log(`Mul = ${num1 * num2}`);
console.log(`Div = ${num1 / num2}`);


// 2. Shorthand math operators --------> += , -=, *=, /=
let x:number =10;
x += 10;
x -= 5;
x *= 2;
x /= 3;
console.log(`x = ${x}`);

// 3. Increment / Decrement operators --------> ++ , --
let y:number = 2;
++y;
y++;
console.log(`y = ${y}`);

// 4. Conditional operators --------> < >, <= , => , === , !==
let marks:number = 75;
let result:string = '';
if(marks <= 100){
    result=`${marks} less than 100 or equal`;
    console.log(result);
}

// 5. Logical operators  --------> && , || , ^
let inRelation:boolean=true;
let parentsAgreed:boolean=false;
if(inRelation && parentsAgreed){
    console.log('Get Marry Soon');
}else{
    console.log('Wait until Parents Agreed');
}

// 6. Ternary operators  --------> ? :
let age:number=7;
let isStudy:string= '';
(age>=7) ? isStudy="Yes, You can start a school" : isStudy= "No, you must be at home sometime";
console.log(isStudy);
