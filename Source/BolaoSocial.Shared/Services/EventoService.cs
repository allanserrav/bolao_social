using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Entities;
using BolaoSocial.Shared.Repositories;

namespace BolaoSocial.Shared.Services
{
    public class EventoService : Base
    {
        public EventoService(IUnitOfWork unit) : base(unit)
        {
        }

        public async Task Add(int competicaoId, Evento evento)
        {
            var compdb = new CompeticaoRepository(Unit);
            var competicao = await compdb.Find(competicaoId);
            if(competicao == null)
            {
                throw new ArgumentException("Competição informada não existe");
            }
            await Add(competicao, evento);
        }

        public async Task Add(Competicao competicao, Evento evento)
        {
            var db = new EventoRepository(Unit);
            var criador = CriadorEvento.Get(competicao.EventoTipo);
            using (var tr = Unit.BeginTransaction())
            {
                await criador.Processar(Unit, competicao, evento);
                await db.Add(evento);
                tr.Commit();
            }
        }

        public async Task AddAgrupamentos(int eventoId, IEnumerable<EventoAgrupamento> data)
        {
            var db = new EventoRepository(Unit);
            var agrdb = new AgrupamentoRepository(Unit);
            var eagrdb = new EventoAgrupamentoRepository(Unit);
            var evento = await db.Find(eventoId);
            foreach (var item in data)
            {
                item.Evento = evento;
                if (item.Agrupamento.Id <= 0)
                    await agrdb.Add(item.Agrupamento);
                else
                    item.Agrupamento = await agrdb.Find(item.Agrupamento.Id);
                await eagrdb.Add(item);
            }
        }
    }

    public abstract class CriadorEvento
    {
        public static CriadorEvento Get(EventoType tipo)
        {
            switch (tipo)
            {
                case EventoType.Futebol:
                    return new CriadorEventoFutebol();
                default:
                    throw new NotImplementedException();
            }
        }

        public async Task Processar(IUnitOfWork unit, Competicao competicao, Evento evento)
        {
            var partdb = new ParticipanteRepository(unit);
            var agrdb = new AgrupamentoRepository(unit);
            evento.Competicao = competicao;
            evento.Tipo = competicao.EventoTipo;

            // Verifica se é um participante novo
            foreach (var item in evento.Participantes)
            {
                if(item.Participante.Id <= 0) await partdb.Add(item.Participante);
            }
            // Verifica se é um agrupamento novo
            foreach (var item in evento.Agrupamentos)
            {
                if (item.Agrupamento.Id <= 0)
                    await agrdb.Add(item.Agrupamento);
                else
                    item.Agrupamento = await agrdb.Find(item.Agrupamento.Id);
            }
            await DoProcessar(evento);
        }

        protected abstract Task DoProcessar(Evento evento);
    }

    public class CriadorEventoFutebol : CriadorEvento
    {
        protected override Task DoProcessar(Evento evento)
        {
            if(evento.Participantes == null || evento.Participantes.Count() != 2)
            {
                throw new ArgumentException("Número de participantes inválidos para uma partida de futebol");
            }
            return Task.CompletedTask;
        }
    }
}
