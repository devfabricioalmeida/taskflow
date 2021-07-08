using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskFlow.GerencimentoTarefas.Infrastructure.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resposaveis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_resposaveis", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tarefa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(type: "VARCHAR(300)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "VARCHAR(500)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_previsao_entrega = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    responsavel_id = table.Column<int>(type: "int", nullable: true),
                    prioridade = table.Column<int>(type: "int", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tarefa", x => x.id);
                    table.ForeignKey(
                        name: "fk_tarefa_resposaveis_responsavel_id",
                        column: x => x.responsavel_id,
                        principalTable: "resposaveis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "interacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    tarefa_id = table.Column<int>(type: "int", nullable: false),
                    conteudo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interacoes", x => x.id);
                    table.ForeignKey(
                        name: "fk_interacoes_tarefas_tarefa_id",
                        column: x => x.tarefa_id,
                        principalTable: "tarefa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_interacoes_tarefa_id",
                table: "interacoes",
                column: "tarefa_id");

            migrationBuilder.CreateIndex(
                name: "ix_tarefa_responsavel_id",
                table: "tarefa",
                column: "responsavel_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "interacoes");

            migrationBuilder.DropTable(
                name: "tarefa");

            migrationBuilder.DropTable(
                name: "resposaveis");
        }
    }
}
