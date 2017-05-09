<?php
$hostname = 'new';
$password = '4m4z0nakr!';
$username = 'root';
$port = '3306';
$dbname = 'ebdb';

$session = $_POST['session'];
$length = intval($_POST['length']);

$mysqli = new mysqli($hostname,$username,$password,$dbname,$port);

$output = "";

for($i = 0; $i<$length; $i++){
$statement = $mysqli->prepare("INSERT INTO Events(session) VALUES (?)");
$statement->bind_param('i',intval($session));
$statement->execute();
$output = $output.strval($mysqli->insert_id);

if($i<$length-1){$output = $output.",";}



}

echo($output);



?>