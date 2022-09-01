const express = require('express');
const app =express();
const bodyParser = require('body-parser');
const cors =require('cors');
const { request, response } = require('express');
const apiRouter = require('./Api/apiRouter')
const hostname = '127.0.0.1';
const port = 3000;

// configure bodyParser
const jsonParser = bodyParser.json();
const urlEncodedParser = bodyParser.urlencoded({extended:false});
app.use(jsonParser);
app.use(urlEncodedParser);

// configure cors
app.use(cors());

// configure the  Router
app.use('/api',apiRouter);

// get
app.get('/',(request,response) =>{
    response.send(`<h2>Welcome to Express Server of Employee Portal</h2>`)
});

app.listen(port, hostname, ()=>{
    console.log(`Express Server is Started at http://${hostname}:${port}`);
})