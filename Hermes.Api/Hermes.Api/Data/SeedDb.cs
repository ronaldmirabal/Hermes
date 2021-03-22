using Hermes.Api.Helpers;
using Hermes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckIdentificacionAsync();
            await CheckUserAsync("Ronald Mirabal", "mirabalsoft@gmail.com","admin", "322 311 4620", UserType.Admin);
        }

        

        private async Task<User> CheckUserAsync(
        string nombre,
        string email,
        string username,
        string phone,
        UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Nombre = nombre,
                    Email = email,
                    UserName = username,
                    PhoneNumber = phone,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "173001");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckIdentificacionAsync()
        {
            if (!_context.IdentificacionTypes.Any())
            {
                _context.IdentificacionTypes.Add(new IdentificacionType { Nombre = "Cedula" });
                _context.IdentificacionTypes.Add(new IdentificacionType { Nombre = "Pasaporte" });
                await _context.SaveChangesAsync();
            }
        }




    }
}
