using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class BooksForm : Form
    {
        private LiblaryContext _context;
        public BooksForm()
        {
            InitializeComponent();
            _context = new LiblaryContext();
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            // var findBooks = _context.Books.ToList();

            var findBooks = _context.Books.Include(b => b.User).ToList();


            foreach (var book in findBooks)
            {
                flowLayoutPanel1.Controls.Add(new BooksControl(book));
            }
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var findBooks = _context.Books.Where(b => b.Title == tbTitle.Text).ToList();

            foreach (var book in findBooks)
            {
                flowLayoutPanel1.Controls.Add(new BooksControl(book));
            }

        }

        private void tbGenre_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var findBooks = _context.Books.Where(b => b.Genre == tbGenre.Text).ToList();

            foreach (var book in findBooks)
            {
                flowLayoutPanel1.Controls.Add(new BooksControl(book));
            }
        }
    }
}
