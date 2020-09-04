﻿using System;
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
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Waiting for a connection...");

            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; //Will auto flush

            string message = sr.ReadLine();

            Console.WriteLine("Received Message: " + message);
            if (message != null)
            {
                sw.WriteLine(message.ToUpper());
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