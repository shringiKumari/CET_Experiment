<?php
$hostname = 'new';
$password = '4m4z0nakr!';
$username = 'root';
$port = '3306';
$dbname = 'ebdb';




$gameID = $_POST['gameID']; 
$ip = md5(get_client_ip());

 

$mysqli = new mysqli($hostname,$username,$password,$dbname,$port);

$statement = $mysqli->prepare("INSERT INTO GameplaySession(gameID,ip) VALUES (?,?)");
$statement->bind_param('ss',$gameID,$ip);


$statement->execute();
$insid = $mysqli->insert_id;


echo($insid);

function get_client_ip() {
    $ipaddress = '';
    if (getenv('HTTP_CLIENT_IP'))
        $ipaddress = getenv('HTTP_CLIENT_IP');
    else if(getenv('HTTP_X_FORWARDED_FOR'))
        $ipaddress = getenv('HTTP_X_FORWARDED_FOR');
    else if(getenv('HTTP_X_FORWARDED'))
        $ipaddress = getenv('HTTP_X_FORWARDED');
    else if(getenv('HTTP_FORWARDED_FOR'))
        $ipaddress = getenv('HTTP_FORWARDED_FOR');
    else if(getenv('HTTP_FORWARDED'))
       $ipaddress = getenv('HTTP_FORWARDED');
    else if(getenv('REMOTE_ADDR'))
        $ipaddress = getenv('REMOTE_ADDR');
    else
        $ipaddress = 'UNKNOWN';
    return $ipaddress;
}


 ?> 
 
