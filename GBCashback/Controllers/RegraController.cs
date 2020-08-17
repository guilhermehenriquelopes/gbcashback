using System;
using System.Collections.Generic;
using AutoMapper;
using GBCashback.Models;
using GBCashback.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBCashback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class RegraController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRegraService _service;

        public RegraController(IMapper mapper, IRegraService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Cadastra uma nova Regra
        /// </summary>                
        [HttpPost]
        public ActionResult<Regra> Cadastrar(Regra regra)
        {
            try
            {
                return _service.Cadastrar(regra);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Retorna todas as regras
        /// </summary>                
        [HttpGet]
        public ActionResult<IEnumerable<Regra>> Consulta()
        {
            try
            {
                return Ok(_service.Consultar());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Deleta a Regra de acordo com o Id informado
        /// </summary>        
        [HttpDelete("{id}")]
        public ActionResult<Regra> Deletar(long id)
        {
            try
            {
                var regra = _service.Consultar(id);

                if (regra == null)
                {
                    return NoContent();
                }

                return Ok(_service.Deletar(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}