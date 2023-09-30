using IdentityModel.OidcClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondLife.DTO;
using SecondLife.Helper;
using SIgnin_Manager.Interface;

namespace SecondLife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class Authenticate : ControllerBase
    {
        private IUserInterface _userInterface;

       // private IConfiguration _configuration;
        private readonly JwtValidateAndDeserialize _jwt;
        public Authenticate(IUserInterface userService,  JwtValidateAndDeserialize jwt)
        {

            _userInterface = userService;

           
            _jwt = jwt;

        }

        [HttpPost]
        public IActionResult Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {

                //if(model.Password!=model.ConfirmPassword)
                //{
                //    ViewBag.Message = "Password and ConfirmPassword Doesnot match";
                //    return View(model);
                //}




                var result = _userInterface.RegisterUserAsync(model).Result;//.result returns the response of the function
                // RedirectToAction(SiginIn);
                if (result.IsSuccess == true)
                {

                    //ViewBag.Message=result.Message;
                    return Ok();
                   
                    
                }
                return BadRequest();

                // ViewBag.Message = result.Message;

            }

            return BadRequest();


        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(SigninDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userInterface.SignInUserAsync(model);



                return Ok(result);
            }

            return BadRequest("Some properties are not valid");
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult GetMyDetails()
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString();

            // The token comes with the "Bearer " prefix, so we need to remove it
            if (token.StartsWith("Bearer "))
            {
                token = token.Substring("Bearer ".Length);
            }
            var user = _jwt.ValidateAndDeseerialize(token);


            var result=_userInterface.




            return Ok();
        }

       







    }
}
