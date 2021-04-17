﻿using FakeTrave.API.Dtos;
using FakeTrave.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthenticateController(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            //1.验证用户名和密码
            var loginResult = await signInManager.PasswordSignInAsync(
                loginDto.Email,
                loginDto.Password,
                false,
                false
                );
            if (!loginResult.Succeeded)
            {
                return BadRequest();
            }
            var user = await userManager.FindByNameAsync(loginDto.Email);
           


            //2.创建jwt
            //header
            var signingAlgoithm = SecurityAlgorithms.HmacSha256;
            //payload
            var claims = new List<Claim>
            {
                //sub 
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                //new Claim(ClaimTypes.Role,"Admin")
            };
            var roleNames = await userManager.GetRolesAsync(user);
            foreach (var roleName in roleNames)
            {
                var roleClaim = new Claim(ClaimTypes.Role, roleName);
                claims.Add(roleClaim);
            }

            //signiture ☆☆key至少要16个字符
            var sercretByte = Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]);
            var signingKey = new SymmetricSecurityKey(sercretByte);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgoithm);

            var token = new JwtSecurityToken(
                issuer: configuration["Authentication:Issuer"],
                audience: configuration["Authentication:Audience"],
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials
                );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            //3.return 200 ok +jwt

            return Ok(tokenStr);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            //1.使用用户名创建用户对象
            var user = new ApplicationUser()
            {
                UserName = registerDto.Email,
                Email = registerDto.Email
            };
            //2.hash密码，保存用户
            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }

        }
    }
}
