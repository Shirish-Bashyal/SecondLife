using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondLife.DTO;
using SecondLife.Interfaces;
using SecondLife.Models;

namespace SecondLife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        public IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        [Authorize]

        public IActionResult AddUserDetails(UserDetailsDTO user )
        {

            var result=_user.AddUserDetailsAsync(user).Result;


            return Ok(result);
        }








    }
}
