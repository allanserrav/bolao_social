using BolaoSocial.Api.Models;
using BolaoSocial.Shared.Entities;
using BolaoSocial.Shared.Repositories;
using BolaoSocial.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoSocial.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/evento")]
    public class EventoController : Controller
    {
        public EventoService Service { get; }

        public EventoController(EventoService service)
        {
            Service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var db = new EventoRepository(Service.Unit);
            var evento = await db.Find(id);
            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]EventoModel data)
        {
            var evento = new Evento
            {
                Observacao = data.Nome,
                PermiteSubEvento = data.PermiteSubEvento,
                Horario = data.Horario,
                Localizacao = data.Localizacao,
            };
            evento.Participantes = GetParticipantes(evento, data.Participantes);
            evento.Agrupamentos = GetAgrupamentos(evento, data.Agrupamentos);
            await Service.Add(data.CompeticaoId, evento);
            return Ok();
        }

        [HttpPut]
        [Route("agrupamento/{id}")]
        public async Task<IActionResult> AddAgrupamentos(int id, [FromBody]IEnumerable<AgrupamentoModel> data)
        {
            var agrupamentos = GetAgrupamentos(null, data);
            await Service.AddAgrupamentos(id, agrupamentos);
            return Ok();
        }

        private IEnumerable<EventoParticipante> GetParticipantes(Evento evento, IEnumerable<Participante> participantes)
        {
            var c = new List<Participante>(participantes ?? Array.Empty<Participante>());
            return c.Select(p => new EventoParticipante() { Participante = p, Evento = evento, }).ToList();
        }

        private IEnumerable<EventoAgrupamento> GetAgrupamentos(Evento evento, IEnumerable<AgrupamentoModel> agrupamentos)
        {
            var c = new List<AgrupamentoModel>(agrupamentos ?? Array.Empty<AgrupamentoModel>());
            return c.Select(p => new EventoAgrupamento() { Agrupamento = new Agrupamento { Id = p.Id, Nome = p.Nome, }, Evento = evento, Ordem = p.Ordem, }).ToList();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var db = new EventoRepository(Service.Unit);
            await db.Delete(id);
        }
    }
}