using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using System.Linq;

namespace Hermes.Api.Services
{
    public interface IClienteService
    {
        public IQueryable<Cliente> GetAll();
        public void Add(ClienteRequest request);
        public void Edit(ClienteRequest request);
        public void Delete(ClienteRequest request);
    }
}
