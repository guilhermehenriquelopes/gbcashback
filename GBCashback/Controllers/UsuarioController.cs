using System;
using GBCashback.Models;
using GBCashback.Services.Interface;
using GBCashback.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GBCashback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuarioController : ControllerBase
    {
        private readonly IRevendedorService _service;

        public UsuarioController(IRevendedorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Logar na aplicação
        /// </summary>        
        [HttpPost]
        public IActionResult Logar(Usuario usuario)
        {
            try
            {
                if (Geral.ValidarCpf(usuario.CPF))
                {
                    var revendedor = _service.ConsultarPorCpfSenha(usuario.CPF, usuario.Senha);

                    if (revendedor != null)
                    {
                        var token = JWTToken.GerarToken(revendedor);
                        revendedor.Senha = string.Empty;

                        return Ok(new { revendedor = revendedor, token = token });
                    }
                }

                return Unauthorized(Mensagens.FalhaLogin);
            }
            catch (ArgumentException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}