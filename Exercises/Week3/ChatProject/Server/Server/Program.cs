using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        const int portNo = 50000;

        static void Main(string[] args)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            TcpListener listener = new TcpListener(ipAddress, portNo);
            listener.Start();
            Console.WriteLine("Server started...");

            try
            {
                while (true)
                {
                    Socket clientSocket = listener.AcceptSocket();
                    ChatClient client = new ChatClient(clientSocket);
                }
            } catch(Exception ex)
            {
                Console.WriteLine("An error occured: " + ex.ToString());
            }
            finally
            {
                listener.Stop();
            }
          
        }
    }
 }
