using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    class Server
    {
        public static void Start()
        { 
            //Creating an instance of TCPlistener class that listen on a specified port
            TcpListener serverSocket = new TcpListener(7777);

            //Start server
            Console.WriteLine("Waiting for a connection...");
            serverSocket.Start();
            
            //Establish a TCP connection and accept all pending connection request
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Connection established or enter c to close the connection");

            //Using the client method
            DoClient(connectionSocket);

            //Closing the TCP listener
            serverSocket.Stop();
            Console.WriteLine("Server Stop ");

        }

        //Client method to handle the client 
        public static void DoClient(TcpClient connectionSocket)
        {
            //Creating a stream of data, that can both been read, and write from a byte stream
            NetworkStream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; //Will auto flush

            //Making a while loop that display the enter message from the user
            while (true)
            {
                sw.WriteLine("you are connected press c to disconnect");

                string message = sr.ReadLine();

                Console.WriteLine("Received Message: " + message);
                if (message != null)
                {
                    sw.WriteLine(message.ToUpper());
                }

                //If the user enters c the connection will close down
                if (message.ToLower() == "c")
                {
                    break;   
                }
            }

            sw.WriteLine("c");
            //Closing the stream of data and close the TCP connection
            ns.Close();
            Console.WriteLine("Net stream closed");
            connectionSocket.Close();
            Console.WriteLine("Connection socket closed");
        }

    }
}
