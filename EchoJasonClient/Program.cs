using System;
using System.IO;
using System.Net.Sockets;
using CarLibrary;
using Newtonsoft.Json;

namespace EchoJasonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World it is client!");
            Car carObject = new Car{ Color = "red", Model = "BMW", RegNo = "XM 1111" };
           
            string getInput=Console.ReadLine();

            TcpClient clientSocket = new TcpClient("localhost", 10001);


            Stream ns = clientSocket.GetStream();  //provides a Stream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            //string message = Console.ReadLine();
            // string message = (carObject.ToString());
            while (getInput != "STOP")
            {
                string message = JsonConvert.SerializeObject(carObject);
                Console.WriteLine("Client Message ==> :" + message);

                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();

                Console.WriteLine("Server Message ==>: " + serverAnswer);

                Console.WriteLine("STOP for close");
                getInput = Console.ReadLine();
            } 
            

            ns.Close();

            clientSocket.Close();

        }
    }
}
