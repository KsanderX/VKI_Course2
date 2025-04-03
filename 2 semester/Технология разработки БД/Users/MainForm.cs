using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Users.DB;

namespace Users
{
    public partial class MainForm : Form
    {
        private readonly AppDbContext _context;
        private BindingSource _bindingSource;
        public MainForm()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _bindingSource = new BindingSource();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
