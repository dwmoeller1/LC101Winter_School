using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LC101Winter_School.Models
{
    public enum StudentType {
        Credit,
        Audit
    }

    public class Student
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public List<Course> Courses { get; set; }
        public int Id { get; set; }
        public StudentType StudentType { get; set; }
    }
}
