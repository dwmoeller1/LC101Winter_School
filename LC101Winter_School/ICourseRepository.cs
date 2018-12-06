using LC101Winter_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LC101Winter_School
{
    interface ICourseRepository
    {
        void Add(Course course);
        void Delete(int courseId);
        List<Course> GetCourses();
        Course GetCourse(int courseId);
    }
}
