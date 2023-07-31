const http = require('http');
const fs = require('fs');
const cors = require('cors');
const express = require('express');
const app = express();

// app.use(cors());

app.get('/', function (req, res) {
  res.sendFile(__dirname + '/index.html');
});

app.get('/index.html', function (req, res) {
  res.sendFile(__dirname + '/index.html');
});

app.get('/pagetwo.html', function (req, res) {
  res.sendFile(__dirname + '/pagetwo.html');
});

app.get('/pagethree.html', function (req, res) {
  res.sendFile(__dirname + '/pagethree.html');
});

const server = app.listen(3000, function () {
  const host = server.address().address;
  const port = server.address().port;
  console.log("Example app listening at http://%s:%s", host, port);
});
