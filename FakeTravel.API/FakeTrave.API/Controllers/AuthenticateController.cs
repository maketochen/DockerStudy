using FakeTrave.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FakeTrave.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthenticateController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            //1.验证用户名和密码

            //2.创建jwt
            //header
            var signingAlgoithm = SecurityAlgorithms.HmacSha256;
            //payload
            var claims = new[]
            {
                //sub 
                new Claim(JwtRegisteredClaimNames.Sub,"fake_user_id")
            };
            //signiture ☆☆key至少要16个字符
            var sercretByte = Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]);
            var signingKey = new SymmetricSecurityKey(sercretByte);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgoithm);

            var token = new JwtSecurityToken(
                issuer: configuration["Authentication:Issuer"],
                audience: configuration["Authentication:Audience"],
                claims,
                notBefore:DateTime.UtcNow,
                expires:DateTime.UtcNow.AddDays(1),
                signingCredentials
                );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            //3.return 200 ok +jwt

            return Ok(tokenStr);
        }

    }
}
