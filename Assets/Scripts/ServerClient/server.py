import os
import socket
import sys
from thread import *
import datetime

host = socket.gethostname()
port = 7777

# Create server socket
try:
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    print 'Socket Creation: Success'
except socket.error, error_message:
    print 'Socket Creation: Failure'
    print '\tError: ' + (error_message)
    sys.exit()

# Bind server socket
try:
    server_socket.bind((host, port))
    print 'Socket Bind: Success'
except socket.error, error_message:
    print 'Socket Bind: Failure'
    print '\tError: ' + str(error_message)
    sys.exit()


print socket.gethostbyname(socket.gethostname())

# Listening on server socket
server_socket.listen(5)

# Functions
def photo():
    #connection.send('hello photo');
    image_list = os.listdir('C:\Users\John Li\Pictures\Test')
    for file in image_list:
        print file
    image_request = [img for img in image_list if img.endswith('.png')]

    #for i in image_request:
    #connection.send(ima_request[0])
    file_n = open(image_request[0], 'rb').read()

    #file_w = open("blank.txt", "w")
    #file_w.write(file_n)

    #s = file_n.readline(512)
    connection.send(".png")

    connection.send(file_n)
    print image_request[0]
    file_n.close()
    file_w.close()

def music():
        #connection.send('hello photo');
    video_list = os.listdir('C:\Users\John Li\Pictures\Test')
    for file in video_list:
        print file
    video_request = [vid for vid in video_list if vid.endswith('.mp3')]

    connection.send(".mp3")

    #for i in image_request:
    #connection.send(ima_request[0])
    file_n = open(video_request[0], 'rb').read()

    connection.send(file_n)
    file_n.close()

def video():
        #connection.send('hello photo');
    video_list = os.listdir('C:\Users\John Li\Pictures\Test')
    for file in video_list:
        print file
    video_request = [vid for vid in video_list if vid.endswith('.wmv')]

    connection.send(".wmv")

    #for i in image_request:
    #connection.send(ima_request[0])
    file_n = open(video_request[0], 'rb').read()

    connection.send(file_n)
    file_n.close()
    
# List of services
service = {
    'photo' : photo,
    'music' : music,
    'video' : video,
}

# Handle connections via threads
def client_thread(connection):
    #   connection.send('\nWelcome to Potato Land!\n')
    option = ""
    while option != "no life":
        try:
            option = connection.recv(1024)
            print option
            service[option]()
        except socket.error, noresponse:
            connection.close()
    connection.close()

# Server
while 1:
    connection, address = server_socket.accept()
    print 'Connected with ' + address[0] + ':' + str(address[1])
    start_new_thread(client_thread, (connection,))
    
# Close server socket
server_socket.close()