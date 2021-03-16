using Microsoft.EntityFrameworkCore;
using System;


#nullable disable

namespace Hermes.Api.Models
{
    public partial class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Detallefactura> Detallefacturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }

   
    }
}
