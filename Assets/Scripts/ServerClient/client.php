<?php
    $host = "10.25.3.26";
    $port = 7777;
    $option = $_REQUEST["option_post"];
    $in = "photo";
    $client_socket = socket_create(AF_INET, SOCK_STREAM,0) or die("Could not create socket\n");
    socket_connect ($client_socket , $host, $port);
    socket_write($client_socket, $option, strlen($in));
    $buffer = null;
    $ext = null;
    socket_recv($client_socket, $ext, 8, 0);
    //echo $ext;
    socket_recv($client_socket, $buffer, 13421776, 0);
    #$myfile = fopen("test.txt", "w");
    #fwrite($myfile,$buffer);
    $imageData = null;
    switch ($ext){
        case ".png":
        case ".jpeg":
        case ".gif":
        case ".bmp":
            $imgData = base64_encode($buffer);
            $img = "<img src= 'data:image/".$ext.";base64, $imgData'>";
            
            #print($img);
            print($buffer);
            break;
        case ".ogg":
        case ".ogv":
            #$zip = new ZipArchive;
            #$result = $zip->open("file.zip");
            #if($result == TRUE){
            #    $zip->extractTo('/');
            #    $zip->close();
            #}

            #$filename = "woot.ogv";
            #$psp = "data.flv";
            #header("Content-type: video/ogv");
            #header("Content-Disposition:attachment;filename=$filename");
            #header("Content-length: " . filesize($psp) . "\n\n"); 
            #echo file_get_contents($psp);
            echo $buffer;
            break;
        default:
            $imgData = $buffer;
            $img = "<img src= 'data:image/".$ext.";base64, $imgData'>";
            print($img);
    }
    
   
    
    $fp = fopen("data".$ext, 'w');
    fwrite($fp, $buffer);
    fclose($fp);
?>