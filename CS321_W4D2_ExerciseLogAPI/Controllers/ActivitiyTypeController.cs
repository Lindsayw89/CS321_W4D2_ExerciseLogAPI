using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CS321_W4D2_ExerciseLogAPI.ApiModels;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiyTypeController : ControllerBase
    {
        private readonly IActivityTypeService _activityTypeService;


        public ActivitiyTypeController(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService;
        }

            // GET: api/<controller>
            [HttpGet]
            public IActionResult Get()
        {
            var activityTypeModels = _activityTypeService.GetAll()

           .ToApiModels();

            return Ok(activityTypeModels);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var activityType = _activityTypeService.Get(id).ToApiModel();
            

            if (activityType == null) return NotFound();
            return Ok(activityType);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ActivityTypeModel newActivityType)
        {
            try {
            _activityTypeService.Add(newActivityType.ToDomainModel());
            

        }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddActivityType", ex.GetBaseException().Message);
                return BadRequest(ModelState);
    }

            return CreatedAtAction("Get", new { Id = newActivityType.Id}, newActivityType);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ActivityTypeModel updatedActivityType)
        {

            var activityType = _activityTypeService.Update(updatedActivityType.ToDomainModel());
            if (activityType == null) return NotFound();
            //UNSURE
            return Ok(activityType.ToApiModel());
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var activityType = _activityTypeService.Get(id);
            if (activityType == null) return NotFound();
            _activityTypeService.Remove(activityType);
            return NoContent();

        }
    }
}

