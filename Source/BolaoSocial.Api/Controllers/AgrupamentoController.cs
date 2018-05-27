using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolaoSocial.Shared.Models;
using BolaoSocial.Shared.Repositories;
using BolaoSocial.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolaoSocial.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/agrupamento")]
    public class AgrupamentoController : Controller
    {
        public AgrupamentoService Service { get; }

        public AgrupamentoController(AgrupamentoService service)
        {
            Service = service;
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var db = new AgrupamentoRepository(Service.Unit);
            var agrupamento = await db.Find(id);
            return Ok(agrupamento);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Agrupamento data)
        {
            var db = new AgrupamentoRepository(Service.Unit);
            await db.Add(data);
            return Ok();
        }

        [HttpPut("{id}")]
        [Route("nome")]
        public async Task UpdateNome(int id, [FromBody]string nome)
        {
            await Service.UpdateNome(id, nome);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var db = new AgrupamentoRepository(Service.Unit);
            await db.Delete(id);
        }
    }
}