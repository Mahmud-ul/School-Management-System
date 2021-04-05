using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using schoolApp.Models;
namespace schoolApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ConnectionStringClass _sd;

        public StudentController (ConnectionStringClass sd)
        {
            _sd = sd;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<Student> stud = _sd.Students.ToList();
            return View(stud);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student stud)
        {
            if (ModelState.IsValid)
            {
                if (stud == null)
                    return NotFound();
                _sd.Students.Add(stud);
                int n = _sd.SaveChanges();
                if (n > 0)
                    return RedirectToAction("Index");
                else
                    return BadRequest();
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Student ss = _sd.Students.Find(id);
            _sd.Students.Remove(ss);
            int a = _sd.SaveChanges();
            if (a > 0)
                return RedirectToAction("index");
            else
                return BadRequest();
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();
            Student x = _sd.Students.Find(id);
            if (x == null)
                return NotFound();
            return View(x);
        }
        [HttpPost]
        public IActionResult Update(Student std)
        {
            if (ModelState.IsValid)
            {
                _sd.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                int n = _sd.SaveChanges();
                if (n > 0)
                    return RedirectToAction("Index");
                return NotFound();
            }
            return BadRequest(); 
        }
    }
}
