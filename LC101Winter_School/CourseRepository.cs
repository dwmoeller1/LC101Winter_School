using LC101Winter_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LC101Winter_School
{
    public class CourseRepository : ICourseRepository
    {
        private List<Course> courses = new List<Course>();
        private int currentId = 1;

        public void Add(Course course)
        {
            if (course.Id == 0)
            {
                course.Id = currentId++;
            }
            Delete(course.Id);
            courses.Add(course);
        }

        public void Delete(int courseId)
        {
            courses.RemoveAll(student => student.Id == courseId);
        }

        public Course GetCourse(int courseId)
        {
            return courses.Where(course => course.Id == courseId).SingleOrDefault();
        }

        public List<Course> GetCourses()
        {
            List<Course> clonedList = new List<Course>(courses);
            return clonedList;
        }
    }
}
