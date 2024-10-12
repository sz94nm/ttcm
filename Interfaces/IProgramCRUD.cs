using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface IProgramCRUD
    {
        public IEnumerable<ttcm_api.Models.Program> GetAll();
        public ttcm_api.Models.Program Create(ttcm_api.Models.Program p);
        public ttcm_api.Models.Program Update(int id, ttcm_api.Models.Program newProgram);
        public bool Delete(int id);


    }
}
