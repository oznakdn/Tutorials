/* Object Orianted Programming */


/*************** Interface *************/
interface Employee{
    name:string;
    age:number;
    email:string;
}

let employee1:Employee={
    name:'John',
    age:30,
    email:'john@mail.com'
}

console.log(employee1);
console.log(employee1.name);


/***************** Class *****************/
class Mobile{

    private brand:string;
    private color:string;
    private price:number;


    constructor(brand:string, color:string, price:number){
        this.brand=brand;
        this.color=color;
        this.price=price;
    }

    /* Encapsulation Get-Set */
    public getBrand():string{
        return this.brand;
    }
    public setBrand(value:string):void{
        this.brand=value;
    }

    public getColor() : string{
        return this.color;
    }
    public setColor(value:string):void{
        this.color=value;
    }

    public getPrice() : number {
        return this.price;
    }
    public setPrice(value:number) : void{
        this.price=value;
    }
}

let mobile : Mobile = new Mobile('Apple','red',12000);

console.log(mobile);
console.log(mobile.getBrand());
mobile.setBrand('Samsung');
console.log(mobile);

console.log(mobile.getColor());
console.log(mobile.setColor('Blue'));
console.log(mobile);

console.log(mobile.getPrice());
console.log(mobile.setPrice(15_000));
console.log(mobile);



/**************** Inheritence *****************/

// Super - Parent - Base class
class BasicCalc{  

    public result:number;

    constructor(){
        this.result=0;
    }

    public Sum(a:number, b:number):void{
        this.result = a + b;
        console.log(this.result);
    }

    public Sub(a:number, b:number):void{
        this.result = a - b;
        console.log(this.result);
    }
}

let basicCalc:BasicCalc = new BasicCalc();
basicCalc.Sum(10,20);
basicCalc.Sub(10,20);


// Sub - Child - Derived class
class AdvanceCalc extends BasicCalc{

    constructor(){
        super();
    }

    
    public Mul(a: number, b: number): void {
        this.result = a * b;
        console.log(this.result);
    }
}

let advancedCalc:AdvanceCalc = new AdvanceCalc();
advancedCalc.Sum(5,10);
advancedCalc.Mul(10,30);



/**************** Implementation *****************/

interface IStudent{
    firstName : string;
    lastName : string;
    age : number;
    course : string;

    fullname : () => string;
    biography: () => void;
}

class Student implements IStudent{

    firstName: string;
    lastName: string;
    age: number;
    course: string;

    constructor(firstname:string, lastname:string, age:number , course:string){
        this.firstName=firstname;
        this.lastName=lastname;
        this.age=age;
        this.course=course;
    }

    public fullname():string{
        return `${this.firstName} ${this.lastName}`;
    }
    public biography():void{
        let bio:string=`Full Name : ${this.fullname()} Age : ${this.age} Course : ${this.course}`;
        console.log(bio);

    }

}

let student:Student = new  Student('John','Wolker',35,'Compiter engineering');
console.log(student.fullname());
student.biography();


