using BolaoSocial.Shared.Entities;
using System;
using System.Collections.Generic;

namespace BolaoSocial.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var competicao = new Competicao()
            {
                Nome = "Copa do mundo 2018",
            };

            var participantes = new List<Participante>
            {
                new Participante { Nome = "Rússia" },
                new Participante { Nome = "Arábia Saudita" },
                new Participante { Nome = "Egito" },
                new Participante { Nome = "Uruguai" },
                new Participante { Nome = "Brasil" },
                new Participante { Nome = "Suiça" },
            };

            var primeiraRodada = new Agrupamento { Nome = "1 rodada" };
            var grupoA = new Agrupamento { Nome = "Grupo A" };
            var grupoE = new Agrupamento { Nome = "Grupo E" };

            var eventosCopaPrimeiraRodada = new List<Evento>
            {
                new Evento
                {
                    Competicao = competicao,
                    Participantes = new List<EventoParticipante>
                    {
                        new EventoParticipante { Participante = participantes[0] },
                        new EventoParticipante { Participante = participantes[1] },
                    },
                    //Agrupamentos = new List<Agrupamento>
                    //{
                    //    primeiraRodada,
                    //    grupoA,
                    //},
                    Horario = new DateTime(2018, 6, 14, 12, 0, 0),
                    Localizacao = "Olímpico Lujniki",

                },
                new Evento
                {
                    Competicao = competicao,
                    Participantes = new List<EventoParticipante>
                    {
                        new EventoParticipante { Participante = participantes[2] },
                        new EventoParticipante { Participante = participantes[3] },
                    },
                    //Agrupamentos = new List<Agrupamento>
                    //{
                    //    primeiraRodada,
                    //    grupoA,
                    //},
                    Horario = new DateTime(2018, 6, 15, 9, 0, 0),
                    Localizacao = "Ecaterimburgo",
                },
                new Evento
                {
                    Competicao = competicao,
                    Participantes = new List<EventoParticipante>
                    {
                        new EventoParticipante { Participante = participantes[4] },
                        new EventoParticipante { Participante = participantes[5] },
                    },
                    //Agrupamentos = new List<Agrupamento>
                    //{
                    //    primeiraRodada,
                    //    grupoE,
                    //},
                    Horario = new DateTime(2018, 6, 17, 15, 0, 0),
                    Localizacao = "Rostov",
                },
            };

            foreach (var evento in eventosCopaPrimeiraRodada)
            {
            }

            var regraTudo = new RegraAcerto { Nome = "Acertou tudo", Pontos = 4, };
            var regraEmpate = new RegraAcerto { Nome = "Acertou empate", Pontos = 2, };
            var regraVencedor = new RegraAcerto { Nome = "Acertou vencedor", Pontos = 1, };

            var palpites = new PalpiteEvento
            {
                Evento = eventosCopaPrimeiraRodada[0],
                Palpites = new List<PalpiteParticipante>
                {
                    //new PalpiteParticipante { Participante = participantes[0], PalpiteValor = 3, },
                    //new PalpiteParticipante { Participante = participantes[1], PalpiteValor = 1, },
                }
            };
        }
    }
}
