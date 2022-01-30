using Application.Share;
using HotelMgt.Application.Shared;
using HotelMgt.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginService _iVisitorservices;
        public AuthController(ILoginService iVisitorservices)
        {
            _iVisitorservices = iVisitorservices;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationViewModel model)
        {

            if(ModelState.IsValid)
            {
                var result = await _iVisitorservices.RegistrationASync(model);
                if (result.IsSuccessful)
                {

                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Some properties are not Valid" );
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _iVisitorservices.LoginAsync(model);
                if (result.IsSuccessful)
                {

                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Some properties are not Valid");
        }
    }
    

    
}
