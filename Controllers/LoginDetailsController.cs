using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeMVC.Controllers
{
    [Authorize]
    public class LoginDetailsController : Controller
    {
        private readonly LoginDetailsContext _context = new LoginDetailsContext();



        // GET: LoginDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoginDetails.ToListAsync());
        }

        // GET: LoginDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginDetails = await _context.LoginDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginDetails == null)
            {
                return NotFound();
            }

            return View(loginDetails);
        }

        // GET: LoginDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,AccessLevel,UserId")] LoginDetails loginDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginDetails);
        }

        // GET: LoginDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginDetails = await _context.LoginDetails.FindAsync(id);
            if (loginDetails == null)
            {
                return NotFound();
            }
            return View(loginDetails);
        }

        // POST: LoginDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,AccessLevel,UserId")] LoginDetails loginDetails)
        {
            if (id != loginDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginDetailsExists(loginDetails.Id))
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
            return View(loginDetails);
        }

        // GET: LoginDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginDetails = await _context.LoginDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginDetails == null)
            {
                return NotFound();
            }

            return View(loginDetails);
        }

        // POST: LoginDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginDetails = await _context.LoginDetails.FindAsync(id);
            _context.LoginDetails.Remove(loginDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginDetailsExists(int id)
        {
            return _context.LoginDetails.Any(e => e.Id == id);
        }
    }
}
