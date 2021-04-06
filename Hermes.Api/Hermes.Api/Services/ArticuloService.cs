using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Tools;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly DataContext _context;

        public ArticuloService(DataContext context)
        {
            _context = context;
        }
        public async Task Add(ArticuloRequest request)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(request.IdCategoria);
                var article = _context.Articulos.OrderByDescending(t => t.Id).FirstOrDefault();
                int id;
                if (article == null)
                {
                    id = 1;
                }
                else
                {
                    id = article.Id;
                }
                Articulo articulo = new Articulo();
                articulo.Codigo = "A" + LlenaCero.LlenaConCero(id.ToString(), 8, "0");
                articulo.Nombre = request.Nombre;
                articulo.Descripcion = request.Descripcion;
                articulo.Tipo = request.Tipo;
                articulo.Precio = request.Precio;
                articulo.Stock = request.Stock;
                articulo.Costo = request.Costo;
                articulo.Itbis = request.Itbis;
                articulo.categoria = categoria;
                articulo.Estado = true;
                _context.Add(articulo);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error en la inserción");
            }
        }

        public void Delete(ArticuloRequest request)
        {
            try
            {
                Articulo articulo = _context.Articulos.Find(request.Id);
                articulo.Codigo = articulo.Codigo;
                articulo.Nombre = articulo.Nombre;
                articulo.Descripcion = articulo.Descripcion;
                articulo.Precio = articulo.Precio;
                articulo.Stock = articulo.Stock;
                articulo.Tipo = articulo.Tipo;
                articulo.categoria = articulo.categoria;
                articulo.Estado = false;
                articulo.Costo = articulo.Costo;
                articulo.Itbis = articulo.Itbis;
                _context.Articulos.Update(articulo);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error en el delete");
            }
        }

        public IQueryable<Articulo> GetAll()
        {
            return _context.Articulos.OrderByDescending(a => a.Id).Include(c => c.categoria);
        }

        public async Task Update(ArticuloRequest request)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(request.IdCategoria);
                Articulo articulo = await _context.Articulos.FindAsync(request.Id);
                articulo.Codigo = articulo.Codigo;
                articulo.Nombre = request.Nombre;
                articulo.Descripcion = request.Descripcion;
                articulo.Tipo = request.Tipo;
                articulo.Precio = request.Precio;
                articulo.Stock = request.Stock;
                articulo.Costo = request.Costo;
                articulo.Itbis = request.Itbis;
                articulo.categoria = categoria;
                articulo.Estado = request.Estado;
                _context.Articulos.Update(articulo);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error en la actualizacion");
            }
        }
    }
}
