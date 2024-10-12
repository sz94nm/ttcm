using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface ITraineeService
    {
        List<Trainee> GetAll();
        Trainee GetById(int id);
        void Add(Trainee trainee);
        Trainee Update(int id, Trainee updatedTrainee);
        bool Delete(int id);
    }
}