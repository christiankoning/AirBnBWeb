using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirbnbWeb.Data;
using AirbnbWeb.ViewModel;
using AirbnbWeb.Model;
using Newtonsoft.Json;

namespace AirbnbWeb.Controllers
{
    public class HousesController : Controller
    {
        private readonly DatabaseContext _context;

        public HousesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Houses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Houses.ToListAsync());
        }

        // GET: Houses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.Houses
                .Include(x => x.Landlord)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }
            HouseViewModel vm = new HouseViewModel
            {
                AllHouses = new SelectList(_context.Houses),
                House = house,
            };
            return View(vm);
        }

        // GET: Houses/Create
        public IActionResult Create()
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: Houses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation, Customer customer)
        {
            if (ModelState.IsValid)
            {
                double totalDays = (reservation.End_date - reservation.Start_date).TotalDays;

                var house = await _context.Houses
                .Include(x => x.Landlord)
                .FirstOrDefaultAsync(m => m.Id == reservation.HouseId);

                Customer newCustomer = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Age = customer.Age,
                    Email = customer.Email,
                    Phonenumber = customer.Phonenumber,
                    Streetname = customer.Streetname,
                    HouseNumber = customer.HouseNumber,
                    City = customer.City,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                };

                _context.Add(newCustomer);

                reservation.Price = house.Price * (float)totalDays;
                reservation.Customer = newCustomer;
                _context.Add(reservation);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Reservations", new {id = reservation.Id.ToString()});
            }
            //ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Id", reservation.HouseId);
            return View(reservation);
        }

        // GET: Houses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HouseName,HouseDescription,HouseType,MaxPerson,Price,BedroomTotal,BedTotal,BathroomTotal,SmokingAllowed,Streetname,HouseNumber,City,PostalCode,Country")] House house)
        {
            if (id != house.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Houses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.Houses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseExists(int id)
        {
            return _context.Houses.Any(e => e.Id == id);
        }
    }
}
