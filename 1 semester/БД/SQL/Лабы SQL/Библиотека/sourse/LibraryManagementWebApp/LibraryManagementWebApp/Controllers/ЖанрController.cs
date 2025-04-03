using Microsoft.AspNetCore.Mvc;
using LibraryManagementWebApp.Models;
using System.Linq;

namespace LibraryManagementWebApp.Controllers
{
    public class ЖанрыController : Controller
    {
        private readonly LibraryContext _context;

        public ЖанрыController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var жанры = _context.Жанры.ToList();
            return View(жанры);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Жанры жанр)
        {
            if (ModelState.IsValid)
            {
                _context.Жанры.Add(жанр);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(жанр);
        }
    }
}