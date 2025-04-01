namespace WinFormsApp1
{
    partial class BooksForm
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            tbTitle = new TextBox();
            tbGenre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(213, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(485, 436);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(12, 49);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(150, 31);
            tbTitle.TabIndex = 1;
            tbTitle.TextChanged += tbTitle_TextChanged;
            // 
            // tbGenre
            // 
            tbGenre.Location = new Point(12, 110);
            tbGenre.Name = "tbGenre";
            tbGenre.Size = new Size(150, 31);
            tbGenre.TabIndex = 2;
            tbGenre.TextChanged += tbGenre_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 3;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 4;
            label2.Text = "Genre";
            // 
            // BooksForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbGenre);
            Controls.Add(tbTitle);
            Controls.Add(flowLayoutPanel1);
            Name = "BooksForm";
            Text = "BooksForm";
            Load += BooksForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox tbTitle;
        private TextBox tbGenre;
        private Label label1;
        private Label label2;
    }
}