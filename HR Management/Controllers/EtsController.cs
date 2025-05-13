using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR_Management.Models;

namespace HR_Management.Controllers
{
    public class EtsController : Controller
    {
        private readonly HrdbContext _context;

        public EtsController(HrdbContext context)
        {
            _context = context;
        }

        // GET: Ets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ets.ToListAsync());
        }

        // GET: Ets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var et = await _context.Ets
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (et == null)
            {
                return NotFound();
            }

            return View(et);
        }

        // GET: Ets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Department,Salary")] Et et)
        {
            if (ModelState.IsValid)
            {
                _context.Add(et);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(et);
        }

        // GET: Ets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var et = await _context.Ets.FindAsync(id);
            if (et == null)
            {
                return NotFound();
            }
            return View(et);
        }

        // POST: Ets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Department,Salary")] Et et)
        {
            if (id != et.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(et);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtExists(et.EmployeeId))
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
            return View(et);
        }

        // GET: Ets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var et = await _context.Ets
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (et == null)
            {
                return NotFound();
            }

            return View(et);
        }

        // POST: Ets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var et = await _context.Ets.FindAsync(id);
            if (et != null)
            {
                _context.Ets.Remove(et);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtExists(int id)
        {
            return _context.Ets.Any(e => e.EmployeeId == id);
        }
    }
}
