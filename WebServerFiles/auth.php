<?php
// variables
$user = $_GET['user'];
$pass = $_GET['password'];
$hostname = "localhost";
$username = "Zordon";
$password = "123";
$database = "ExampleAppWithLoginDB";
$dbconnect = mysqli_connect($hostname, $username, $password, $database);

// auth check
$sql = "SELECT username FROM users WHERE username = '$user' && password = '$pass'";
$queryresult = $dbconnect->query($sql);

if($queryresult->num_rows > 0) {
    echo "1";
}
else {
    echo "0";
}

?>