using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comanda.Service.API.Controllers
{
    [ApiController]
    [Authorize()]
    [Produces("application/json")]
    [Route("api/v1.0/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        public BaseApiController() { }
    }
}