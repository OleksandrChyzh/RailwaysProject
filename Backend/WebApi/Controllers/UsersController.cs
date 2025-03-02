using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Services;
using BusinessLogic.Validation;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            return Ok(await _userService.GetAllAsync());
        }

        //GET: api/users/email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserModel>> GetByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmail(email);
                return Ok(user);
            }
            catch (RailwaysException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserModel value)
        {
            try
            {
                await _userService.AddAsync(value);
                return Ok(value); 
            }
            catch (RailwaysException ex) 
            {
                return BadRequest(ex.Message); 
            }
        }

        // PUT: api/users/{email}
        [HttpPut("{email}")]
        public async Task<ActionResult> Update(string email, [FromBody] UserModel model)
        {
            try
            {
                model.Email = email;
                await _userService.UpdateAsync(model);
                return NoContent();
            }
            catch (RailwaysException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/users/{email}
        [HttpDelete("{email}")]
        public async Task<ActionResult> Delete(string email)
        {            
            try
            {
                await _userService.DeleteAsync(email);
                return Ok();

            }
            catch (RailwaysException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
