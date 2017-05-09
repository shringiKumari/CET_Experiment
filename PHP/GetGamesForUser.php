<?php
$hostname = 'new';
$password = '4m4z0nakr!';
$username = 'root';
$port = '3306';
$dbname = 'ebdb';


$mysqli = new mysqli($hostname,$username,$password,$dbname,$port);

$id = -1; 

$statement = $mysqli->prepare("SELECT GameID , GameTitle from Game Where Game.GameID >= ?");
$statement->bind_param('i',$id);
$statement->execute();
$result = $statement->get_result();

$row = $result->fetch_array(MYSQLI_NUM);
		echo($row[0]."Â¬".$row[1]);

    while ($row = $result->fetch_array(MYSQLI_NUM)) {
		echo("|".$row[0]."Â¬".$row[1]);		
    }



 ?> 