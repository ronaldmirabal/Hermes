using Hermes.Api.Data;
using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Hermes.Api.Services;
using Hermes.Api.Tools;
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
        private readonly IArticuloService _articuloService;

        public ArticuloController(DataContext contex, IArticuloService articuloService)
        {
            _contex = contex;
            this._articuloService = articuloService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                var art = _articuloService.GetAll();
                _respuesta.Exito = 1;
                _respuesta.Datos = art;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

      

        [HttpPost]
        public async Task<IActionResult> Add(ArticuloRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Respuesta _respuesta = new Respuesta();
            try
            {
                await _articuloService.Add(request);
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Exito = 0;
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ArticuloRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                await _articuloService.Update(request);
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

  
        [HttpPut("{id}")]
        [Route("delete")]
        public IActionResult Delete(ArticuloRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _articuloService.Delete(request);
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
