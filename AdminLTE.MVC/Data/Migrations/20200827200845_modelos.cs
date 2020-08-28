using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    CondominioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    FotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.CondominioId);
                });

            migrationBuilder.CreateTable(
                name: "AguaCondominio",
                columns: table => new
                {
                    AguaCondominioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    dt_leitura_atual = table.Column<DateTime>(nullable: false),
                    re_leitura_atual = table.Column<double>(nullable: false),
                    re_valor_atual = table.Column<long>(nullable: false),
                    FotoPath = table.Column<string>(nullable: true),
                    CondominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AguaCondominio", x => x.AguaCondominioId);
                    table.ForeignKey(
                        name: "FK_AguaCondominio_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartamento",
                columns: table => new
                {
                    ApartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    apartamento = table.Column<int>(nullable: false),
                    Bloco = table.Column<string>(nullable: false),
                    CondominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamento", x => x.ApartamentoId);
                    table.ForeignKey(
                        name: "FK_Apartamento_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AguaApartamento",
                columns: table => new
                {
                    AguaApartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    dt_leitura_atual = table.Column<DateTime>(nullable: false),
                    re_leitura_atual = table.Column<double>(nullable: false),
                    re_valor_atual = table.Column<long>(nullable: false),
                    FotoPath = table.Column<string>(nullable: true),
                    ApartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AguaApartamento", x => x.AguaApartamentoId);
                    table.ForeignKey(
                        name: "FK_AguaApartamento_Apartamento_ApartamentoId",
                        column: x => x.ApartamentoId,
                        principalTable: "Apartamento",
                        principalColumn: "ApartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AguaApartamento_ApartamentoId",
                table: "AguaApartamento",
                column: "ApartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AguaCondominio_CondominioId",
                table: "AguaCondominio",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartamento_CondominioId",
                table: "Apartamento",
                column: "CondominioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AguaApartamento");

            migrationBuilder.DropTable(
                name: "AguaCondominio");

            migrationBuilder.DropTable(
                name: "Apartamento");

            migrationBuilder.DropTable(
                name: "Condominio");
        }
    }
}
