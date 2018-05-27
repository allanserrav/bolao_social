using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolaoSocial.Shared;
using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Models;
using BolaoSocial.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolaoSocial.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/participante")]
    //[Route("api/[controller]")]
    public class ParticipanteController : Controller
    {
        public ParticipanteRepository Db { get; }

        protected ParticipanteController(IDataRead reader, IDataWrite writer)
        {
            Db = new ParticipanteRepository(reader, writer);
        }

        // GET: api/participante/5
        //[HttpGet("{id}", Name = "Get")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var participante = await Db.Find(id);
        //    return Ok(participante);
        //}

        // POST: api/participante
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]Participante model)
        {
            await Db.Add(model);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // PUT: api/Participante/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}
