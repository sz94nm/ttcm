using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_categoryService.GetAll());
        }


        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            _categoryService.Add(category);
            //return Ok(category);// Http 200 => success
            return CreatedAtAction("Create", new { Id = category.Id }, category);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {


            var newCategory = _categoryService.Update(id, category);
            if (newCategory != null)
            {
                return Ok(newCategory);
            }
            // # if reach this line, this mean no resource found!
            return NotFound("The Category resource not found!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            bool isDone = _categoryService.Delete(id);
            if (isDone)
            {
                return Ok();
            }

            return NotFound();
        }


    }
}
