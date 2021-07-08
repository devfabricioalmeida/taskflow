using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskFlow.GerencimentoTarefas.Infrastructure.Migrations
{
    public partial class alteracao_mapeamento_padrao4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "titulo",
                table: "tarefa",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "titulo",
                table: "tarefa",
                type: "VARCHAR(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)",
                oldMaxLength: 300,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
