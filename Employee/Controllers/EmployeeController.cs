using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Employee.Data;
using Employee.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployeeRepository _repository;

        public EmployeeController(ApplicationDbContext db,IEmployeeRepository repository)
        {
            _context = db;
            _repository = repository;

        }
        public IActionResult Index()
        {
            //IEnumerable<Models.Employee> objList = _context.Employee;
            IEnumerable<Models.Employee> objList = _repository.GetAllEmployees();
            return View(objList);
        }

        public IActionResult GetEmployees()
        {
            return Ok(_repository.GetAllEmployees());
        }
        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Employee obj)
        {
            if (!ModelState.IsValid)
                return View(obj);
            
            _context.Employee.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - Edit
        public IActionResult Edit(Guid id)
        {
            var obj = _context.Employee.SingleOrDefault(x => x.Id == id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }
        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Employee obj)
        {
            if (!ModelState.IsValid)
                return View(obj);

            _context.Employee.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - Edit
        public IActionResult Delete(Guid id)
        {
            var obj = _context.Employee.SingleOrDefault(x => x.Id == id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }
        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Models.Employee obj)
        {
            if (obj == null)
                return NotFound();
            _context.Employee.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
