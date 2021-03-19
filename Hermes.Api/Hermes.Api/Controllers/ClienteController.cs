using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Hermes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;


        public ClienteController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                var lst = _context.Clientes.OrderByDescending(d => d.Id).ToList();
                _respuesta.Exito = 1;
                _respuesta.Data = lst;

            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                Cliente oCliente = new Cliente();
                oCliente.Nombre = oModel.nombre;
                _context.Add(oCliente);
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
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                Cliente oCliente = _context.Clientes.Find(oModel.id);
                oCliente.Nombre = oModel.nombre;
                _context.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                _respuesta.Exito = 1;

            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }


    }
}
