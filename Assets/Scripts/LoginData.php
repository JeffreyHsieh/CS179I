<?php
	$servername = "10.25.23.143";
	$server_username = "root";
	$server_password = "oaGj90P5O8NO0Nkv";
	$dbName = "social_vr";
		
	$username = $_REQUEST["username_post"];

	//Make Connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection failed! ".mysqli_connect_error());
	}




	$sql = "SELECT username , password FROM login WHERE username = '".$username."'";
	$result = mysqli_query($conn, $sql);

	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo "Username:".$row['username']."|Password:".$row['password'].";";
		}
	}
?>