using System.Net.Sockets;
using System;

namespace Client
{
    public partial class ChatForm : Form
    {

        /// <summary>
        ///     Initializes a new instance of the ChatForm class.
        /// </summary>
        public ChatForm()
        {
            InitializeComponent();
        }



        const int portNo = 50000;
        TcpClient client;
        byte[] data;


        /// <summary>
            /// Event handler for the "Sign In" button click event.
            /// Connects to the server if not already connected, or disconnects from the server if already connected.
        /// </summary>

        private void btnSignIn_Click_1(object sender, EventArgs e)
        {
            if (btnSignIn.Text == "Sign In")
            {
                try
                {
                    //---connect to server---
                    client = new TcpClient();
                    client.Connect("127.0.0.1", portNo);
                    data = new byte[client.ReceiveBufferSize];
                    //---read from server---
                    SendMessage(txtNick.Text);
                    client.GetStream().BeginRead(data, 0,
                    System.Convert.ToInt32(
                        client.ReceiveBufferSize),
                        ReceiveMessage, null);
                    
                    btnSignIn.Text = "Sign Out";
                    btnSend.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                //---disconnect from server---
                Disconnect();
                btnSignIn.Text = "Sign In";
                btnSend.Enabled = false;
            }
        }


        /// <summary>
        /// Event handler for the "Send" button click event.
        /// Sends the message entered in the text box to the server.
        /// </summary>
        private void btnSend_Click_1(object sender, EventArgs e)
        {
            SendMessage(txtMessage.Text);
            txtMessage.Clear();
        }



        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void SendMessage(string message)
        {
            try
            {
                //---send a message to the server---
                NetworkStream ns = client.GetStream();
                byte[] data =
                System.Text.Encoding.ASCII.GetBytes(message);
                //---send the text---
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        /// <summary>
        /// Callback method for receiving messages from the server.
        /// </summary>
        /// <param name="ar">The async result containing the received data.</param>
        public void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;
                //---read the data from the server---
                bytesRead = client.GetStream().EndRead(ar);
                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    //---invoke the delegate to display the
                    // received data---
                    object[] para = { System.Text.Encoding.ASCII.GetString(data, 0, bytesRead) };
                    this.Invoke(new delUpdateHistory(UpdateHistory), para);
                }
                //---continue reading...---
                client.GetStream().BeginRead(data, 0,
                System.Convert.ToInt32(client.ReceiveBufferSize),
                ReceiveMessage, null);
            }
            catch (Exception ex)
            {
       
            }
        }


        /// <summary>
        /// Updates the message history in the text box with the specified string.
        /// </summary>
        /// <param name="str">The string to append to the message history.</param>
        public delegate void delUpdateHistory(string str);
        public void UpdateHistory(string str)
        {
            txtMessageHistory.AppendText(str);
        }


        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        public void Disconnect()
        {
            try
            {
                client.GetStream().Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}