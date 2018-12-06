using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LC101Winter_School.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LC101Winter_School.Controllers
{
    public class CourseController : Controller
    {
        private static ICourseRepository courseRepository = new CourseRepository(); 

        public ActionResult Index()
        {
            List<Course> courses = courseRepository.GetCourses();
            return View(courses);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course model)
        {
            courseRepository.Add(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(List<int> itemsToDelete)
        {
            foreach (int id in itemsToDelete)
                courseRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddStudent(int id)
        {
            ViewBag.course = courseRepository.GetCourse(id);
            ViewBag.students = StudentController.studentRepository.GetStudents();
 
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(int id, int studentId)
        {
            Course course = courseRepository.GetCourse(id);
            Student student = StudentController.studentRepository.GetStudent(studentId);
            course.AddStudent(student);

            return Redirect("Index");
        }
    }
}