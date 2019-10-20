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
    public class UsersController : ControllerBase
    {
        private IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var userModels = _userService
                .GetAll()
                .ToApiModels();
            return Ok(userModels);  //done
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var user = _userService.Get(id).ToApiModel();
            

            if (user == null) return NotFound();
            return Ok(user); //done
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]UserModel newUser)
        {  //done
            try
            {
               
                _userService.Add(newUser.ToDomainModel());
                

            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddUser", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newUser.Id }, newUser);


        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserModel updatedUser)
        {

            var user = _userService.Update(updatedUser.ToDomainModel());
            if (user == null) return NotFound();
            //done
            return Ok(user.ToApiModel());
        }
        
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.Get(id);
            if (user == null) return NotFound();
            _userService.Remove(user);
            return NoContent();
            //done
        }
    }
}
