using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Hermes.Api.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly DataContext _context;

        public ProveedorService(DataContext context)
        {
            _context = context;
        }
        public void Add(ProveedorRequest request)
        {
            try
            {
                var identificacion = _context.IdentificacionTypes.Find(request.idtipoidentificacion);
                Proveedor _proveedor = new Proveedor();
                _proveedor.Nombre = request.nombre;
                _proveedor.Telefono = request.telefono;
                _proveedor.Direccion = request.direccion;
                _proveedor.Estado = true;
                _proveedor.ididentificacionType = identificacion;
                _proveedor.NoIdentificacion = request.Noidentificacion;
                _context.Add(_proveedor);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error en la inserción");
            }
        }


        public void Delete(ProveedorRequest request)
        {
            try
            {
                Proveedor _proveedor = _context.Proveedores.Find(request.id);
                _proveedor.Estado = false;
                _context.Proveedores.Update(_proveedor);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error en la eliminación");
            }
        }

        public void Edit(ProveedorRequest request)
        {
            try
            {
                var identificacion = _context.IdentificacionTypes.Find(request.idtipoidentificacion);
                Proveedor _proveedor = _context.Proveedores.Find(request.id);
                _proveedor.Nombre = request.nombre;
                _proveedor.Telefono = request.telefono;
                _proveedor.Direccion = request.direccion;
                _proveedor.Estado = true;
                _proveedor.ididentificacionType = identificacion;
                _proveedor.NoIdentificacion = request.Noidentificacion;
                _context.Proveedores.Update(_proveedor);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error en la edición");
            }
        }

        public IQueryable<Proveedor> GetAll()
        {
            return _context.Proveedores.Include(i => i.ididentificacionType).OrderByDescending(d => d.Id).Where(f => f.Estado == true);
        }
    }
}
