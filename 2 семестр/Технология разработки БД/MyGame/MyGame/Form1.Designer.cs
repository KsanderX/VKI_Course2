namespace MyGame
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtIP = new TextBox();
            txtEmail = new TextBox();
            textBox5 = new TextBox();
            this.txtLevel = new TextBox();
            this.txtOrigin = new TextBox();
            this.txtSex = new TextBox();
            this.txtNickname = new TextBox();
            button1 = new Button();
            button2 = new Button();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(447, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(503, 109);
            dataGridView1.TabIndex = 0;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(27, 42);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(125, 27);
            txtLogin.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(27, 110);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 2;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(27, 179);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(125, 27);
            txtIP.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(27, 244);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 4;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(27, 311);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 5;
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new Point(221, 110);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new Size(125, 27);
            this.txtLevel.TabIndex = 6;
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new Point(221, 179);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new Size(125, 27);
            this.txtOrigin.TabIndex = 8;
            // 
            // txtSex
            // 
            this.txtSex.Location = new Point(221, 244);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new Size(125, 27);
            this.txtSex.TabIndex = 9;
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new Point(221, 42);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new Size(125, 27);
            this.txtNickname.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(27, 355);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 13;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(221, 355);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 14;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(447, 217);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(503, 109);
            dataGridView2.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 467);
            Controls.Add(dataGridView2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(this.txtNickname);
            Controls.Add(this.txtSex);
            Controls.Add(this.txtOrigin);
            Controls.Add(this.txtLevel);
            Controls.Add(textBox5);
            Controls.Add(txtEmail);
            Controls.Add(txtIP);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtIP;
        private TextBox txtEmail;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView2;
    }
}
