using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramiaMVC.Data;
using ProgramiaMVC.Models;
using System.Threading.Tasks;

namespace ProgramiaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /home/index
        public async Task<IActionResult> Index()
        {
            var produkty = await _context.Produkty.ToListAsync();
            return View(produkty); // Pøedá model do pohledu
        }

        // GET: /home/produkty/create
        public IActionResult CreateProdukt()
        {
            return View("Produkty/Create");
        }

        // POST: /home/produkty/create
        [HttpPost]
        public async Task<IActionResult> CreateProdukt(Produkt produkt)
        {
            if (ModelState.IsValid) // validace vrací modelstate true
            {   
                _context.Produkty.Add(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Pøesmìrování na hlavní stránku
            }

            return View("Produkty/Create", produkt);
        }

        // GET: /home/produkty/edit/{id}
        public async Task<IActionResult> EditProdukt(int id)
        {
            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            return View(produkt);
        }

        // POST: /home/produkty/edit/{id}
        [HttpPost]
        public async Task<IActionResult> EditProdukt(int id, Produkt produkt)
        {
            if (id != produkt.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(produkt).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produkt);
        }

        // GET: /home/produkty/delete/{id}
        public async Task<IActionResult> DeleteProdukt(int id)
        {
            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            return View("Produkty/Delete", produkt);
        }

        // POST: /home/produkty/delete/{id}
        [HttpPost, ActionName("DeleteProdukt")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produkt = await _context.Produkty.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }

            _context.Produkty.Remove(produkt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
