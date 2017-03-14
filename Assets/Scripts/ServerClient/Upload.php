<?php
    $host = "10.25.0.203";
    $port = 7777;

    $client_socket = socket_create(AF_INET, SOCK_STREAM,0) or die("Could not create socket\n");
    socket_connect ($client_socket , $host, $port);

    $in = "upload";
    $uid = $_REQUEST['uid'];
    $upload_folder = "./images/";

    socket_write($client_socket, $in, strlen($in));
    #an associative array  of items uploaded to the curent script using the HTTP POST method
    #check if there is a chosen file on the sumbitted form
    if(isset($_FILES['file']) )
    {
      if(isset($_POST['_chunkNumber']))
      {
          $current_chunk_number = $_REQUEST['_chunkNumber'];
          $chunk_size = $_REQUEST['_chunkSize'];
          $total_size = $_REQUEST['_totalSize'];

          $total_chunk_number = ceil($total_size / $chunk_size);
          move_uploaded_file($_FILES['file']['tmp_name'], $upload_folder . $uid . '.part' . $current_chunk_number);

          if ($current_chunk_number == ($total_chunk_number - 1)) 
          {
             for($i = 0; $i < $total_chunk_number; $i++)
             {
                $content = file_get_contents($upload_folder . $uid . '.part' . $i);
                file_put_contents($upload_folder . $filename, $content, FILE_APPEND);
                unlink($upload_folder . $uid . '.part' . $i);
             }
          }
      }
      else
      {
         move_uploaded_file($_FILES['file']['tmp_name'], "./images/" . $_FILES['file']['name']);
      }
    }
    else
    {
        print("Failed!");
    }

  
?>
   