using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class BooksControl : UserControl
    {
        private LiblaryContext _context;
        public BooksControl(Models.Book book)
        {
            InitializeComponent();
            _context = new LiblaryContext();

            cbUser.DataSource = _context.Users.ToList();
            cbUser.DisplayMember = "Name";
            cbUser.ValueMember = "Id";

            tbId.Text = book.Id.ToString();
            tbTitle.Text = book.Title;
            tbDesc.Text = book.Description;
            tbGenre.Text = book.Genre;
            cbStatusBook.DataSource = Enum.GetValues(typeof(Status));
            cbStatusBook.Text = book.BookStatus.ToString();
            cbUser.Text = book.User.Name;

        }

        public void Update()
        {
            var findBook = _context.Books.FirstOrDefault(x => x.Id == Convert.ToInt32(tbId.Text));
            findBook.Title = tbTitle.Text;
            findBook.Description = tbDesc.Text;
            findBook.Genre = tbGenre.Text;
            findBook.BookStatus = (Status)cbStatusBook.SelectedItem;

            var selectedUserId = (int)cbUser.SelectedValue;
            findBook.UserId = selectedUserId;
            _context.Update(findBook);
            _context.SaveChanges();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var findBookDelite = _context.Books.FirstOrDefault(x => x.Id == Convert.ToInt32(tbId.Text));

            _context.Books.Remove(findBookDelite);
            _context.SaveChanges();
            this.Parent.Controls.Remove(this);
        }
    }
}
