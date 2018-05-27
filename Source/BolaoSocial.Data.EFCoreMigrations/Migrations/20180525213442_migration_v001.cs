using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BolaoSocial.Data.EFCoreMigrations.Migrations
{
    public partial class migration_v001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "competicao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventoTipo = table.Column<byte>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "participante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "regra_acerto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    Pontos = table.Column<decimal>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regra_acerto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    SegundosLoginExpirar = table.Column<int>(nullable: false),
                    Senha = table.Column<string>(maxLength: 10, nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "evento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cancelado = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CompeticaoId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventoPaiId = table.Column<int>(nullable: true),
                    Horario = table.Column<DateTime>(nullable: false),
                    Localizacao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    PermiteSubEvento = table.Column<bool>(nullable: false),
                    Processado = table.Column<bool>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_evento_competicao_CompeticaoId",
                        column: x => x.CompeticaoId,
                        principalTable: "competicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_evento_evento_EventoPaiId",
                        column: x => x.EventoPaiId,
                        principalTable: "evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "agrupamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventoId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agrupamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_agrupamento_evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "palpite_evento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventoId = table.Column<int>(nullable: true),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_palpite_evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_palpite_evento_evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "participante_evento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventoId = table.Column<int>(nullable: true),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    ParticipanteId = table.Column<int>(nullable: true),
                    Resultado = table.Column<decimal>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participante_evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_participante_evento_evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_participante_evento_participante_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "participante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "palpite_participante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcertoId = table.Column<int>(nullable: true),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    PalpiteEventoId = table.Column<int>(nullable: true),
                    PalpiteValor = table.Column<decimal>(nullable: false),
                    ParticipanteId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_palpite_participante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_palpite_participante_regra_acerto_AcertoId",
                        column: x => x.AcertoId,
                        principalTable: "regra_acerto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_palpite_participante_palpite_evento_PalpiteEventoId",
                        column: x => x.PalpiteEventoId,
                        principalTable: "palpite_evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_palpite_participante_participante_evento_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "participante_evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agrupamento_Codigo",
                table: "agrupamento",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_agrupamento_EventoId",
                table: "agrupamento",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_competicao_Codigo",
                table: "competicao",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_evento_Codigo",
                table: "evento",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_evento_CompeticaoId",
                table: "evento",
                column: "CompeticaoId");

            migrationBuilder.CreateIndex(
                name: "IX_evento_EventoPaiId",
                table: "evento",
                column: "EventoPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_palpite_evento_Codigo",
                table: "palpite_evento",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_palpite_evento_EventoId",
                table: "palpite_evento",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_palpite_participante_AcertoId",
                table: "palpite_participante",
                column: "AcertoId");

            migrationBuilder.CreateIndex(
                name: "IX_palpite_participante_Codigo",
                table: "palpite_participante",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_palpite_participante_PalpiteEventoId",
                table: "palpite_participante",
                column: "PalpiteEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_palpite_participante_ParticipanteId",
                table: "palpite_participante",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_participante_Codigo",
                table: "participante",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_participante_evento_Codigo",
                table: "participante_evento",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_participante_evento_EventoId",
                table: "participante_evento",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_participante_evento_ParticipanteId",
                table: "participante_evento",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_regra_acerto_Codigo",
                table: "regra_acerto",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Codigo",
                table: "usuario",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agrupamento");

            migrationBuilder.DropTable(
                name: "palpite_participante");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "regra_acerto");

            migrationBuilder.DropTable(
                name: "palpite_evento");

            migrationBuilder.DropTable(
                name: "participante_evento");

            migrationBuilder.DropTable(
                name: "evento");

            migrationBuilder.DropTable(
                name: "participante");

            migrationBuilder.DropTable(
                name: "competicao");
        }
    }
}
