using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private List<Enrollment> enrollments = new List<Enrollment>();

        public void Add(Enrollment enrollment)
        {
            enrollment.Id = enrollments.Count + 1;
            enrollments.Add(enrollment);
        }

        public bool Delete(int id)
        {
            var enrollment = GetById(id);
            if (enrollment != null)
            {
                enrollments.Remove(enrollment);
                return true;
            }
            return false;
        }

        public List<Enrollment> GetAll()
        {
            return enrollments;
        }

        public Enrollment GetById(int id)
        {
            Enrollment enrollment = enrollments.FirstOrDefault(t => t.Id == id);
            if (enrollment == null) return null;

            return enrollment;
        }
        public Enrollment Update(int id, Enrollment updatedEnrollment)
        {
            var enrollment = GetById(id);
            if (enrollment != null)
            {
                enrollment.EnrollmentDate = updatedEnrollment.EnrollmentDate;
                enrollment.Price = updatedEnrollment.Price;


            }
            return enrollment;

        }
    }
}