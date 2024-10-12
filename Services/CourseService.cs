using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Services
{
    public class CourseService : ICourseService
    {
        private List<Course> courses = new List<Course>();

        public void Add(Course course)
        {
            course.Id = courses.Count + 1;
            courses.Add(course);
        }

        public bool Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                courses.Remove(course);
                return true;
            }
            return false;
        }

        public List<Course> GetAll()
        {
            return courses;
        }

        public Course GetById(int id)
        {
            Course course = courses.FirstOrDefault(t => t.Id == id);
            if (course == null) return null;

            return course;
        }
        public Course Update(int id, Course updatedCourse)
        {
            var course = GetById(id);
            if (course != null)
            {
                course.IsActive = updatedCourse.IsActive;
                course.TrainerId = updatedCourse.TrainerId;


            }
            return course;

        }
    }
}