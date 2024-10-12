using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    // /api/courses
    [Route("api/v1/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        // For Dependency Injection
        // to be fetched from DI containee, auto
        // SHOULD BE ADDED to the containee of DI at program.cs file
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // Read:R
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_courseService.GetAll());
        }


        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            _courseService.Add(course);
            //return Ok(course);// Http 200 => success
            return CreatedAtAction("Create", new { Id = course.Id }, course);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course course)
        {


            var newCourse = _courseService.Update(id, course);
            if (newCourse != null)
            {
                return Ok(newCourse);
            }
            // # if reach this line, this mean no resource found!
            return NotFound("The Course resource not found!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            bool isDone = _courseService.Delete(id);
            if (isDone)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}