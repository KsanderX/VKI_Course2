using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Controllers
{
    public class КнигиController : Controller
    {
        private readonly LIbraryContext _context;

        public КнигиController(LIbraryContext context)
        {
            _context = context;
        }

        // GET: Книги
        public async Task<IActionResult> Index()
        {
            return View(await _context.Книгиs.ToListAsync());
        }

        // GET: Книги/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var книги = await _context.Книгиs
                .FirstOrDefaultAsync(m => m.IdКниги == id);
            if (книги == null)
            {
                return NotFound();
            }

            return View(книги);
        }

        // GET: Книги/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Книги/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdКниги")] Книги книги)
        {
            if (ModelState.IsValid)
            {
                _context.Add(книги);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(книги);
        }

        // GET: Книги/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var книги = await _context.Книгиs.FindAsync(id);
            if (книги == null)
            {
                return NotFound();
            }
            return View(книги);
        }

        // POST: Книги/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdКниги")] Книги книги)
        {
            if (id != книги.IdКниги)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(книги);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!КнигиExists(книги.IdКниги))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(книги);
        }

        // GET: Книги/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var книги = await _context.Книгиs
                .FirstOrDefaultAsync(m => m.IdКниги == id);
            if (книги == null)
            {
                return NotFound();
            }

            return View(книги);
        }

        // POST: Книги/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var книги = await _context.Книгиs.FindAsync(id);
            if (книги != null)
            {
                _context.Книгиs.Remove(книги);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool КнигиExists(int id)
        {
            return _context.Книгиs.Any(e => e.IdКниги == id);
        }
    }
}
