using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Hermes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriaController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                var from = 0;
                var to = 0;
                var result = _context.Categorias.ToList();
                var count = result.Count();


                Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
                Response.Headers.Add("Content-Range", $"{typeof(T).Name.ToLower()} {from}-{to}/{count}");
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    Respuesta _respuesta = new Respuesta();
        //    try
        //    {
        //        var res = _context.Categorias.ToList();
        //        _respuesta.Exito = 1;
        //        _respuesta.Datos = res;
        //    }
        //    catch (Exception ex)
        //    {
        //        _respuesta.Mensaje = ex.Message;
        //    }
        //    return Ok(_respuesta);

        //}

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


        [HttpDelete]
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
