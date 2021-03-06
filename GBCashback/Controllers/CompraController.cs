using System;
using System.Collections.Generic;
using AutoMapper;
using GBCashback.DTO;
using GBCashback.Models;
using GBCashback.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBCashback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
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
        [AllowAnonymous]
        public ActionResult<Compra> Cadastrar(CompraDTO dto)
        {
            try
            {
                Compra compra = _mapper.Map<Compra>(dto);

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
        /// Altera o status para Ativo de acordo com o cpf e código informado
        /// </summary>        
        [HttpPut("{cpf}/{codigo}/ativar")]
        public IActionResult Ativar(string cpf, string codigo)
        {
            try
            {
                return Ok(_service.Ativar(cpf, codigo));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Retorna todas as compras de acordo com o CPF informado
        /// </summary>        
        [HttpGet("{cpf}")]
        public IActionResult Consultar(string cpf)
        {
            try
            {
                return Ok(_service.Consultar(cpf));
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
        /// Deleta uma Compra de acordo com o CPF e Código informado
        /// </summary>        
        [HttpDelete("{cpf}/{codigo}")]
        public ActionResult<Compra> Deletar(string cpf, string codigo)
        {
            try
            {
                return Ok(_service.Deletar(cpf, codigo));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}