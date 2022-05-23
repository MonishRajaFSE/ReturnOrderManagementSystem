using ComponentProcessingMicroservice.Interface;
using ComponentProcessingMicroservice.Model;
using ComponentProcessingMicroservice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComponentProcessingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IConfiguration _configuration;
        private readonly LoginService _loginService;
        public AuthenticationController(IConfiguration configuration, IAuthentication iAuthentication, ILogger<AuthenticationController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _loginService = new LoginService(iAuthentication);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authentication([FromBody] LoginModel login)
        {
            try
            {
                if (login.Email != "" && login.Email != null && _loginService.ValidateUser(login.Email, login.Password))
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, login.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };


                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );
                    _logger.LogInformation($"Login - User Authentication Success");
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                _logger.LogWarning("Login - Unauthorized User");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error - {ex}");
                return Unauthorized();
            }
        }
    }
}
