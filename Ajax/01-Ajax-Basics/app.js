/*********** Text File Data *********/ 
let textButton=document.getElementById("text-btn");
textButton.addEventListener('click',function(){
    // Create an Ajax Request
    let xhr = new XMLHttpRequest();
    // Prepare the Request
    xhr.open('GET','./Data/message.txt',true);
    // Send the Request
    xhr.send();
    // Process the Request
    xhr.onload = ()=>{
        if(xhr.status === 200){
            let data=xhr.responseText;
            displayTextData(data);
        }
    }
});

// Display Text Data
let displayTextData=(data)=>{
    let htmlTemplate = `<h3>${data}</h3>`;
    document.getElementById("text-card").innerHTML=htmlTemplate;
}

/*********** Json Data *********/ 
let jsonButton = document.getElementById("json-btn");
jsonButton.addEventListener('click',function(){
    let xhr = new XMLHttpRequest();
    xhr.open('GET','./Data/mobiles.json',true);
    xhr.send();
    xhr.onload = ()=>{
        if(xhr.status === 200){
            let data = xhr.responseText;
            let mobile = JSON.parse(data);
            let mobileStringfy=JSON.stringify(data);
            console.log(typeof mobile);
            console.log(typeof mobileStringfy);

            displayJsonData(mobile);

        }
    }
});

let displayJsonData = (data)=>{
    let htmlTemlate = '';
    htmlTemlate = `<ul class="list-group mt-1">
                    <li class="list-group-item">ID : ${data.id}</li>
                    <li class="list-group-item">Brand : ${data.brand}</li>
                    <li class="list-group-item">Color : ${data.color}</li>
                    <li class="list-group-item">Price : ${data.price}</li>

                   </ul>`
    document.getElementById("json-card").innerHTML=htmlTemlate;

}

/*********** Api Data *********/
let apiButton = document.querySelector("#api-btn");
apiButton.addEventListener('click',function(){
    let xhr = new XMLHttpRequest();
    xhr.open('GET','https://jsonplaceholder.typicode.com/users',true);
    xhr.send();
    xhr.onload = () =>{
        if(xhr.status === 200){
            let data = xhr.responseText;
            let usersData = JSON.parse(data);
            displayApiData(usersData);
        }
    }
});

let displayApiData = (users)=>{
    let htmlTemplate = '';
    for(let user of users){
        htmlTemplate += `<ul class="list-group mt-1">
        <li class="list-group-item">ID : ${user.id}</li>
        <li class="list-group-item">Name : ${user.name}</li>
        <li class="list-group-item">Email : ${user.email}</li>
        <li class="list-group-item">Street : ${user.address.street}</li>
        <li class="list-group-item">City : ${user.address.city}</li>
        <li class="list-group-item">Company : ${user.company.name}</li>
        </ul>`
    }
   
     document.querySelector("#api-card").innerHTML = htmlTemplate;
}
