using Hermes.Api.Data;
using Hermes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Services
{
    public class TipoComprobanteService : ITipoComprobanteService
    {
        private readonly DataContext _context;

        public TipoComprobanteService(DataContext context)
        {
            _context = context;
        }
        public IQueryable<TipoComprobante> GetAll()
        {
            return _context.TipoComprobantes.OrderBy(d => d.Id);
        }
    }
}
