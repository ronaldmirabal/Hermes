using Hermes.Api.Models.Response;
using Hermes.Api.Services;
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
    public class TipoComprobanteController : ControllerBase
    {
        private readonly ITipoComprobanteService _comprobanteService;

        public TipoComprobanteController(ITipoComprobanteService comprobanteService)
        {
            _comprobanteService = comprobanteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _respuesta.Datos = _comprobanteService.GetAll();
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
