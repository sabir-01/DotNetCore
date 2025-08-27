using CodeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDB;

        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }

        //show all rrecords
        public async Task<IActionResult> Index()
        {
            var data = await studentDB.Students.ToListAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDB.Students.AddAsync(std);
                await studentDB.SaveChangesAsync();
                TempData["msginsert"] = "Record Added Successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        // GET: these both edit methods are for editing the record
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var data = await studentDB.Students.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentDB.Students.Update(std);
                await studentDB.SaveChangesAsync();
                TempData["msgupdate"] = "Record Updated Successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        // GET: these both delete methods are for deleting the record
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var data = await studentDB.Students.FirstOrDefaultAsync(x => x.Id ==
           id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var data = await studentDB.Students.FindAsync(id);
            if (data != null)
            {
                studentDB.Students.Remove(data);
                await studentDB.SaveChangesAsync();
                TempData["msgdelete"] = "Record Deleted Successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var data = await studentDB.Students.FirstOrDefaultAsync(x => x.Id ==
           id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

    }
}
