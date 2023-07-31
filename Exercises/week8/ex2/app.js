var express = require('express');
var app = express();

// Update: Require the msnodesqlv8 package
const sql = require("msnodesqlv8");

app.get('/', function (req, res) {
  // Config for your database
  const connectionString = "server=.\\SQLEXPRESS;Database=Node;Trusted_Connection=Yes;Driver={SQL Server Native Client 11.0}";
  const query = "SELECT * FROM Node.dbo.Studentinfo;";

  // Query the database
  sql.query(connectionString, query, (err, rows) => {
    if (err) {
      console.error("Error executing the query:");
      console.error(err);
      res.status(500).send("Error executing the query");
    } else {
      console.log("Query executed successfully. Results:");
      console.log(rows);
      res.send(rows);
    }
  });
});

var server = app.listen(5000, function () {
  console.log('Server is running..');
});
