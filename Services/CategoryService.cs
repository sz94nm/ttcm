using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ttcm_api.Models;

namespace ttcm_api.Services
{
    public class CategoryService
    {
        private List<Category> categorys = new List<Category>();

        public void Add(Category category)
        {
            category.Id = categorys.Count + 1;
            categorys.Add(category);
        }

        public bool Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                categorys.Remove(category);
                return true;
            }
            return false;
        }

        public List<Category> GetAll()
        {
            return categorys;
        }

        public Category GetById(int id)
        {
            Category category = categorys.FirstOrDefault(t => t.Id == id);
            if (category == null) return null;

            return category;
        }
        public Category Update(int id, Category updatedCategory)
        {
            var category = GetById(id);
            if (category != null)
            {
                category.Name = updatedCategory.Name;



            }
            return category;

        }
    }
}