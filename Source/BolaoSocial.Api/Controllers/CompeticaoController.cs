using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Entities;
using BolaoSocial.Shared.Repositories;
using BolaoSocial.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolaoSocial.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/competicao")]
    public class CompeticaoController : Controller
    {
        public CompeticaoService Service { get; }

        public CompeticaoController(CompeticaoService service)
        {
            Service = service;
        }

        // GET: api/competicao/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var db = new CompeticaoRepository(Service.Unit);
            var competicao = await db.Find(id);
            return Ok(competicao);
        }

        // POST: api/competicao
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Competicao model)
        {
            var db = new CompeticaoRepository(Service.Unit);
            await db.Add(model);
            return Ok();
        }

        // PUT: api/competicao/nome/5
        [HttpPut("{id}")]
        [Route("nome")]
        public async Task UpdateNome(int id, [FromBody]string nome)
        {
            await Service.UpdateNome(id, nome);
        }

        // PUT: api/competicao/nome/5
        [HttpPut("{id}")]
        [Route("tipo")]
        public async Task UpdateTipo(int id, [FromBody]EventoType tipo)
        {
            await Service.UpdateTipo(id, tipo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var db = new CompeticaoRepository(Service.Unit);
            await db.Delete(id);
        }
    }
}