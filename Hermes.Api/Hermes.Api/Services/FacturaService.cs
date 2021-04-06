using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Helpers
{
    public class FacturaService : IFacturaService
    {
        private readonly DataContext _context;

        public FacturaService(DataContext context)
        {
            _context = context;
        }
        public void Add(FacturaRequest request)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var client = _context.Clientes.Find(request.Idcliente);
                var comprobante = _context.TipoComprobantes.Find(request.IdTipoComprobante);
                var factura = new Factura();
                factura.Total = request.detallefacturas.Sum(d => d.Cantidad * d.Precio);
                factura.Fecha = DateTime.Now;
                factura.tipoComprobante = comprobante;
                factura.cliente = client;
                _context.Add(factura);
                _context.SaveChanges();

                foreach (var _detalle in request.detallefacturas)
               {
                    var art =  _context.Articulos.Find(_detalle.Idarticulo);
                    var fac =  _context.Facturas.Find(factura.Id);
                    var detalle = new Models.Detallefactura();
                    detalle.Cantidad = _detalle.Cantidad;
                    detalle.Articulo = art;
                    detalle.Precio = _detalle.Precio;
                    detalle.Itbis = _detalle.Itbis;
                    detalle.Factura = fac;
                    detalle.Total = _detalle.Total;
                    _context.Detallefacturas.Add(detalle);
                    _context.SaveChanges();
                }
                transaction.Commit();
            }
           catch (Exception)
            {
                transaction.Rollback();
                throw new Exception("Ocurio un error en la inserción");
            }
        }

        public IQueryable<Factura> GetAll()
        {
            return _context.Facturas.OrderByDescending(f => f.Id).Include(c => c.cliente).Include(t => t.tipoComprobante);
        }
    }
}
