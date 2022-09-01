import {BrainHttp} from './Api/BrainHttp';

const serverUrl = 'http://127.0.0.1:3000/api';

// DOM Content Loaded

window.addEventListener('DOMContentLoaded', function(){
    fetchAllEmployees();
});


// Get All Employees
let fetchAllEmployees = () => {
    let http = new BrainHttp();
    let url = `${serverUrl}/employees`;
    http.get(url, (err, employees) => {
        if(err) throw err;
        let employeesRow = '';
        for(let employee of employees){
            employeesRow += `<tr>
                            <td>${employee.id}</td>
                            <td>${employee.firstname}</td>
                            <td>${employee.lastname}</td>
                            <td>${employee.email}</td>
                            <td>${employee.gender}</td>
                            <td>
                            <button class="btn btn-secondary btn-sm update">Update</button>
                            <button class="btn btn-danger btn-sm delete">Delete</button>
                            </td>
                            </tr>`
        }
        document.querySelector('#table-body').innerHTML = employeesRow;
    });
};

// Add Employee Form
let addEmployeeForm = document.querySelector('#add-employee-form');
addEmployeeForm.addEventListener('submit',function(e){
    e.preventDefault(); // stop auto form submit
    $("#add-employee-modal").modal('hide'); // to close the modal
    let employee = {
        firstname : document.querySelector('#addFirstName').Value,
        lastname : document.querySelector('#addLastName').Value,
        email : document.querySelector('#addEmail').Value,
        gender :document.querySelector('#addGender').Value
    }

    let url = `${serverUrl}/employees`;
    let http = new BrainHttp();
    http.post(url, employee, (data)=>{
        fetchAllEmployees();
        clearFormFields();
    });

});


// Clear fields
let clearFormFields = () =>{
    document.querySelector('#addFirstName').Value = "";
    document.querySelector('#addLastName').Value = "";
    document.querySelector('#addEmail').Value = "";
    document.querySelector('#addGender').Value = "";
};

// Click Event on Entire Table Body
let tableBody = document.querySelector('#table-body');
tableBody.addEventListener('click', function(e){
    let targetElement = e.target;
    if(targetElement.classList.contains('delete')){
        let theElement = targetElement.parentElement;
    }
    if(targetElement.classList.contains('update')){
        
    }
});

