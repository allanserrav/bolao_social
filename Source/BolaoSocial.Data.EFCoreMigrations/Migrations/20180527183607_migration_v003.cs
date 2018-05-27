using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BolaoSocial.Data.EFCoreMigrations.Migrations
{
    public partial class migration_v003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agrupamento_evento_EventoId",
                table: "agrupamento");

            migrationBuilder.DropForeignKey(
                name: "FK_palpite_participante_participante_evento_ParticipanteId",
                table: "palpite_participante");

            migrationBuilder.DropForeignKey(
                name: "FK_participante_evento_evento_EventoId",
                table: "participante_evento");

            migrationBuilder.DropForeignKey(
                name: "FK_participante_evento_participante_ParticipanteId",
                table: "participante_evento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_participante_evento",
                table: "participante_evento");

            migrationBuilder.DropIndex(
                name: "IX_agrupamento_EventoId",
                table: "agrupamento");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "agrupamento");

            migrationBuilder.RenameTable(
                name: "participante_evento",
                newName: "evento_participante");

            migrationBuilder.RenameIndex(
                name: "IX_participante_evento_ParticipanteId",
                table: "evento_participante",
                newName: "IX_evento_participante_ParticipanteId");

            migrationBuilder.RenameIndex(
                name: "IX_participante_evento_EventoId",
                table: "evento_participante",
                newName: "IX_evento_participante_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_participante_evento_Codigo",
                table: "evento_participante",
                newName: "IX_evento_participante_Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_evento_participante",
                table: "evento_participante",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "evento_agrupamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgrupamentoId = table.Column<int>(nullable: true),
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventoId = table.Column<int>(nullable: true),
                    ObjDesabilitado = table.Column<bool>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento_agrupamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_evento_agrupamento_agrupamento_AgrupamentoId",
                        column: x => x.AgrupamentoId,
                        principalTable: "agrupamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_evento_agrupamento_evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_evento_agrupamento_AgrupamentoId",
                table: "evento_agrupamento",
                column: "AgrupamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_evento_agrupamento_Codigo",
                table: "evento_agrupamento",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_evento_agrupamento_EventoId",
                table: "evento_agrupamento",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_evento_participante_evento_EventoId",
                table: "evento_participante",
                column: "EventoId",
                principalTable: "evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evento_participante_participante_ParticipanteId",
                table: "evento_participante",
                column: "ParticipanteId",
                principalTable: "participante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_palpite_participante_evento_participante_ParticipanteId",
                table: "palpite_participante",
                column: "ParticipanteId",
                principalTable: "evento_participante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evento_participante_evento_EventoId",
                table: "evento_participante");

            migrationBuilder.DropForeignKey(
                name: "FK_evento_participante_participante_ParticipanteId",
                table: "evento_participante");

            migrationBuilder.DropForeignKey(
                name: "FK_palpite_participante_evento_participante_ParticipanteId",
                table: "palpite_participante");

            migrationBuilder.DropTable(
                name: "evento_agrupamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_evento_participante",
                table: "evento_participante");

            migrationBuilder.RenameTable(
                name: "evento_participante",
                newName: "participante_evento");

            migrationBuilder.RenameIndex(
                name: "IX_evento_participante_ParticipanteId",
                table: "participante_evento",
                newName: "IX_participante_evento_ParticipanteId");

            migrationBuilder.RenameIndex(
                name: "IX_evento_participante_EventoId",
                table: "participante_evento",
                newName: "IX_participante_evento_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_evento_participante_Codigo",
                table: "participante_evento",
                newName: "IX_participante_evento_Codigo");

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "agrupamento",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_participante_evento",
                table: "participante_evento",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_agrupamento_EventoId",
                table: "agrupamento",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_agrupamento_evento_EventoId",
                table: "agrupamento",
                column: "EventoId",
                principalTable: "evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_palpite_participante_participante_evento_ParticipanteId",
                table: "palpite_participante",
                column: "ParticipanteId",
                principalTable: "participante_evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_participante_evento_evento_EventoId",
                table: "participante_evento",
                column: "EventoId",
                principalTable: "evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_participante_evento_participante_ParticipanteId",
                table: "participante_evento",
                column: "ParticipanteId",
                principalTable: "participante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
