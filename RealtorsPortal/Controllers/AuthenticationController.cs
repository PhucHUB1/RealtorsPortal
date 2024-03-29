﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealtorsPortal.Entities;
using System.Security.Cryptography;
using RealtorsPortal.Dto;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace RealtorsPortal.Controllers
{
    [ApiController]
    [Route("/api/user")]
    [Authorize(Policy = "User")] 
    public class AuthenticationController: ControllerBase
    {
        private readonly RealEstateContext _context;
        private readonly IConfiguration _config;
        
        public AuthenticationController(RealEstateContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public IActionResult Register(UserRegister user)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var u = new Entities.User { UserName =user.UserName, Email = user.Email,Password = hashed,Phone = user.Phone,PersonalTaxCode = user.PersonalTaxCode,Picture = user.Picture};
            _context.Users.Add(u);
            _context.SaveChanges();
            return Ok(new UserData { UserName=user.UserName,Email=user.Email,Phone = user.Phone,PersonalTaxCode = user.PersonalTaxCode,Picture = user.Picture,Token= GenerateJWT(u)});
        }
        private String GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signatureKey = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.MobilePhone,user.Phone),
                        new Claim(ClaimTypes.UserData,user.PersonalTaxCode),
                        new Claim(ClaimTypes.UserData,user.Picture)
                    
                    };
                    var token = new JwtSecurityToken(
                        _config["JWT:Issuer"],
                        _config["JWT:Audience"],
                        claims,
                        expires: DateTime.Now.AddHours(2),
                        signingCredentials: signatureKey
                    );

                    return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(UserLogin userLogin)
        {
            var user = _context.Users.Where(u => u.Email.Equals(userLogin.Email))
                .First();
            if (user == null)
                return Unauthorized();
            bool verified = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password);
            if(!verified)
                return Unauthorized();

            return Ok(new UserData {UserName=user.UserName,Email=user.Email,Phone = user.Phone,PersonalTaxCode = user.PersonalTaxCode,Picture = user.Picture,Token= GenerateJWT(user) });
        }
        
        [HttpGet]
        [Route("profile")]
        public IActionResult Profile()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var userClaims = identity.Claims;
                var Id = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var user =  new UserData
                {
                    Id = Convert.ToInt32(Id),
                    UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Phone = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone)?.Value,
                    PersonalTaxCode = userClaims.FirstOrDefault(x => x.Type ==ClaimTypes.UserData )?.Value,
                    Picture = userClaims.FirstOrDefault(x => x.Type ==ClaimTypes.UserData )?.Value
                };
                return Ok(user);
            }
            return Unauthorized();
        }
    }
}


