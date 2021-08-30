using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackGetTalentsV2.Business.User;
using BackGetTalentsV2.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace BackGetTalentsV2.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTOMinimalist userDTO)
        {
            User user = UserHelper.ConvertUserDTO(userDTO);

            _userService.AddUser(user);

            return Created(nameof(CreateUser), user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            IList<User> users = _userService.GetAllUsers();

            List<UserDTO> usersDTO = UserHelper.ConvertUsers(users.ToList());

            return Ok(usersDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            try
            {
                User user = _userService.GetUserById(id);

                UserDTO userDTO = UserHelper.ConvertUser(user);

                return Ok(userDTO);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            try
            {
                _userService.DeleteUser(id);

                return NoContent();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserDTOMinimalist userDTO)
        {
            try
            {
                User user = UserHelper.ConvertUserDTO(userDTO);

                _userService.UpdateUser(id, user);

                return NoContent();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }
}