using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using schoolApp.Models;

namespace schoolApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ConnectionStringClass _bb;
        public DepartmentController(ConnectionStringClass bb)
        {
            _bb = bb;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<Department> departments = _bb.Departments.ToList();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if(ModelState.IsValid)
            {
                _bb.Departments.Add(dept);
                int n = _bb.SaveChanges();
                if (n > 0)
                    return RedirectToAction("Index");
                else
                    return NotFound(); 
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();
            Department dept = _bb.Departments.Find(id);

            if (dept == null)
                return NotFound();
            return View(dept);
        }
        [HttpPost]
        public IActionResult Update(Department details)
        {
            if(ModelState.IsValid)
            {
                _bb.Entry(details).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                int a = _bb.SaveChanges();
                if (a > 0)
                    return RedirectToAction("Index");
                return NotFound();
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Department a = _bb.Departments.Find(id);
            if (a == null)
                return NotFound();
            _bb.Departments.Remove(a);
            int n = _bb.SaveChanges();
            if (n > 0)
                return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
