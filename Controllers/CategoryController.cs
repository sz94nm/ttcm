using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Models;

namespace ttcm_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> Categories = new List<Category>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Categories);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category) { 
            
            Categories.Add(category);

            return Ok("Catrgory Added Successfully");
        }


    }
}
