using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BolaoSocial.Data.EFCoreMigrations.Migrations
{
    public partial class migration_v004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "evento");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "evento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "evento");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "evento",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
