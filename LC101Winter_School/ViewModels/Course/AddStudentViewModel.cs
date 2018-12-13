using LC101Winter_School.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LC101Winter_School.ViewModels.Course
{
    public class AddStudentViewModel
    {
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public List<Student> Students { get; set; }
        public StudentType StudentType { get; set; }

        public List<SelectListItem> StudentTypes { get; set; }

        [Required]
        public int StudentId { get; set; }

        public AddStudentViewModel() {
            StudentTypes = new List<SelectListItem>();
        }

        public AddStudentViewModel(string courseName, string instructorName, List<Student> students)
        {
            StudentTypes = new List<SelectListItem>();
            CourseName = courseName;
            InstructorName = instructorName;
            Students = students;
            foreach (StudentType type in Enum.GetValues(typeof(StudentType)))
                StudentTypes.Add(new SelectListItem(type.ToString(), ((int)type).ToString()));
        }
    }
}
