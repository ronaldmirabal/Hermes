using Hermes.Api.Data;
using Hermes.Api.Helpers;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FacturaController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFacturaService _facturaService;

        public FacturaController(DataContext context, IFacturaService facturaService)
        {
            _context = context;
            _facturaService = facturaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                var fact = _facturaService.GetAll();
                _respuesta.Datos = fact;
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.ToString();
            }
            return Ok(_respuesta);
        }

        [HttpPost]
        public IActionResult Add(FacturaRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _facturaService.Add(request);
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Exito = 0;
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }





    }
}
