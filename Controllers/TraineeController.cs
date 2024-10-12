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
    [Route("api/v1/trainees")]
    public class TraineeController : ControllerBase

    {
        // For Dependency Injection
        // to be fetched from DI containee, auto
        // SHOULD BE ADDED to the containee of DI at program.cs file
        private ITraineeService _traineeService;
        public TraineeController(ITraineeService traineeService)
        {
            _traineeService = traineeService;
        }

        // Read:R
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_traineeService.GetAll());
        }


        [HttpPost]
        public IActionResult Create([FromBody] Trainee trainee)
        {
            _traineeService.Add(trainee);
            //return Ok(trainee);// Http 200 => success
            return CreatedAtAction("Create", new { Id = trainee.Id }, trainee);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Trainee trainee)
        {


            var newTrainee = _traineeService.Update(id, trainee);
            if (newTrainee != null)
            {
                return Ok(newTrainee);
            }
            // # if reach this line, this mean no resource found!
            return NotFound("The Trainee resource not found!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            bool isDone = _traineeService.Delete(id);
            if (isDone)
            {
                return Ok();
            }

            return NotFound();
        }


    }
}