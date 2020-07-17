using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ponto.Data.Migrations.PontoDB
{
    public partial class Funcionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 250, nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(250)", nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    IE = table.Column<string>(maxLength: 14, nullable: true),
                    IM = table.Column<string>(maxLength: 14, nullable: true),
                    RamoAtividade = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoEmpresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 250, nullable: true),
                    Numero = table.Column<string>(maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(maxLength: 500, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 10, nullable: true),
                    Pais = table.Column<string>(maxLength: 50, nullable: true),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoEmpresa_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeCompleto = table.Column<string>(maxLength: 150, nullable: false),
                    Apelido = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Funcao = table.Column<string>(nullable: true),
                    HorarioEntrada = table.Column<DateTime>(nullable: false),
                    HorarioSaida = table.Column<DateTime>(nullable: false),
                    FormaContratacao = table.Column<string>(nullable: true),
                    FotoData = table.Column<byte[]>(nullable: true),
                    FotoFilename = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEmpresa_EmpresaId",
                table: "EnderecoEmpresa",
                column: "EmpresaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmpresaId",
                table: "Funcionarios",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoEmpresa");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
