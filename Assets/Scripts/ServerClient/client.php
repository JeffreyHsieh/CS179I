<?php
    $host = "10.25.28.210";
    $port = 7777;

    $client_socket = socket_create(AF_INET, SOCK_STREAM,0) or die("Could not create socket\n");
    socket_connect ($client_socket , $host, $port ) ;

    $in = "photo";

    socket_write($client_socket, $in, strlen($in));

    $buffer = null;

    socket_recv($client_socket, $buffer, 80000, 0);

    //echo $buffer;
    $imgData = base64_encode($buffer);
    $img = "<img src= 'data:image/png;base64, $imgData' />";
    print($img);


    $fp = fopen('data.png', 'w');
    fwrite($fp, $buffer);
    fclose($fp);

?>