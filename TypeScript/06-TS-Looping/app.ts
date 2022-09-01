/*
    1. for
    2. while
    3. do while

 */


// for
let names:string[]=['Ahmet','Mehmnet','Cemil'];
for(let i:number=0; i<names.length; i++){
    console.log(names[i]);
}

// while
let count:number=0;
let result:string='';
while(count<11){
    result+= `${count} `
    count++;
}
console.log(result);

// do while
let i:number=0;
do{
    console.log('*');
    i++;
}while(i<5);