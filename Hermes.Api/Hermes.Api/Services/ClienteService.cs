using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Hermes.Api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly DataContext _context;

        public ClienteService(DataContext context)
        {
            _context = context;
        }

        public void Add(ClienteRequest request)
        {
            try
            {
                var tipo = _context.IdentificacionTypes.Find(request.idtipoidentificacion);
                var _cliente = new Cliente();
                _cliente.Nombre = request.nombre;
                _cliente.Identificacion = request.identificacion;
                _cliente.Direccion = request.direccion;
                _cliente.Telefono = request.telefono;
                _cliente.Estado = true;
                _cliente.ididentificacionType = tipo;
                _context.Add(_cliente);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error en la inserción");
            }
        }

        public void Delete(ClienteRequest request)
        {
            try
            {
                Cliente _cliente = _context.Clientes.Find(request.id);
                _cliente.Estado = false;
                _context.Clientes.Update(_cliente);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error en el borrado");
            }
        }

        public void Edit(ClienteRequest request)
        {
            try
            {
                var tipo = _context.IdentificacionTypes.Find(request.idtipoidentificacion);
                Cliente _cliente = _context.Clientes.Find(request.id);
                _cliente.Nombre = request.nombre;
                _cliente.Identificacion = request.identificacion;
                _cliente.Direccion = request.direccion;
                _cliente.Telefono = request.telefono;
                _cliente.Estado = true;
                _cliente.ididentificacionType = tipo;
                _context.Clientes.Update(_cliente);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error en la edición");
            }
        }

        public IQueryable<Cliente> GetAll()
        {
            return _context.Clientes.Include(i => i.ididentificacionType).OrderByDescending(o => o.Id).Where(w => w.Estado == true);
        }
    }
}
