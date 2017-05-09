<?php
$hostname = 'new';
$password = '4m4z0nakr!';
$username = 'root';
$port = '3306';
$dbname = 'ebdb';

$session = $_POST['session'];
$info = $_POST['info'];
$title = $_POST['title'];

$mysqli = new mysqli($hostname,$username,$password,$dbname,$port);


$length = count($info);

for($i = 0; $i<$length; $i++){
$statement = $mysqli->prepare("INSERT INTO SessionParameters(session,title,information) VALUES (?,?,?)");
$statement->bind_param('iss',intval($session),$title[$i],$info[$i]);
$statement->execute();
}

?>