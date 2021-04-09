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
    public class IdentificacionController : ControllerBase
    {
        private readonly ITipoIdentificacionService _tipoIdentificacionService;

        public IdentificacionController(ITipoIdentificacionService tipoIdentificacionService)
        {
            _tipoIdentificacionService = tipoIdentificacionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _respuesta.Datos = _tipoIdentificacionService.GetAll();
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Exito = 0;
            }
            return Ok(_respuesta);
        }
    }
}
