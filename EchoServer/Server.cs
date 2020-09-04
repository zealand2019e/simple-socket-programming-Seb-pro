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
            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, 7777);

            //Start server
            Console.WriteLine("Waiting for a connection...");
            serverSocket.Start();
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Connection established ");

            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; //Will auto flush
            while (true)
            {
                string message = sr.ReadLine();

                Console.WriteLine("Received Message: " + message);
                if (message != null)
                {
                    sw.WriteLine(message.ToUpper());
                }

                if (message.ToLower() == "Close ")
                {
                 break;   
                }
            }
            ns.Close();
            Console.WriteLine("Net stream closed");
            connectionSocket.Close();
            Console.WriteLine("Connection socket closed");
            serverSocket.Stop();
            Console.WriteLine("Server Stop ");
        }
    }
}
