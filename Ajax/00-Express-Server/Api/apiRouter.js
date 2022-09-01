const express = require('express');
const router = express.Router();

// Employees Data
let employess = [

    {
        id : '_abcdef',
        firstName : 'John',
        lastName : 'Wilson',
        gender : 'Male',
        email : 'john@mail.com',
    },
    {
        id : '_vwxyz',
        firstName : 'Laura',
        lastName : 'Wilson',
        gender : 'Female',
        email : 'Laura@mail.com',
    }
]

// Set ID
let setId = () => {
    return '_' + Math.random().toString(36).substring(2, 9);
}



// GET - Employees
router.get('/employees', (request, response) => {
    console.log(`GET Request Received at server .. ${new Date().toLocaleTimeString()}`);
    response.json(employess);
});

// POST - Request
router.post('/employees', (request, response) =>{
    let employee = {
        id : setId(),
        first_name : request.body.first_name,
        last_name : request.body.last_name,
        gender : request.gender,
        email : request.body.email
    };
    employees.push(employee);
    console.log(`POST Request Received at server .. ${new Date().toLocaleTimeString()}`);
    response.json({msg : 'POST Request is Success'})
})


// PUT - Request
router.put('/employees/:id', (request, response) =>{
    let employeeId = request.params.id;
    let updateEmployee = {
        id : employeeId,
        first_name : request.body.first_name,
        last_name : request.body.last_name,
        email : request.body.email,
        gender : request.body.gender
    };
    
    let existingEmployee = employess.find((employee) => {
        return employee.id === employeeId;
    });

    employess.splice(employess.indexOf(existingEmployee),1,updateEmployee);
    console.log(`PUT Request Received at server .. ${new Date().toLocaleTimeString()}`);
    response.json({msg : 'PUT Request is Success'})
});

// DELETE - Request
router.delete('/employees/:id', (request, response) =>{
    let employeeId = request.params.id;
    employess = employess.filter( (employee) =>{
        return employee.id !==employeeId;
    });
    console.log(`DELETE Request Received at server .. ${new Date().toLocaleTimeString()}`);
    response.json({msg : 'DELETE Request is Success'})

});

module.exports = router;