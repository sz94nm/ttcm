using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Services
{
    public class TrainerService : ITrainerService
    {
        private List<Trainer> trainers = new List<Trainer>();

        public void Add(Trainer trainer)
        {
            trainer.Id = trainers.Count + 1;
            trainers.Add(trainer);
        }

        public bool Delete(int id)
        {
            var trainer = GetById(id);
            if (trainer != null)
            {
                trainers.Remove(trainer);
                return true;
            }
            return false;
        }

        public List<Trainer> GetAll()
        {
            return trainers;
        }

        public Trainer GetById(int id)
        {
            Trainer trainer = trainers.FirstOrDefault(t => t.Id == id);
            if (trainer == null) return null;

            return trainer;
        }
        public Trainer Update(int id, Trainer updatedTrainer)
        {
            var trainer = GetById(id);
            if (trainer != null)
            {
                trainer.Name = updatedTrainer.Name;
                trainer.Specialization = updatedTrainer.Specialization;
                trainer.Salary = updatedTrainer.Salary;

            }
            return trainer;

        }
    }
}