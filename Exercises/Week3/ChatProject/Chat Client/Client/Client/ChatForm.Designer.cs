using System.Net.Sockets;

namespace Client
{
    partial class ChatForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNick = new TextBox();
            label1 = new Label();
            btnSignIn = new Button();
            txtMessageHistory = new TextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // txtNick
            // 
            txtNick.Location = new Point(56, 25);
            txtNick.Name = "txtNick";
            txtNick.Size = new Size(162, 23);
            txtNick.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Nick";
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(244, 25);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(75, 23);
            btnSignIn.TabIndex = 2;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click_1;
            // 
            // txtMessageHistory
            // 
            txtMessageHistory.Location = new Point(12, 54);
            txtMessageHistory.Multiline = true;
            txtMessageHistory.Name = "txtMessageHistory";
            txtMessageHistory.Size = new Size(317, 339);
            txtMessageHistory.TabIndex = 3;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 415);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(236, 23);
            txtMessage.TabIndex = 4;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(254, 415);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 5;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 450);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(txtMessageHistory);
            Controls.Add(btnSignIn);
            Controls.Add(label1);
            Controls.Add(txtNick);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNick;
        private Label label1;
        private Button btnSignIn;
        private TextBox txtMessageHistory;
        private TextBox txtMessage;
        private Button btnSend;
    }
}