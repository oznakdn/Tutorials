interface Mobile{
    brand:string;
    color:string;
    price:number;
}


let mobileObj:Mobile={
    brand:'Apple',
    color:'Silver',
    price:15_000,
    
};
console.log(mobileObj.brand);


// Nested Object

interface Address{
    street:string;
    city:string;
    state:string;
    country:string;
}

interface Student{
    name:string;
    age:number;
    course:string;
    address:Address;
}

let student:Student={
    name:'John Walker',
    age:20,
    course:'Software',
    address:{
        street:'1.street',
        city:'Samsun',
        state:'Atakum',
        country:'Turkiye'
    }
}
console.log(`Name: ${student.name}\n Age: ${student.age}\n Course: ${student.course}\n Address: ${student.address.city}/${student.address.state}`);