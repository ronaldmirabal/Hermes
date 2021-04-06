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
        private readonly IUserService _userHelper;

        public SeedDb(DataContext context, IUserService userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckIdentificacionAsync();
            await CheckCategoryAsync();
            await CheckNfcAsync();
        }

        private async Task CheckNfcAsync()
        {
            if (!_context.TipoComprobantes.Any())
            {
                await AddNfc("Sin Comprobante", "S", 0, 0);
                await AddNfc("Factura de Crédito Fiscal Electrónica", "E", 31, 0);
                await AddNfc("Factura de Consumo Electrónica", "E", 32, 0);
                await AddNfc("Nota de Débito Electrónica", "E", 33, 0);
                await AddNfc("Nota de Crédito Fiscal Electrónica", "E", 34, 0);
                await AddNfc("Compras Electrónico", "E", 41, 0);
                await AddNfc("Gastos Menors Electrónico", "E", 43, 0);
                await AddNfc("Regímenes Especiales Electrónica", "E", 44, 0);
                await AddNfc("Gubernamental Electrónico", "E", 45, 0);
                await _context.SaveChangesAsync();
            }
        }

        private async Task AddNfc(string nombreNfc, string serie, int tipoNfc, int cantidadDisponible)
        {
            TipoComprobante tipoComprobante = new TipoComprobante
            {
                NombreNfc = nombreNfc,
                Serie = serie,
                TipoNfc = tipoNfc,
                CantidadDisponible = cantidadDisponible
            };
            await _context.TipoComprobantes.AddAsync(tipoComprobante);
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
