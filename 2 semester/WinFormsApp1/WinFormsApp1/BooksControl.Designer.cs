namespace WinFormsApp1
{
    partial class BooksControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            cbUser = new ComboBox();
            dateTimePickerDeliveryDate = new DateTimePicker();
            tbDesc = new TextBox();
            tbGenre = new TextBox();
            tbTitle = new TextBox();
            cbStatusBook = new ComboBox();
            tbId = new TextBox();
            btnDel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Descriptions = new Label();
            label41 = new Label();
            StatusBook = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(122, 586);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 46);
            btnSave.TabIndex = 13;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cbUser
            // 
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(133, 453);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(182, 33);
            cbUser.TabIndex = 12;
            // 
            // dateTimePickerDeliveryDate
            // 
            dateTimePickerDeliveryDate.Format = DateTimePickerFormat.Time;
            dateTimePickerDeliveryDate.Location = new Point(133, 382);
            dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            dateTimePickerDeliveryDate.Size = new Size(150, 31);
            dateTimePickerDeliveryDate.TabIndex = 11;
            // 
            // tbDesc
            // 
            tbDesc.Location = new Point(133, 311);
            tbDesc.Name = "tbDesc";
            tbDesc.Size = new Size(150, 31);
            tbDesc.TabIndex = 10;
            // 
            // tbGenre
            // 
            tbGenre.Location = new Point(133, 244);
            tbGenre.Name = "tbGenre";
            tbGenre.Size = new Size(150, 31);
            tbGenre.TabIndex = 9;
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(133, 172);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(150, 31);
            tbTitle.TabIndex = 8;
            // 
            // cbStatusBook
            // 
            cbStatusBook.FormattingEnabled = true;
            cbStatusBook.Location = new Point(133, 533);
            cbStatusBook.Name = "cbStatusBook";
            cbStatusBook.Size = new Size(182, 33);
            cbStatusBook.TabIndex = 14;
            // 
            // tbId
            // 
            tbId.Location = new Point(133, 104);
            tbId.Name = "tbId";
            tbId.ReadOnly = true;
            tbId.Size = new Size(150, 31);
            tbId.TabIndex = 15;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(292, 586);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(86, 46);
            btnDel.TabIndex = 16;
            btnDel.Text = "Delite";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 76);
            label1.Name = "label1";
            label1.Size = new Size(28, 25);
            label1.TabIndex = 17;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(133, 144);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 18;
            label2.Text = "Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(133, 216);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 19;
            label3.Text = "Genre";
            // 
            // Descriptions
            // 
            Descriptions.AutoSize = true;
            Descriptions.Location = new Point(133, 283);
            Descriptions.Name = "Descriptions";
            Descriptions.Size = new Size(44, 25);
            Descriptions.TabIndex = 20;
            Descriptions.Text = "Title";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(133, 354);
            label41.Name = "label41";
            label41.Size = new Size(112, 25);
            label41.TabIndex = 21;
            label41.Text = "DateDelivery";
            // 
            // StatusBook
            // 
            StatusBook.AutoSize = true;
            StatusBook.Location = new Point(133, 505);
            StatusBook.Name = "StatusBook";
            StatusBook.Size = new Size(112, 25);
            StatusBook.TabIndex = 22;
            StatusBook.Text = "DateDelivery";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(133, 425);
            label4.Name = "label4";
            label4.Size = new Size(47, 25);
            label4.TabIndex = 23;
            label4.Text = "User";
            // 
            // BooksControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(StatusBook);
            Controls.Add(label41);
            Controls.Add(Descriptions);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDel);
            Controls.Add(tbId);
            Controls.Add(cbStatusBook);
            Controls.Add(btnSave);
            Controls.Add(cbUser);
            Controls.Add(dateTimePickerDeliveryDate);
            Controls.Add(tbDesc);
            Controls.Add(tbGenre);
            Controls.Add(tbTitle);
            Name = "BooksControl";
            Size = new Size(467, 693);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private ComboBox cbUser;
        private DateTimePicker dateTimePickerDeliveryDate;
        private TextBox tbDesc;
        private TextBox tbGenre;
        private TextBox tbTitle;
        private ComboBox cbStatusBook;
        private TextBox tbId;
        private Button btnDel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label Descriptions;
        private Label label41;
        private Label StatusBook;
        private Label label4;
    }
}
