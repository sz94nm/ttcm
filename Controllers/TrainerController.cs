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
    [Route("api/v1/trainers")]
    public class TrainerController : ControllerBase

    {
        // For Dependency Injection
        // to be fetched from DI container, auto
        // SHOULD BE ADDED to the container of DI at program.cs file
        private ITrainerService _trainerService;
        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        // Read:R
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_trainerService.GetAll());
        }


        [HttpPost]
        public IActionResult Create([FromBody] Trainer trainer)
        {
            _trainerService.Add(trainer);
            //return Ok(trainer);// Http 200 => success
            return CreatedAtAction("Create", new { Id = trainer.Id }, trainer);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Trainer trainer)
        {


            var newTrainer = _trainerService.Update(id, trainer);
            if (newTrainer != null)
            {
                return Ok(newTrainer);
            }
            // # if reach this line, this mean no resource found!
            return NotFound("The Trainer resource not found!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            bool isDone = _trainerService.Delete(id);
            if (isDone)
            {
                return Ok();
            }

            return NotFound();
        }


    }
}