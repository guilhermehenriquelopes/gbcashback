using System.Threading.Tasks;
using GBCashback.Enums;
using GBCashback.Models;
using GBCashback.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCashback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuarioController : ControllerBase
    {

    }
}