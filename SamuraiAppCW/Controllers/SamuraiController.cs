using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamuraiAppCW.Models;
using SamuraiAppCW.Services;

namespace SamuraiAppCW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraiController : ControllerBase
    {
        private readonly ISamuraiService _samuraiService;

        public SamuraiController(ISamuraiService samuraiService)
        {
            _samuraiService = samuraiService;
        }

        [HttpGet("GetAllSamurais")]
        public async Task<ActionResult<List<Samurai>>> GetSamurais()
        {
            var samurais = await _samuraiService.GetAllSamurais();
            return Ok(samurais);
        }

    }
}
