using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private LiblaryContext _context;
        public Form1()
        {
            InitializeComponent();
            _context = new LiblaryContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbUser.DataSource = _context.Users.ToList();
            cbUser.DisplayMember = "Name";
            cbUser.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text; // название
            string genre = tbGenre.Text; // жанр
            string desc = tbDesc.Text; // описание

            DateTime selectedDateTime = dateTimePickerDeliveryDate.Value; // дата сдачи

            // Status bookStatus = (Status)cbStatusBook.SelectedItem; // статус наличия

            int userId = (int)cbUser.SelectedValue; // айди пользователя которому выдали

            Book book = new Book();
            book.Title = title;
            book.Genre = genre;
            book.Description = desc;
            book.DateOfDelivery = selectedDateTime;
            book.UserId = userId;

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            var booksForm = new BooksForm();
            booksForm.ShowDialog();
        }
    }
}
