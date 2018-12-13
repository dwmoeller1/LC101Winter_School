using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LC101Winter_School.Models;
using LC101Winter_School.ViewModels.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LC101Winter_School.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository courseRepository;
        private IStudentRepository studentRepository;

        public CourseController(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            this.courseRepository = courseRepository;
            this.studentRepository = studentRepository;
        }

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
            Course course = courseRepository.GetCourse(id);
            List<Student> students = studentRepository.GetStudents();
            AddStudentViewModel viewModel = new AddStudentViewModel(course.Subject, course.Instructor, students);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddStudent(int id, AddStudentViewModel viewModel)
        {
            Course course = courseRepository.GetCourse(id);
            Student student = studentRepository.GetStudent(viewModel.StudentId);
            course.AddStudent(student);

            return Redirect("Index");
        }
    }
}