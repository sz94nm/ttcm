using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Services
{
    public class TraineeService : ITraineeService
    {
        private List<Trainee> trainees = new List<Trainee>();

        public void Add(Trainee trainee)
        {
            trainee.Id = trainees.Count + 1;
            trainees.Add(trainee);
        }

        public bool Delete(int id)
        {
            var trainee = GetById(id);
            if (trainee != null)
            {
                trainees.Remove(trainee);
                return true;
            }
            return false;
        }

        public List<Trainee> GetAll()
        {
            return trainees;
        }

        public Trainee GetById(int id)
        {
            Trainee trainee = trainees.FirstOrDefault(t => t.Id == id);
            if (trainee == null) return null;

            return trainee;
        }
        public Trainee Update(int id, Trainee updatedTrainee)
        {
            var trainee = GetById(id);
            if (trainee != null)
            {
                trainee.IsGraduated = updatedTrainee.IsGraduated;
                trainee.Email = updatedTrainee.Email;
                trainee.Name = updatedTrainee.Name;
                trainee.Phone = updatedTrainee.Phone;

            }
            return trainee;

        }
    }
}