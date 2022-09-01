/* 
      Array
*/
let colors:string[]=['white','black','grey'];
console.log(colors);

// for
for(let i:number=0 ; i < colors.length; i++){
    console.log(colors[i]);
}

// for in
for (let color in colors){
    console.log(colors[color]);
}

// for of
for(let color of colors){
    console.log(color);
}

// foreach
colors.forEach(item=>{
    console.log(item);
});


/* 
      Objects Array
*/

interface Employee {
        sno:string;
        name:string;
        age:number;
        designation:string;
        location:string;
}

let employees:Employee[]=[
    {
        sno:'AA12023',
        name:'Ali',
        age:30,
        designation:'Computer Engineer',
        location:'Turkiye'
    },
    {
        sno:'AA12025',
        name:'Veli',
        age:36,
        designation:'Software Engineer',
        location:'Turkiye'
    },
    {
        sno:'AA12025',
        name:'Aynur',
        age:34,
        designation:'Software Engineer',
        location:'Turkiye'
    }
];


// All employees
console.log(employees);

// Junior employees
for(let juniorEmployees of employees){
    if(juniorEmployees.age <= 30){
        console.log(juniorEmployees);
    }
}

// Using filter function
let seniorEmployees:Employee[]=employees.filter((employee:Employee)=>{
    return employee.age > 30;
});
console.log(seniorEmployees);
