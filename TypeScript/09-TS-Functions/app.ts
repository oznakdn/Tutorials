/* Simple */
let greet=(name:string)=>{
    console.log(`Hello, ${name}`);
}

greet('John');

/* Function with return type */

let add = (a:number, b:number) : number => {
    let result:number=a+b;
    return result;
}
console.log(add(5,10));

/* Function with an object type as parameter */
interface Mobile{
    brand:string;
    color:string;
    price:number;
}

let printMobile = (mobile : Mobile) : void => {
    console.log(JSON.stringify(mobile));
};
let mobileOne : Mobile ={
    brand:'Apple',
    color:'Black',
    price:12000
};

printMobile(mobileOne);
printMobile({brand:'Lenovo',color:'Silver',price:5000});


