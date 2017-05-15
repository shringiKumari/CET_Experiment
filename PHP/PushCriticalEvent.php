<?php
$hostname = 'aa1en9monf18b2a.cr0zaaibyfhg.eu-west-2.rds.amazonaws.com';
$password = '4m4z0nakr!';
$username = 'root';
$port = '3306';
$dbname = 'ebdb';

$title = $_POST['title'];
$info = $_POST['info'];
$session = $_POST['session'];

$length = count($title);
		
$mysqli = new mysqli($hostname,$username,$password,$dbname,$port);

for($i = 0; $i<$length; $i++){
$statement = $mysqli->prepare("INSERT INTO CriticalEvents(session,title,info) VALUES (?,?,?)");
$statement->bind_param('iss',intval($session),$title[$i],$info[$i]);
$statement->execute();
}

echo("Commit");

?>