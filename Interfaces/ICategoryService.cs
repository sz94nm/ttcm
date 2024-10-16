using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        Category Update(int id, Category updatedCategory);
        bool Delete(int id);
    }
}