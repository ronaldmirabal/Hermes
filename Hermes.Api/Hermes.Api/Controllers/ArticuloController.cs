using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArticuloController : ControllerBase
    {
        private readonly DataContext _contex;

        public ArticuloController(DataContext contex)
        {
            _contex = contex;
        }
        // GET: api/<ArticuloController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Respuesta _respuesta = new Respuesta();
            try
            {
                var res = await _contex.Articulos.OrderByDescending(d => d.Id).Include(c => c.categoria).ToListAsync();
                _respuesta.Exito = 1;
                _respuesta.Data = res;
            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        // GET api/<ArticuloController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Respuesta _respuesta = new Respuesta();
            try
            {
                var res = await _contex.Articulos.Include(f => f.categoria).Where(a => a.Id == id).ToListAsync();
                _respuesta.Exito = 1;
                _respuesta.Data = res;
            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        // POST api/<ArticuloController>
        [HttpPost]
        public async Task<IActionResult> Post(ArticuloRequest articuloRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Respuesta _respuesta = new Respuesta();
            try
            {
                var categoria = await _contex.Categorias.FindAsync(articuloRequest.IdCategoria);
                if (categoria == null)
                {
                    _respuesta.Exito = 0;
                    return BadRequest("Categoria no valida");
                }


                Articulo articulo = new Articulo();
                articulo.Codigo = articuloRequest.Codigo;
                articulo.Nombre = articuloRequest.Nombre;
                articulo.Descripcion = articuloRequest.Descripcion;
                articulo.Precio = articuloRequest.Precio;
                articulo.Stock = articuloRequest.Stock;
                articulo.categoria = categoria;
                articulo.Estado = true;
                _contex.Add(articulo);
                await _contex.SaveChangesAsync();
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        // PUT api/<ArticuloController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ArticuloRequest articuloRequest)
        {
            Respuesta _respuesta = new Respuesta();
            if (!ModelState.IsValid)
            {
                _respuesta.Exito = 0;
                return BadRequest(ModelState);
            }

            if (id != articuloRequest.Id)
            {
                _respuesta.Exito = 0;
                return BadRequest();
            }

            
            try
            {
                var categoria = await _contex.Categorias.FindAsync(articuloRequest.IdCategoria);
                if (categoria == null)
                {
                    _respuesta.Exito = 0;
                    return BadRequest("Categoria no valida");
                }


                Articulo articulo = await _contex.Articulos.FindAsync(articuloRequest.Id);
                articulo.Codigo = articuloRequest.Codigo;
                articulo.Nombre = articuloRequest.Nombre;
                articulo.Descripcion = articuloRequest.Descripcion;
                articulo.Precio = articuloRequest.Precio;
                articulo.Stock = articuloRequest.Stock;
                articulo.categoria = categoria;
                _contex.Articulos.Update(articulo);
                await _contex.SaveChangesAsync();
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        // DELETE api/<ArticuloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
