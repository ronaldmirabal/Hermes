using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Hermes.Api.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Hermes.Api.Helpers
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public UserService(DataContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model)
        {
            var userresponse = new UserResponse();
            using (var db = _context)
            {
                string spassword = Encrypt.GetSHA256(model.password);
                var usuario = db.Users.Where(d => d.Username == model.username && d.Password == spassword).FirstOrDefault();
                if (usuario == null) return null;

                userresponse.Username = usuario.Username;
                userresponse.Token = GetToken(usuario);

            }
            return userresponse;
        }


        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Username.ToString())
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }

}
