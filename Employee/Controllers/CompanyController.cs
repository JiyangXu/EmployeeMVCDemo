using System.Collections.Generic;
using Employee.Data;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext db)
        {
            _context = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Models.Company> objList = _context.Company;
            return View(objList);
           
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Company obj)
        {
            _context.Company.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
