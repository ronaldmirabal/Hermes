using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Hermes.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _respuesta.Datos = _proveedorService.GetAll();
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPost]
        public IActionResult Add(ProveedorRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _proveedorService.Add(request);
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPut]
        public IActionResult Edit(ProveedorRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _proveedorService.Edit(request);
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPut]
        [Route("delete")]
        public IActionResult Delete(ProveedorRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _proveedorService.Delete(request);
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
