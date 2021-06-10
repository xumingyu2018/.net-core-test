using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileDemo.Models;
using FileDemo.Data;

namespace FileDemo.Controllers
{
    public class DocDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DocDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.DocumentDetail.ToListAsync());
        }

        // GET: DocDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentDetail = await _context.DocumentDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentDetail == null)
            {
                return NotFound();
            }

            return View(documentDetail);
        }

        // GET: DocDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,FileType,DocName,DocDesc")] DocumentDetail documentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentDetail);
        }

        // GET: DocDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentDetail = await _context.DocumentDetail.FindAsync(id);
            if (documentDetail == null)
            {
                return NotFound();
            }
            return View(documentDetail);
        }

        // POST: DocDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,FileType,DocName,DocDesc")] DocumentDetail documentDetail)
        {
            if (id != documentDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentDetailExists(documentDetail.Id))
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
            return View(documentDetail);
        }

        // GET: DocDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentDetail = await _context.DocumentDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentDetail == null)
            {
                return NotFound();
            }

            return View(documentDetail);
        }

        // POST: DocDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentDetail = await _context.DocumentDetail.FindAsync(id);
            _context.DocumentDetail.Remove(documentDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentDetailExists(int id)
        {
            return _context.DocumentDetail.Any(e => e.Id == id);
        }
    }
}
