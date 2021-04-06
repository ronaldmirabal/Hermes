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
                var lst = _context.Clientes.Include(i => i.ididentificacionType).OrderByDescending(d => d.Id).ToList();
                _respuesta.Datos = lst;
                _respuesta.Exito = 1;
               

            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Exito = 0;
            }
            return Ok(_respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClienteRequest oModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Respuesta _respuesta = new Respuesta();
            try
            {
                var tipo = await _context.IdentificacionTypes.FindAsync(oModel.idtipoidentificacion);
                if (tipo == null)
                {
                    _respuesta.Exito = 0;
                    return BadRequest("Tipo id no valida");
                }

                var oCliente = new Cliente();
                oCliente.Nombre = oModel.nombre;
                oCliente.Identificacion = oModel.identificacion;
                oCliente.Direccion = oModel.direccion;
                oCliente.Telefono = oModel.telefono;
                oCliente.Estado = true;
                oCliente.ididentificacionType = tipo;
                _context.Add(oCliente);
                await _context.SaveChangesAsync();
                _respuesta.Exito = 1;

            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }



        [HttpPut]
        public async Task<IActionResult> Edit(ClienteRequest oModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Respuesta _respuesta = new Respuesta();
            try
            {
                var tipo = await _context.IdentificacionTypes.FindAsync(oModel.idtipoidentificacion);
                if (tipo == null)
                {
                    _respuesta.Exito = 0;
                    return BadRequest("Tipo id no valida");
                }
                Cliente oCliente = _context.Clientes.Find(oModel.id);
                oCliente.Nombre = oModel.nombre;
                oCliente.Identificacion = oModel.identificacion;
                oCliente.Direccion = oModel.direccion;
                oCliente.Telefono = oModel.telefono;
                oCliente.Estado = true;
                oCliente.ididentificacionType = tipo;
                _context.Clientes.Update(oCliente);
                await _context.SaveChangesAsync();
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
