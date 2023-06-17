using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Entities;
using UsuarioAPI.Services;

namespace UsuarioAPI.Controllers
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


        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }


        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {

            var user = _userService.GetById(id);

            if (user == null) 
            { 
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Users user)
        {
            _userService.Insert(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id, Users user)
        {
            var users = _userService.GetById(id);

            if (users == null)
                return NotFound();

            _userService.Update(id, user);

            return Ok(user);

        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var users = _userService.GetById(id);

            if (users == null)
                return NotFound();

            _userService.Delete(id);

            return Ok("Usuario com o " + id + " Deletado com sucesso!");

        }

    }
}
