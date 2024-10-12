using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface IEnrollmentService
    {
        List<Enrollment> GetAll();
        Enrollment GetById(int id);
        void Add(Enrollment enrollment);
        Enrollment Update(int id, Enrollment updatedEnrollment);
        bool Delete(int id);
    }
}