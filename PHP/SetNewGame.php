<?php
$hostname = 'aa1en9monf18b2a.cr0zaaibyfhg.eu-west-2.rds.amazonaws.com';
$password = '4m4z0nakr!';
$username = 'root';
$port = '3306';
$dbname = 'ebdb';




		$name = $_POST['name'];
 		$user = $_POST['user']; 
		
$mysqli = new mysqli($hostname,$username,$password,$dbname,$port);


	$statement = $mysqli->prepare("INSERT INTO Game(GameTitle) VALUES (?)");
	$statement->bind_param('s',$name);
	$statement->execute();
	
	$insid = $mysqli->insert_id;

	echo($insid);



 ?> 
 
