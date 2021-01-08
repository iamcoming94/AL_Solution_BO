using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArcherLogic_Salon_Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService _userService)
        {
            this._userService = _userService;
        }

        // GET: api/<UserController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var item = await _userService.GetUserByIDAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var item = await _userService.GetAllUser();
            return Ok(item);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> AddUser(UserBindingModel entity)
        {
            if (ModelState.IsValid)
            {
                var item = await _userService.AddUser(entity);
                return Ok(item);
            }

            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatUser(int id, UserBindingModel entity)
        {
            if(ModelState.IsValid)
            {
                var item = await _userService.UpdateUser(id, entity);
                return Ok(item);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var item = await _userService.DeleteUser(id);
            return Ok(item);
        }

        [HttpGet("media")]
        public async Task<IActionResult> GetMediaDDL()
        {
            var item = await _userService.LoadMediaDDL();
            return Ok(item);
        }
    }
}
