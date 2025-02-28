using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Service;
using ModelLayer.DTO;
namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        UserRegistrationBL _userRegistrationBL;
        ResponseModel<String> response;
        public UserRegistrationController(UserRegistrationBL userRegistrationBL)
        { 
            _userRegistrationBL = userRegistrationBL;
        }

        [HttpGet]
        public string registration()
        {
            //entering username and password
            string username="root";
            string password = "root";
            //Calling registration method of Business Layer to check weather it's valid or invalid
            return _userRegistrationBL.registrationBL(username, password);
        }

        [HttpPost]
        public IActionResult PostData(RegisterDTO register)
        {
            try
            {
                bool result = _userRegistrationBL.RegisterUser(register);
                response = new ResponseModel<String>();
                if (result)
                {
                    response.Success = true;
                    response.Message = "User Registered Sucessfully.";
                    response.Data = register.EMail;
                    return Ok(response);
                }
                response.Success = false;
                response.Message = "Registration Failed.";
                response.Data = "";
                return NotFound(response);
            }
            catch
            {
                response.Success = false;
                response.Message = "";
                response.Data = response.Message;
                return BadRequest(response);
            }
        }

       
    }
}
