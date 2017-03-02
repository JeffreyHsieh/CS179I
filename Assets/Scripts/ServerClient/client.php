<?php
    $host = "10.25.2.107";
    $port = 7777;

    $client_socket = socket_create(AF_INET, SOCK_STREAM,0) or die("Could not create socket\n");
    socket_connect ($client_socket , $host, $port);

    $in = "video";

    socket_write($client_socket, $in, strlen($in));

    $buffer = null;
    $ext = null;
    socket_recv($client_socket, $ext, 8, 0);
    echo $ext;
    socket_recv($client_socket, $buffer, 13421776, 0);

    echo "after recv";
    $myfile = fopen("test.txt", "w");
    fwrite($myfile,$buffer);
    $imageData = null
    switch ($ext){
        case ".png":
        case ".jpeg":
        case ".gif":
        case ".bmp":
            $imgData = base64_encode($buffer);
            $img = "<img src= 'data:image/".$ext.";base64, $imgData'>";
            break;
        default:
            $imageData = $buffer;
            $img = "<img src= 'data:image/".$ext.";base64, $imgData'>";
            break;
    }
    

   
    print($img);
    $fp = fopen("data".$ext, 'w');
    fwrite($fp, $buffer);
    fclose($fp);
?>