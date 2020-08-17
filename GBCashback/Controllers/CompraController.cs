using System;
using System.Collections.Generic;
using AutoMapper;
using GBCashback.Models;
using GBCashback.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBCashback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CompraController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompraService _service;

        public CompraController(IMapper mapper, ICompraService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Cadastra uma nova Compra
        /// </summary>                
        [HttpPost]
        public ActionResult<Compra> Cadastrar(Compra compra)
        {
            try
            {
                return _service.Cadastrar(compra);
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
        /// Retorna todas as Compras
        /// </summary>                
        [HttpGet]
        public ActionResult<IEnumerable<Compra>> Consulta()
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
        /// Deleta uma Compra de acordo com o Id informado
        /// </summary>        
        [HttpDelete("{id}")]
        public ActionResult<Compra> Deletar(long id)
        {
            try
            {
                var compra = _service.Consultar(id);

                if (compra == null)
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