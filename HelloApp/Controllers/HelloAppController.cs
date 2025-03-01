using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Service;
using ModelLayer.DTO;
using BusinessLayer.Interface;

namespace HelloApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloAppController : ControllerBase
    {
        private readonly IRegisterHelloBL _registerHelloBL;
        ResponseModel <string>response;
        public HelloAppController(IRegisterHelloBL registerHello)
        {
            _registerHelloBL = registerHello;
        }

        [HttpGet]

        public string Get()
        {
            return _registerHelloBL.registration("value from controller");
        }
        [HttpPost]
        public IActionResult LoginUser(LoginDTO loginDTO) {
            {
                try
                {
                    response = new ResponseModel<string>();
                    bool result = _registerHelloBL.LoginUser(loginDTO);
                    if (result)
                    {
                        response.success = true;
                        response.message = "Data received successfully";
                        response.data = loginDTO.username;
                        return Ok();
                    }
                    else
                    {
                        response.success = false;
                        response.message = "Login unsuccessfull";
                        response.data = loginDTO.password;
                        return NotFound();
                    }
                }
                catch (Exception ex) 
                {
                    response.success = false;
                    response.message = "Login failed";
                    response.data=ex.Message;
                    return BadRequest();
                }
            }
        }
    }
}