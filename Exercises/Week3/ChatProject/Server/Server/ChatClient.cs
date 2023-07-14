using System;
using System.Net.Sockets;
using System.Collections;

namespace Server
{
    /*
     A Class respresenting a User Chat Server
     */

    public class ChatClient
    {
        //contains list of all clients
        public static Hashtable AllClients = new Hashtable();

        private Socket _client;
        private string _clientIP;
        private string _clientNick;

        //used for sending and recieving data
        private byte[] _buffer;

        //is the nickname being sent?
        private bool ReceiveNick = true;


        /// <summary>
        ///     Constructor for the ChatClient class
        ///     Initialises the client object and stores client ip address, 
        ///     adds the client to the AllClients hashtable and starts reading the 
        ///     data from the client
        /// </summary>
        /// <param name="client">Socket obj representing the client connection</param>
        public ChatClient(Socket client)
        {
            _client = client;
           
            _clientIP = client.RemoteEndPoint.ToString();
            AllClients.Add(_clientIP, this);
            
            _buffer = new byte[1024];
            _client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveMessage, null);
        }

        /// <summary>
        ///     Method for recieiving messages from the client.
        ///     Reads data from the client, check if message is setting up
        ///     nickname or actual message and removes client if disconnected.
        /// </summary>
        /// <param name="ar">IAsyncResult object</param>
        
        
        public void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead = _client.EndReceive(ar);
                //client has disconnected
                if (bytesRead < 1)
                {
                    AllClients.Remove(_clientIP);
                    Broadcast(_clientNick + " has left the chat.");
                    _client.Close();
                    return;
                }
                else
                {
                    //get the message sent
                    string messageReceived = System.Text.Encoding.ASCII.GetString(_buffer, 0, bytesRead);
                    //client is sending its nickname
                    if (ReceiveNick)
                    {
                        _clientNick = messageReceived;
                        Broadcast(_clientNick + " has joined the chat.");
                        ReceiveNick = false;
                    }
                    else
                    {
                        //broadcast the message to everyone
                        Broadcast(_clientNick + "-->" + messageReceived);
                    }
                }

                _client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveMessage, null);
            }
            catch (SocketException)
            {
                AllClients.Remove(_clientIP);
                Broadcast(_clientNick + " has left the chat.");
                _client.Close();
            }


        }

        /// <summary>
        ///     Method for sending messages to the client through the network stream.
        /// </summary>
        /// <param name="message">String representation of the message to send.</param>
        public void SendMessage(string message)
        {
            try
            {
                System.Net.Sockets.NetworkStream ns;
                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                _client.Send(bytesToSend);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending the message" + ex.ToString());
            }
        }


        /// <summary>
        ///     Method for broadcasting message to all connected clients.
        /// </summary>
        /// <param name="message">String representation of message to broadcast</param>
        public void Broadcast(string message)
        {
            try
            {
                Console.WriteLine(message);
                foreach (DictionaryEntry c in AllClients)
                {
                    //broadcast message to all users
                    ((ChatClient)(c.Value)).SendMessage(message + Environment.NewLine);
                }
            } catch  (Exception ex)
            {
                Console.WriteLine("Error Broadcasting the message" + ex.ToString());
            }
           
        }
    }
}
