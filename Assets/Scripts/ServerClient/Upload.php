<?php
    $host = "169.235.104.126";
    $port = 7777;

    $client_socket = socket_create(AF_INET, SOCK_STREAM,0) or die("Could not create socket\n");
    socket_connect ($client_socket , $host, $port);

    $in = "upload";

    socket_write($client_socket, $in, strlen($in));
    #an associative array  of items uploaded to the curent script using the HTTP POST method
    #check if there is a chosen file on the sumbitted form
   if(isset($_FILES['file']))
   {


   move_uploaded_file($_FILES['file']['tmp_name'], "../uploads/" . $_FILES['file']['name']);

   } else
   {
      print("Failed!");
   }
?>
   