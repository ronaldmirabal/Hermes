using Hermes.Api.Data;
using Hermes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Services
{
    public class TipoIdentificacionService : ITipoIdentificacionService
    {
        private readonly DataContext _context;

        public TipoIdentificacionService(DataContext context)
        {
            _context = context;
        }
        public IQueryable<IdentificacionType> GetAll()
        {
            return _context.IdentificacionTypes.OrderByDescending(i => i.Id);
        }
    }
}
