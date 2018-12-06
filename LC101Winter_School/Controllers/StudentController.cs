using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LC101Winter_School.Models;
using Microsoft.AspNetCore.Mvc;

namespace LC101Winter_School.Controllers
{
    public class StudentController : Controller
    {
        public static IStudentRepository studentRepository = new StudentRepository();

        public IActionResult Index()
        {
            List<Student> students = studentRepository.GetStudents();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student model)
        {
            studentRepository.Add(model);
            return Redirect("Index");
        }
    }
}