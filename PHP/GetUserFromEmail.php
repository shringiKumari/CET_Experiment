<?php
$hostname = 'aa1en9monf18b2a.cr0zaaibyfhg.eu-west-2.rds.amazonaws.com';
$password = '4m4z0nakr!';
$username = 'root';
$port = '3306';
$dbname = 'ebdb';



		$email = $_POST['email']; 
		$password = $_POST['password'];
		
$mysqli = new mysqli($hostname,$username,$password,$dbname,$port);

$statement = $mysqli->prepare("SELECT UserID, Password From User Where EmailAddress = ?");
$statement->bind_param('s',$email);
$statement->execute();
$result = $statement->get_result();

	if ($result->num_rows>0) {

		$row = $result->fetch_array(MYSQLI_NUM);
		if(strcmp ( $row[1] , md5($password))==0){
		echo($row[0]);
		}
		else{
		echo("-2");
		}
   }
	else{

	$statement2 = $mysqli->prepare("INSERT INTO User(EmailAddress,Password) VALUES (?,?)");
	$statement2->bind_param('ss',$email,md5($password));
	$statement2->execute();
	$insid = $mysqli->insert_id;
	echo($insid);
	}


 ?> 
 
