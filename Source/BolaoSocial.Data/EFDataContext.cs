using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoSocial.Data
{
    public class EFDataContext : DbContext, IDataWrite, IDataRead
    {
        public DbContextOptions<EFDataContext> Options { get; }

        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {
            Options = options;
        }

        Task IDataWrite.Add<TModel>(TModel model)
        {
            var set = this.Set<TModel>();
            set.Add(model);
            return SaveChangesAsync();
        }

        Task IDataWrite.Attach<TModel>(TModel model)
        {
            var set = this.Set<TModel>();
            set.Attach(model);
            return Task.CompletedTask;
        }

        Task IDataWrite.Delete<TModel>(TModel model)
        {
            Remove(model);
            return SaveChangesAsync();
        }

        Task<int> IDataWrite.Update<TModel>(TModel model)
        {
            var set = this.Set<TModel>();
            set.Update(model);
            return SaveChangesAsync();
        }

        Task<TModel> IDataRead.Find<TModel>(int id)
        {
            return FindAsync<TModel>(id);
        }

        async Task<TModel> IDataRead.Find<TModel>(string codigo)
        {
            
            var read = this as IDataRead;
            var query = await read.GetQuery<TModel>();
            return query.FirstOrDefault(c => c.Codigo == codigo);
        }

        Task<IQueryable<TModel>> IDataRead.GetQuery<TModel>() => Task.FromResult(IncludeAll.Resolve(Set<TModel>()));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(b =>
            {
                b.ToTable("usuario");
                HasBaseEntidade(b, true, true, true);

                b.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsRequired();
                b.Property(e => e.SegundosLoginExpirar)
                    .IsRequired();
                b.Property(e => e.Senha)
                    .HasMaxLength(10)
                    .IsRequired();
            });

            modelBuilder.Entity<Agrupamento>(b =>
            {
                b.ToTable("agrupamento");
                HasBaseEntidade(b, true, true, true);

                b.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsRequired();

                b.HasMany(e => e.Eventos)
                    .WithOne(e => e.Agrupamento)
                    ;
            });

            modelBuilder.Entity<Competicao>(b =>
            {
                b.ToTable("competicao");
                HasBaseEntidade(b, true, true, true);

                b.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsRequired();
                b.Property(e => e.EventoTipo)
                    .IsRequired();
                b.HasMany(e => e.Eventos)
                    .WithOne(e => e.Competicao)
                    ;
            });

            modelBuilder.Entity<Evento>(b =>
            {
                b.ToTable("evento");
                HasBaseEntidade(b, true, true, true);

                b.Property(e => e.Observacao);
                b.HasOne(e => e.EventoPai);
                b.HasOne(e => e.Competicao);
                b.HasMany(e => e.Participantes)
                    .WithOne(e => e.Evento)
                    ;
                b.HasMany(e => e.Agrupamentos)
                    .WithOne(e => e.Evento)
                    ;
                b.Property(e => e.PermiteSubEvento);
                b.Property(e => e.Localizacao);
                b.Property(e => e.Horario);
                b.Property(e => e.Cancelado);
                b.Property(e => e.Processado);
                b.Property(e => e.Tipo)
                    .IsRequired();
            });

            modelBuilder.Entity<Participante>(b =>
            {
                b.ToTable("participante");
                HasBaseEntidade(b, true, true, true);

                b.Property(e => e.Nome);
            });

            modelBuilder.Entity<EventoAgrupamento>(b =>
            {
                b.ToTable("evento_agrupamento");
                HasBaseEntidade(b, true, true, true);

                b.Property(e => e.Ordem);
            });

            modelBuilder.Entity<EventoParticipante>(b =>
            {
                b.ToTable("evento_participante");
                HasBaseEntidade(b, true, true, true);

                //b.HasOne(e => e.Participante);
                //b.HasOne(e => e.Evento);

                b.Property(e => e.Resultado);
            });

            modelBuilder.Entity<PalpiteEvento>(b =>
            {
                b.ToTable("palpite_evento");
                HasBaseEntidade(b, true, true, true);

                b.HasOne(e => e.Evento);

                b.HasMany(e => e.Palpites);
            });

            modelBuilder.Entity<PalpiteParticipante>(b =>
            {
                b.ToTable("palpite_participante");
                HasBaseEntidade(b, true, true, true);

                b.HasOne(e => e.Participante);
                b.HasOne(e => e.Acerto);

                b.Property(e => e.PalpiteValor);
            });

            modelBuilder.Entity<RegraAcerto>(b =>
            {
                b.ToTable("regra_acerto");
                HasBaseEntidade(b, true, true, true);

                b.Property(e => e.Nome);
                b.Property(e => e.Pontos);
            });
        }

        void HasBaseEntidade<TModel>(EntityTypeBuilder<TModel> builder, bool mapCodigo = true, bool mapCreatedOn = true, bool mapUpdateOn = true)
            where TModel : class, IModel
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ObjDesabilitado);
            /////
            // Código
            if (mapCodigo)
            {
                builder.HasIndex(e => e.Codigo)
                    .IsUnique();
                builder.Property(e => e.Codigo)
                    .HasMaxLength(20);
            }
            else
            {
                builder.Ignore(e => e.Codigo);
            }
            // CreatedOn
            if (mapCreatedOn)
            {
                builder.Property(e => e.CreatedOn)
                    //.HasDefaultValue(DateTime.Now)
                    .ValueGeneratedOnAdd();
            }
            else
            {
                builder.Ignore(e => e.CreatedOn);
            }
            /////
            // UpdatedOn
            if (mapUpdateOn)
            {
                builder.Property(e => e.UpdatedOn)
                    //.HasDefaultValue(DateTime.Now)
                    ;
            }
            else
            {
                builder.Ignore(e => e.UpdatedOn);
            }
        }
    }
}
