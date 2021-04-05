using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using schoolApp.Models;

namespace schoolApp.Controllers
{
    public class MultiController : Controller
    {
        private readonly ConnectionStringClass _mm;

        public MultiController(ConnectionStringClass mm)
        {
            _mm = mm;
        }

        public IActionResult Index()
        {
            List<Student> students = _mm.Students
                                        .Include(s => s.Department)
                                        .ToList();
            return View(students);
        }
    }
}
