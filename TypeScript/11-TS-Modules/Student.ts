import { IStudent } from "./IStudent";



export class Student implements IStudent{

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