using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    class Client
    {
        public static void Start()
        {
            Console.WriteLine("Press any bottom to connect ");
            Console.ReadKey();
            TcpClient socket = new TcpClient("localhost", 7777);

            //Creating a stream of data, that can both been read, and write from a byte stream
            NetworkStream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; //Will auto flush

           

            while (true)
            {
                string line = sr.ReadLine();
                
                //If the user enters c the connection will close down
                if (line.ToLower() == "c")
                {
                    break;   
                }
                else if (line != null && line.ToLower() != "c")
                {
                    Console.WriteLine(line);
                    sw.WriteLine(Console.ReadLine());
                }
            }

            
        }
    }
}
