using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LC101Winter_School.Models
{
    public class Course
    {
        private List<Student> students = new List<Student>();

        public string Subject { get; set; }
        public int Credits { get; set; }
        public int Id { get; set; }
        public string Instructor { get; set; }

        public Course() { }

        public Course(string subject, string instructor, int credits)
        {
            Subject = subject;
            Instructor = instructor;
            Credits = credits;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public List<Student> GetStudents()
        {
            List<Student> cloneList = new List<Student>();
            foreach(Student student in students)
            {
                cloneList.Add(student);
            }

            return cloneList;
        }
    }
}
