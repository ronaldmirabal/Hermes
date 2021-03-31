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
            await CheckIdentificacionAsync();
            await CheckCategoryAsync();
        }




        private async Task CheckCategoryAsync()
        {
            if (!_context.Categorias.Any())
            {
                _context.Categorias.Add(new Categoria { Nombre = "General" });
                await _context.SaveChangesAsync();
            }
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
