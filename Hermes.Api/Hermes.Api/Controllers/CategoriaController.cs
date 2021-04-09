using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Hermes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriaController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                var res = _context.Categorias.OrderBy(d => d.Id).ToList();
                _respuesta.Exito = 1;
                _respuesta.Datos = res;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);

        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public IActionResult Get(int id)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                var res = _context.Categorias.FirstOrDefault(g => g.Id == id);
                _respuesta.Datos = res;
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }


        [HttpPost]
        public IActionResult Add(CategoriaRequest oModel)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                Categoria categoria = new Categoria();
                categoria.Nombre = oModel.Nombre;
                _context.Add(categoria);
                _context.SaveChanges();
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPut]
        public IActionResult Edit(CategoriaRequest oModel)
        {
            Respuesta _respuesta = new Respuesta();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Categoria categoria = _context.Categorias.Find(oModel.id);
                categoria.Nombre = oModel.Nombre;
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }


        [HttpDelete("{id}")]
        public IActionResult Detele(int id)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                var res = _context.Categorias.FirstOrDefault(c => c.Id == id);
                if (res != null)
                {
                    _context.Categorias.Remove(res);
                    _context.SaveChanges();
                    _respuesta.Exito = 1;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }





    }
}
