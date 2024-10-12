using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface ITrainerService
    {
        List<Trainer> GetAll();
        Trainer GetById(int id);
        void Add(Trainer trainer);
        Trainer Update(int id, Trainer updatedTrainer);
        bool Delete(int id);
    }
}