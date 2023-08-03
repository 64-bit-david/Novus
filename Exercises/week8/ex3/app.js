// Import required modules
var express = require("express");
const cors = require("cors");
var bodyParser = require("body-parser");
var sql = require("msnodesqlv8"); 
var app = express();
const routes = require('./routes');

// Set up view engine
app.set('view engine', 'pug');

// Define IP and port
const ip = '127.0.0.1';
const port = '4040';

// Middleware setup
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.text({ type: 'text/html' }));
app.use(cors({ origin: "*", methods: ['GET', 'POST'] }));
app.use(express.urlencoded({ extended: true }));

// CORS Middleware
app.use(function (req, res, next) {
  // Enabling CORS
  res.header("Access-Control-Allow-Origin", "*");
  res.header("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT");
  res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, contentType, Content-Type, Accept, Authorization");
  next();
});





app.use('/', routes);

// Start the server
var server = app.listen(process.env.PORT || port, function () {
  var port = server.address().port;
  console.log("App now running on port", port);
  console.log(`Server running at http://${ip}:${port}/`);
});

// Initialising connection string





// Routes
// Home page
