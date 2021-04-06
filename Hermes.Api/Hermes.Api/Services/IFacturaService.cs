using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Helpers
{
    public interface IFacturaService
    {
        public void Add(FacturaRequest request);
        IQueryable<Factura> GetAll();
    }
}
