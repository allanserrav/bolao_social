using System.Threading.Tasks;
using BolaoSocial.Shared.Entities;
using BolaoSocial.Shared.Repositories;
using BolaoSocial.Shared.Services;
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

        [HttpGet("{id}")]
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

        [HttpPut]
        [Route("nome/{id}")]
        public async Task<IActionResult> UpdateNome(int id, [FromBody]string nome)
        {
            await Service.UpdateNome(id, nome);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var db = new AgrupamentoRepository(Service.Unit);
            await db.Delete(id);
            return Ok();
        }
    }
}