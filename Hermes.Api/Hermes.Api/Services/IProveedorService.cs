using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Services
{
    public interface IProveedorService
    {
        public void Add(ProveedorRequest request);
        public void Edit(ProveedorRequest request);
        public void Delete(ProveedorRequest request);
        public IQueryable<Proveedor> GetAll();
    }
}
