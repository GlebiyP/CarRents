using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRents.Models;

namespace CarRents.Controllers
{
    public class CarRentsController : Controller
    {
        private readonly CarRentsContext _context;

        public CarRentsController(CarRentsContext context)
        {
            _context = context;
        }

        // GET: CarRents
        public async Task<IActionResult> Index()
        {
            var carRentsContext = _context.CarRents.Include(c => c.Car).Include(c => c.Company).Include(c => c.Renter).Include(c => c.Car.Brand);
            return View(await carRentsContext.ToListAsync());
        }

        public async Task<IActionResult> IndexByCompany(int? id, string? name, double? rating)
        {
            if (id == null) return RedirectToAction("Companies", "Index");
            ViewBag.CompanyID = id;
            ViewBag.CompanyName = name;
            ViewBag.Rating = rating;
            var carRentsByCompany = _context.CarRents.Where(cr => cr.CompanyID == id).Include(cr => cr.Company).Include(cr => cr.Car).Include(cr => cr.Renter).Include(cr => cr.Car.Brand);

            return View(await carRentsByCompany.ToListAsync());
        }

        public async Task<IActionResult> IndexByRenter(int? id, string? name, string? city, string? email)
        {
            if (id == null) return RedirectToAction("Renters", "Index");
            ViewBag.RenterID = id;
            ViewBag.RenterName = name;
            ViewBag.City = city;
            ViewBag.Email = email;
            var carRentsByRenter = _context.CarRents.Where(cr => cr.RenterID == id).Include(cr => cr.Renter).Include(cr => cr.Car).Include(cr => cr.Company).Include(cr => cr.Car.Brand);

            return View(await carRentsByRenter.ToListAsync());
        }

        // GET: CarRents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRent = await _context.CarRents
                .Include(c => c.Car)
                .Include(c => c.Company)
                .Include(c => c.Renter)
                .Include(c => c.Car.Brand)
                .FirstOrDefaultAsync(m => m.CarRentID == id);
            if (carRent == null)
            {
                return NotFound();
            }

            return View(carRent);
        }

        // GET: CarRents/Create
        public IActionResult Create()
        {
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "Model");
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName");
            ViewData["RenterID"] = new SelectList(_context.Renters, "RenterID", "RenterName");
            return View();
        }

        // POST: CarRents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarRentID,RenterID,CarID,CompanyID,RentalDays")] CarRent carRent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carRent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "Model", carRent.CarID);
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName", carRent.CompanyID);
            ViewData["RenterID"] = new SelectList(_context.Renters, "RenterID", "RenterName", carRent.RenterID);
            return View(carRent);
        }

        // GET: CarRents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRent = await _context.CarRents.FindAsync(id);
            if (carRent == null)
            {
                return NotFound();
            }
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "Model", carRent.CarID);
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName", carRent.CompanyID);
            ViewData["RenterID"] = new SelectList(_context.Renters, "RenterID", "RenterName", carRent.RenterID);
            return View(carRent);
        }

        // POST: CarRents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarRentID,RenterID,CarID,CompanyID,RentalDays")] CarRent carRent)
        {
            if (id != carRent.CarRentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carRent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarRentExists(carRent.CarRentID))
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
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "Model", carRent.CarID);
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName", carRent.CompanyID);
            ViewData["RenterID"] = new SelectList(_context.Renters, "RenterID", "RenterName", carRent.RenterID);
            return View(carRent);
        }

        // GET: CarRents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRent = await _context.CarRents
                .Include(c => c.Car)
                .Include(c => c.Company)
                .Include(c => c.Renter)
                .Include(c => c.Car.Brand)
                .FirstOrDefaultAsync(m => m.CarRentID == id);
            if (carRent == null)
            {
                return NotFound();
            }

            return View(carRent);
        }

        // POST: CarRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carRent = await _context.CarRents.FindAsync(id);
            _context.CarRents.Remove(carRent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarRentExists(int id)
        {
            return _context.CarRents.Any(e => e.CarRentID == id);
        }
    }
}
