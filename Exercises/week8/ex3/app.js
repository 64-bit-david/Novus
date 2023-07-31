var express = require("express");
const cors = require("cors");
var bodyParser = require("body-parser");
var sql = require("msnodesqlv8"); 
var app = express();
const path = require("path");
var form = require("multer");
const { json } = require("body-parser");



app.set('view engine', 'pug');
const ip = '127.0.0.1';
const port = '4040';

// Body Parser Middleware
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
var urlencodedParser = bodyParser.urlencoded({ extended: false });
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

// Setting up server
var server = app.listen(process.env.PORT || 4040, function () {
  var port = server.address().port;
  console.log("App now running on port", port);
  console.log(`server running at http://${ip}:${port}/`);
});

// Initialising connection string
const connectionString = "server=.\\SQLEXPRESS;Database=Node;Trusted_Connection=Yes;Driver={SQL Server Native Client 11.0}";


console.log('connectString: ' + connectionString)

var items = [];
var item = [];
var items2 = [];
var item2 = [];

// Function to connect to the database and execute query
// GET ALL ACTIVE USERS FOR PATHWAYS
app.get("/", function (req, res) {
  var query = "select * from Studentinfo;";
  sql.query(connectionString, query, (err, recordset) => {
    if (err) {
      console.error("Error executing the query:");
      console.error(err);
    } else {
      items = recordset;
      console.log("--------------------");
      console.log(items)
      res.render('index', { title: 'items', items: items });
      res.end();
    }
  });
});

// POST API
app.post("/user", function (req, res) {
  userid = req.body["dropDown"];
  var query = "select * from Studentinfo where ID = '" + userid[0] + "'";
  sql.query(connectionString, query, (err, recordset) => {
    if (err) {
      console.error("Error executing the query:");
      console.error(err);
    } else {
      items = recordset;
      console.log(items)
      if (items.length > 0) {
        console.log("length greater than 0");
      } else {
        console.log("length equal 0");
      }
      res.render('table', { title: 'items', items: items });
      res.end();
    }
  });
});

// PUT API
app.put("/api/user/:id", function (req, res) {
  var query = "UPDATE [user] SET Name= " + req.body.Name + ", Email= " + req.body.Email + " WHERE Id= " + req.params.id;
  executeQuery(res, query);
});

// DELETE API
app.delete("/api/user/:id", function (req, res) {
  var query = "DELETE FROM [user] WHERE Id=" + req.params.id;
  executeQuery(res, query);
});

// Function to execute a query and return a promise
function executeQuery(res, query) {
  return new Promise((resolve, reject) => {
    sql.query(connectionString, query, (err, rows) => {
      if (err) {
        console.error("Error executing the query:");
        console.error(err);
        reject(err);
      } else {
        console.log("Query executed successfully. Results:");
        console.log(rows);
        res.send(rows);
        resolve(rows);
      }
    });
  });
}
