using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.DTOs;
using ProductManagement.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductManagement.Controllers.V3
{
    [ApiController]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [SwaggerTag("Authentication Operations")]
    public class AuthController : ControllerBase
    {
        private readonly IProductService service;
        private readonly IAuthService authService;
        private readonly IJwtService jwtService;

        public AuthController(IProductService service,IAuthService authService, IJwtService jwtService)
        {
            this.service = service;
            this.authService = authService;
            this.jwtService = jwtService;
        }


        [HttpPost("register")]
        public IActionResult Register(UserRegistrationRequestDTO dto)
        {
            authService.Register(dto);

            return Ok("User Registered Successfully");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestDTO dto)
        {
            var user = authService.Login(dto);

            var token = jwtService.GenerateToken(user);

            return Ok(new
            {
                Token = token
            });
        }

    }
}