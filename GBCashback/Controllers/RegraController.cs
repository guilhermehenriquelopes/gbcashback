using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCashback.Models;
using GBCashback.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBCashback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegraController : ControllerBase
    {
        
    }
}