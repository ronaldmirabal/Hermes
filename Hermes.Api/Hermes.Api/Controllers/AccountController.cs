using Hermes.Api.Data;
using Hermes.Api.Helpers;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserHelper _userHelper;
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public AccountController(IUserHelper userHelper, IConfiguration configuration, DataContext context)
        {
            _userHelper = userHelper;
            _configuration = configuration;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await _context.Users
                .ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Autentificar(AuthRequest request)
        {
            Respuesta respuesta = new Respuesta();
            var userresponse =  _userHelper.Auth(request);
            if (userresponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contraseña incorrecta";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Datos = userresponse;


            return Ok(respuesta);
          
            
        }



       







        //[HttpPost]
        //[Route("CreateToken")]
        //public async Task<IActionResult> CreateToken([FromBody] AuthRequest model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = await _userHelper.GetUserAsync(model.username);
        //        if (user != null)
        //        {
        //            Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.ValidatePasswordAsync(user, model.password);

        //            if (result.Succeeded)
        //            {
        //                Claim[] claims = new[]
        //                {
        //                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //            };

        //                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
        //                SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //                JwtSecurityToken token = new JwtSecurityToken(
        //                    _configuration["Tokens:Issuer"],
        //                    _configuration["Tokens:Audience"],
        //                    claims,
        //                    expires: DateTime.UtcNow.AddDays(99),
        //                    signingCredentials: credentials);
        //                var results = new
        //                {
        //                    token = new JwtSecurityTokenHandler().WriteToken(token),
        //                    expiration = token.ValidTo,
        //                    user
        //                };

        //                return Created(string.Empty, results);
        //            }
        //        }
        //    }

        //    return BadRequest();
        //}
    



    private object GetToken(User user)
        {
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                _configuration["Tokens:Issuer"],
                _configuration["Tokens:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(99),
                signingCredentials: credentials);

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                user
            };
        }



       









    }
}
