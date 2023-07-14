namespace CalculateShapAreaWF
{
    partial class TriangleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(373, 281);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(267, 151);
            label2.Name = "label2";
            label2.Size = new Size(144, 15);
            label2.TabIndex = 7;
            label2.Text = "Enter the length of side 1: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(461, 148);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(77, 23);
            textBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(232, 45);
            label1.Name = "label1";
            label1.Size = new Size(347, 32);
            label1.TabIndex = 5;
            label1.Text = "Calculate the Area of a Triangle";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(267, 185);
            label3.Name = "label3";
            label3.Size = new Size(144, 15);
            label3.TabIndex = 10;
            label3.Text = "Enter the length of side 2: ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(461, 182);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(77, 23);
            textBox2.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(267, 218);
            label4.Name = "label4";
            label4.Size = new Size(144, 15);
            label4.TabIndex = 12;
            label4.Text = "Enter the length of side 3: ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(461, 215);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(77, 23);
            textBox3.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(198, 91);
            label5.Name = "label5";
            label5.Size = new Size(434, 21);
            label5.TabIndex = 13;
            label5.Text = "Enter the length of each side of a triangle to caculate its width";
            // 
            // TriangleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "TriangleForm";
            Text = "TriangleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
    }
}