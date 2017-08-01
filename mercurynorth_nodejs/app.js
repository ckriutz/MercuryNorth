var express = require('express');
var os = require('os');

var app = express();

// set the view engine to ejs
app.set('view engine', 'ejs');

var port = 5000;

app.use(express.static('public'));

app.get('/', (req, res) => {
  var year = random(1950, 1998);
  // render `home.ejs` with the list of posts
  res.render('index', { year: year, machine: os.hostname() })
})

app.listen(port, function(err) {
   console.log('running server on port ' + port);
   console.log('running on ' + os.hostname());
});

function random (low, high) {
    return Math.floor(Math.random() * (high - low) + low);
}