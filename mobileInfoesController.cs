using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mobileInfo_Assignment03.Data;
using mobileInfo_Assignment03.Models;

namespace mobileInfo_Assignment03
{
    public class mobileInfoesController : Controller
    {
        private readonly mobileInfo_Assignment03Context _context;

        public mobileInfoesController(mobileInfo_Assignment03Context context)
        {
            _context = context;
        }

        // GET: mobileInfoes
        public async Task<IActionResult> Index()
        {
              return _context.mobileInfo != null ? 
                          View(await _context.mobileInfo.ToListAsync()) :
                          Problem("Entity set 'mobileInfo_Assignment03Context.mobileInfo'  is null.");
        }

        // GET: mobileInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.mobileInfo == null)
            {
                return NotFound();
            }

            var mobileInfo = await _context.mobileInfo
                .FirstOrDefaultAsync(m => m.mobileId == id);
            if (mobileInfo == null)
            {
                return NotFound();
            }

            return View(mobileInfo);
        }

        // GET: mobileInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: mobileInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mobileId,mobileModel,mobileCompany,manufacturedYear,mobileStorage,mobileColour")] mobileInfo mobileInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobileInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobileInfo);
        }

        // GET: mobileInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.mobileInfo == null)
            {
                return NotFound();
            }

            var mobileInfo = await _context.mobileInfo.FindAsync(id);
            if (mobileInfo == null)
            {
                return NotFound();
            }
            return View(mobileInfo);
        }

        // POST: mobileInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mobileId,mobileModel,mobileCompany,manufacturedYear,mobileStorage,mobileColour")] mobileInfo mobileInfo)
        {
            if (id != mobileInfo.mobileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobileInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mobileInfoExists(mobileInfo.mobileId))
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
            return View(mobileInfo);
        }

        // GET: mobileInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.mobileInfo == null)
            {
                return NotFound();
            }

            var mobileInfo = await _context.mobileInfo
                .FirstOrDefaultAsync(m => m.mobileId == id);
            if (mobileInfo == null)
            {
                return NotFound();
            }

            return View(mobileInfo);
        }

        // POST: mobileInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.mobileInfo == null)
            {
                return Problem("Entity set 'mobileInfo_Assignment03Context.mobileInfo'  is null.");
            }
            var mobileInfo = await _context.mobileInfo.FindAsync(id);
            if (mobileInfo != null)
            {
                _context.mobileInfo.Remove(mobileInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mobileInfoExists(int id)
        {
          return (_context.mobileInfo?.Any(e => e.mobileId == id)).GetValueOrDefault();
        }
    }
}
