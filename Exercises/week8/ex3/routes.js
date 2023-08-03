// routes.js
const express = require("express");
const router = express.Router();
const sql = require("msnodesqlv8");


const connectionString = "server=.\\SQLEXPRESS;Database=Node;Trusted_Connection=Yes;Driver={SQL Server Native Client 11.0}";
// Variables for data storage
var items = [];

router.get("/", function (req, res) {
    res.render('index'); 
  });
  
  // View student page
router.get('/view-student', (req, res) => {
    var query = "select * from Studentinfo;";
    // Fetch student data from the database
    sql.query(connectionString, query, (err, recordset) => {
        if (err) {
        console.error("Error executing the query:");
        console.error(err);
        res.render('error', { errorMsg: 'An error occurred while processing your request.' });
        } else {
        items = recordset;
        console.log("--------------------");
        console.log(items);
        // Render the 'view-student' template with fetched data
        res.render('view-student', { title: 'View Student', items: items });
        }
    });
});
  
  // Add student page
router.get('/add-student', (req, res) => {
    res.render('add-student', { title: 'Add Student' });
});

// View student details
router.post("/view-student", function (req, res) {
    // Extract student ID from the request
    var userid = req.body.dropDown.split(' ')[0];
    var query = "select * from Studentinfo where ID = '" + userid + "'";

    // Fetch student details from the database
    sql.query(connectionString, query, (err, recordset) => {
        if (err) {
        console.error("Error executing the query:");
        console.error(err);
        res.render('error', { errorMsg: 'An error occurred while processing your request.' });
        } else {
        items = recordset;
        console.log(items);
        
        if (items.length > 0) {
            console.log("length greater than 0");
        } else {
            console.log("length equal 0");
        }
        
        // Render the 'table' template with student details
        res.render('table', { title: 'View Student', items: items });
        }
    });
});

// Add a new student
router.post("/add-student", function (req, res) {
    console.log('add student called');
    var name = req.body.name;
    var age = req.body.age;
    var query = `INSERT INTO Studentinfo (Name, Age) VALUES ('${name}', '${age}')`;

    // Insert new student into the database
    sql.query(connectionString, query, (err, result) => {
        if (err) {
        console.error("Error executing the query:");
        console.error(err);
        res.render('error', { errorMsg: 'An error occurred while adding the student.' });
        } else {
        console.log("New student added successfully.");
        res.render('success', { msg: 'Student Added Successfully' }); // Render success message
        }
    });
});

// Edit student page
router.get('/edit-student/:id', (req, res) => {
    var studentId = req.params.id;
    var query = `SELECT * FROM Studentinfo WHERE ID = ${studentId}`;

// Fetch student details for editing
    sql.query(connectionString, query, (err, recordset) => {
        if (err) {
        console.error("Error executing the query:");
        console.error(err);
        res.render('error', { errorMsg: 'An error occurred while processing your request.' });
        } else {
        var student = recordset[0];
        // Render the 'edit-student' template with student details
        res.render('edit-student', { title: 'Edit Student', student: student });
        }
    });
});

// Update student details
router.post("/update-student/:id", function (req, res) {
    var studentId = req.params.id;
    var name = req.body.name;
    var age = req.body.age;
    var query = `UPDATE Studentinfo SET Name = '${name}', Age = ${age} WHERE ID = ${studentId}`;

    // Update student details in the database
    sql.query(connectionString, query, (err, result) => {
        if (err) {
        console.error("Error executing the query:");
        console.error(err);
        res.render('error', { errorMsg: 'An error occurred while updating the student.' });
        } else {
        console.log("Student updated successfully.");
        res.render('success', {msg: "Student Updated Successfully"}); // Render success message
        }
    });
});

// Delete student
router.post("/delete-user/:id", function (req, res) {
    var userId = req.params.id;
    var query = `DELETE FROM Studentinfo WHERE Id=${userId}`;

    // Perform the SQL query to delete a student
    sql.query(connectionString, query, (err, result) => {
        if (err) {
        console.error("Error executing the query:");
        console.error(err);
        res.render('error', { errorMsg: 'An error occurred while processing your request.' });
        } else {
        console.log("Query executed successfully. Student Deleted");
        res.render('success', { msg: 'Student Deleted Successfully' });
        }
    });
});


module.exports = router;
