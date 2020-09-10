using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PINprojekt_Ivan_Latkovic.Models;

namespace PINprojekt_Ivan_Latkovic.Controllers
{
    public class KnjigaController : Controller
    {
        private readonly DbKontekst _db;
        [BindProperty]
        public Knjiga Knjiga { get; set; }
        public KnjigaController(DbKontekst db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Knjiga = new Knjiga();
            if(id==null)
            {
                //kreiranje
                return View(Knjiga);
            }
            //update-nje
            Knjiga = _db.Knjiga.FirstOrDefault(u => u.Id == id);
            if(Knjiga==null)
            {
                return NotFound();
            }
            return View(Knjiga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if(ModelState.IsValid)
            {
                if(Knjiga.Id == 0)
                {
                    //Kreiranje
                    _db.Knjiga.Add(Knjiga);
                }
                else
                {
                    _db.Knjiga.Update(Knjiga);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Knjiga);
        }

        #region API pozivi
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Knjiga.ToListAsync() });

        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var knjigaFromDb = await _db.Knjiga.FirstOrDefaultAsync(u => u.Id == id);
            if(knjigaFromDb==null)
            {
                return Json(new { success = false, message = "Greška prilikom brisanja" });
            }
            _db.Knjiga.Remove(knjigaFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Brisanje uspješno" });
        }
        #endregion
    }
}
