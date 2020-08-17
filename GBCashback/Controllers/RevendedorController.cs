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
    [ApiController]
    [Route("api/[controller]")]
    public class RevendedorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRevendedorService _service;

        public RevendedorController(IMapper mapper, IRevendedorService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Cadastra um novo revendedor
        /// </summary>        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<Revendedor> Cadastrar(RevendedorDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                Revendedor revendedor = _mapper.Map<Revendedor>(dto);

                return _service.Cadastrar(revendedor);
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
        /// Retorna todos os revendedores
        /// </summary>                
        [HttpGet]
        public ActionResult<IEnumerable<Revendedor>> Consulta()
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
        /// Retorna um revendedor de acordo com o Id informado
        /// </summary>        
        [HttpGet("{id}")]
        public ActionResult<Revendedor> Consulta(long id)
        {
            try
            {
                var revendedor = _service.Consultar(id);

                if (revendedor == null)
                    return NoContent();

                return Ok(revendedor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um revendedor
        /// </summary>        
        [HttpPut]
        public IActionResult Atualizar(Revendedor revendedor)
        {
            try
            {
                return Ok(_service.Atualizar(revendedor));
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
        /// Altera o status para Ativo de acordo com o Id informado
        /// </summary>        
        [HttpPut("{id}/ativar")]
        public IActionResult Ativar(long id)
        {
            try
            {
                var revendedor = _service.Consultar(id);

                if (revendedor == null)
                    return NoContent();

                return Ok(_service.Ativar(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Altera o status para Inativo de acordo com o Id informado
        /// </summary>        
        [HttpPut("{id}/inativar")]
        public IActionResult Inativar(long id)
        {
            try
            {
                var revendedor = _service.Consultar(id);

                if (revendedor == null)
                    return NoContent();

                return Ok(_service.Inativar(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Deleta o Revendedor de acordo com o Id informado
        /// </summary>        
        [HttpDelete("{id}")]
        public ActionResult<Revendedor> Deletar(long id)
        {
            try
            {
                var revendedor = _service.Consultar(id);

                if (revendedor == null)
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