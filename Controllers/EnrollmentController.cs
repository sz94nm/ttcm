using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Controllers
{
    [ApiController]
    [Route("api/v1/enrollments")]
    public class EnrollmentController : ControllerBase
    {
        // For Dependency Injection
        // to be fetched from DI containee, auto
        // SHOULD BE ADDED to the containee of DI at program.cs file
        private IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // Read:R
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_enrollmentService.GetAll());
        }


        [HttpPost]
        public IActionResult Create([FromBody] Enrollment enrollment)
        {
            _enrollmentService.Add(enrollment);
            //return Ok(enrollment);// Http 200 => success
            return CreatedAtAction("Create", new { Id = enrollment.Id }, enrollment);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Enrollment enrollment)
        {


            var newEnrollment = _enrollmentService.Update(id, enrollment);
            if (newEnrollment != null)
            {
                return Ok(newEnrollment);
            }
            // # if reach this line, this mean no resource found!
            return NotFound("The Enrollment resource not found!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            bool isDone = _enrollmentService.Delete(id);
            if (isDone)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}