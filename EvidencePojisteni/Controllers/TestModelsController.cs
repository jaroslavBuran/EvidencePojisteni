using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidencePojisteni.Data;
using EvidencePojisteni.Models;

namespace EvidencePojisteni.Controllers
{
    public class TestModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestModels.ToListAsync());
        }

        // GET: TestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModels
                .FirstOrDefaultAsync(m => m.TestId == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // GET: TestModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestId,Name")] TestModel testModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testModel);
        }

        // GET: TestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModels.FindAsync(id);
            if (testModel == null)
            {
                return NotFound();
            }
            return View(testModel);
        }

        // POST: TestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestId,Name")] TestModel testModel)
        {
            if (id != testModel.TestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestModelExists(testModel.TestId))
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
            return View(testModel);
        }

        // GET: TestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModels
                .FirstOrDefaultAsync(m => m.TestId == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // POST: TestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testModel = await _context.TestModels.FindAsync(id);
            _context.TestModels.Remove(testModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestModelExists(int id)
        {
            return _context.TestModels.Any(e => e.TestId == id);
        }
    }
}
