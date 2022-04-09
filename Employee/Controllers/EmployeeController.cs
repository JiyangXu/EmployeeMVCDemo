using System.Collections;
using System.Collections.Generic;
using Employee.Data;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext db)
        {
            _context = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Models.Employee> objList = _context.Employee;
            return View(objList);
        }
    }
}
