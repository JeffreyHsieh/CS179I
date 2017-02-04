<?php
	$servername = "localhost";
	$server_username = "root";
	$server_password = "oaGj90P5O8NO0Nkv";
	$dbName = "social vr";

	$username = $_POST["username_post"];
	$password = $_POST["password_post"];

	//Make Connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection failed! ".mysqli_connect_error());
	}

	$sql = "INSERT INTO login (username, password) 
			VALUES('".$username."', '".$password."')";
	$result = mysqli_query($conn, $sql);

	if(!$result)
		echo "An error occurred!";
	else
		echo "User added!";

?>