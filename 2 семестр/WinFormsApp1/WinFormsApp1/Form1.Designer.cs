namespace WinFormsApp1
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
            tbTitle = new TextBox();
            tbGenre = new TextBox();
            tbDesc = new TextBox();
            dateTimePickerDeliveryDate = new DateTimePicker();
            cbUser = new ComboBox();
            btnAdd = new Button();
            btnBooks = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            UserLab = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(125, 44);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(150, 31);
            tbTitle.TabIndex = 0;
            // 
            // tbGenre
            // 
            tbGenre.Location = new Point(125, 106);
            tbGenre.Name = "tbGenre";
            tbGenre.Size = new Size(150, 31);
            tbGenre.TabIndex = 1;
            // 
            // tbDesc
            // 
            tbDesc.Location = new Point(125, 180);
            tbDesc.Name = "tbDesc";
            tbDesc.Size = new Size(150, 31);
            tbDesc.TabIndex = 2;
            // 
            // dateTimePickerDeliveryDate
            // 
            dateTimePickerDeliveryDate.Format = DateTimePickerFormat.Time;
            dateTimePickerDeliveryDate.Location = new Point(125, 253);
            dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            dateTimePickerDeliveryDate.Size = new Size(150, 31);
            dateTimePickerDeliveryDate.TabIndex = 4;
            // 
            // cbUser
            // 
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(125, 315);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(182, 33);
            cbUser.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(125, 354);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(146, 46);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Создать запись";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBooks
            // 
            btnBooks.BackColor = Color.Lime;
            btnBooks.Location = new Point(673, 386);
            btnBooks.Name = "btnBooks";
            btnBooks.Size = new Size(115, 52);
            btnBooks.TabIndex = 8;
            btnBooks.Text = "Книги";
            btnBooks.UseVisualStyleBackColor = false;
            btnBooks.Click += btnBooks_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 16);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 9;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(125, 78);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 10;
            label2.Text = "Genre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 152);
            label3.Name = "label3";
            label3.Size = new Size(102, 25);
            label3.TabIndex = 11;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(125, 225);
            label4.Name = "label4";
            label4.Size = new Size(112, 25);
            label4.TabIndex = 12;
            label4.Text = "DeliveryDate";
            // 
            // UserLab
            // 
            UserLab.AutoSize = true;
            UserLab.Location = new Point(125, 287);
            UserLab.Name = "UserLab";
            UserLab.Size = new Size(47, 25);
            UserLab.TabIndex = 13;
            UserLab.Text = "User";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(dateTimePickerDeliveryDate);
            panel1.Controls.Add(UserLab);
            panel1.Controls.Add(tbTitle);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(tbGenre);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(tbDesc);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbUser);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnAdd);
            panel1.Location = new Point(176, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(438, 426);
            panel1.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(btnBooks);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbTitle;
        private TextBox tbGenre;
        private TextBox tbDesc;
        private DateTimePicker dateTimePickerDeliveryDate;
        private ComboBox cbUser;
        private Button btnAdd;
        private Button btnBooks;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label UserLab;
        private Panel panel1;
    }
}
