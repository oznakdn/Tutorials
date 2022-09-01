import {BrainHttp} from './Api/BrainHttp';
const serverUrl = `http://127.0.0.1:3000/api`





// GET Button
let getButton = document.querySelector("#get-btn");
getButton.addEventListener('click',function(){
    fetchEmployees();
});

let fetchEmployees= () =>{
     let http = new BrainHttp();
     let url = `${serverUrl}/employees`;
     http.get(url,(err,employees)=>{
        if(err) throw err;
       let tableRows = '';
        for(let employee of employees){
            tableRows += `<tr>
                          <td>${employee.id}</td>
                          <td>${employee.first_name}</td>
                          <td>${employee.last_name}</td>
                          <td>${employee.email}</td>
                          <td>${employee.gender}</td>
                        </tr>`
        }
        document.querySelector('#table-body').innerHTML = tableRows;
     });
};


// POST Button
let postButton = document.querySelector('#post-btn');
postButton.addEventListener('click',function(){
    let employee = {
        first_name : 'Ali',
        last_name : 'Sever',
        email : 'alisever@mail.com',
        gender : 'male'
    };

    let http = new BrainHttp();
    http.post(url, employee, (data) =>{
        alert(JSON.stringify(data));
        fetchEmployees();
    });
});


// PUT Button
let putButton = document.querySelector('#put-btn');
putButton.addEventListener('click',function(){
    let empId = `_abcdef`;
    let employee = {
        id : empId,
        first_name : 'John',
        last_name : 'Wilson',
        email : 'john@mail.com',
        gender : 'male'
    };

    let url = `${serverUrl}/employees/${empId}`;
    let http = new BrainHttp();
    http.put(url, employee, (data)=>{
        alert(JSON.stringify(data));
        fetchEmployees();
    });
});

// DELETE Button
let deleteButton = document.querySelector('#delete-btn');
deleteButton.addEventListener('click',function(){
    let empId = `_abcdef`;
    let url = `${serverUrl}/employees/${empId}`;
    let http = new BrainHttp();
    http.delete(url, (data) =>{
        alert(JSON.stringify(data));
        fetchEmployees();
    });
})
