using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LC101Winter_School.Models;

namespace LC101Winter_School
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();
        private int currentId = 1;

        public void Add(Student student)
        {
            if(student.Id == 0)
            {
                student.Id = currentId++;
            }
            Delete(student.Id);
            students.Add(student);
        }

        public void Delete(int studentId)
        {
            students.RemoveAll(student => student.Id == studentId);
        }

        public Student GetStudent(int studentId)
        { 
            return students.Where(student => student.Id == studentId).SingleOrDefault();
        }

        public List<Student> GetStudents()
        {
            List<Student> clonedList = new List<Student>(students);
            return clonedList;
        }
    }
}
