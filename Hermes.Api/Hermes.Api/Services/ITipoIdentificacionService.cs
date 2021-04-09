using Hermes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Services
{
    public interface ITipoIdentificacionService
    {
        public IQueryable<IdentificacionType> GetAll();
    }
}
