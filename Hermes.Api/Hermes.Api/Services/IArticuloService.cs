using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Services
{
    public interface IArticuloService
    {
        Task Add(ArticuloRequest request);
        Task Update(ArticuloRequest request);
        public void Delete(ArticuloRequest request);
        IQueryable<Articulo> GetAll();
    }
}
