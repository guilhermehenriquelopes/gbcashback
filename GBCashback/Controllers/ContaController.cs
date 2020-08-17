using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GBCashback.DTO;
using GBCashback.Models;
using GBCashback.Services.Interface;
using GBCashback.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GBCashback.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ContaController : ControllerBase
    {
        private readonly IApiBoticarioService _apiService;
        private readonly ICompraService _service;

        public ContaController(IApiBoticarioService apiService, ICompraService service)
        {
            _apiService = apiService;
            _service = service;
        }

        /// <summary>
        /// Retorna o saldo acumulado na API externa
        /// </summary>        
        [HttpGet("{cpf}/acumuladoapi")]
        public ActionResult<AcumuladoDTO> AcumuladoApi(string cpf)
        {
            if (!Geral.ValidarCpf(cpf))
                return BadRequest(Mensagens.CpfInvalido);
                
            return Ok(_apiService.Acumulado(cpf));
        }

        /// <summary>
        /// Retorna o saldo acumulado
        /// </summary>        
        [HttpGet("{cpf}/acumulado")]
        public ActionResult<AcumuladoDTO> Acumulado(string cpf)
        {
            if (!Geral.ValidarCpf(cpf))
                return BadRequest(Mensagens.CpfInvalido);

            return Ok(_service.Acumulado(cpf));
        }
    }
}