using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface ICourseService
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Add(Course course);
        Course Update(int id, Course updatedCourse);
        bool Delete(int id);
    }
}