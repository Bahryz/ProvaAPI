using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aluno2.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoRequisicoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_folhas_Funcionarios_FuncionarioFolhaFuncionarioId",
                table: "folhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "funcionarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_funcionarios",
                table: "funcionarios",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_folhas_funcionarios_FuncionarioFolhaFuncionarioId",
                table: "folhas",
                column: "FuncionarioFolhaFuncionarioId",
                principalTable: "funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_folhas_funcionarios_FuncionarioFolhaFuncionarioId",
                table: "folhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_funcionarios",
                table: "funcionarios");

            migrationBuilder.RenameTable(
                name: "funcionarios",
                newName: "Funcionarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_folhas_Funcionarios_FuncionarioFolhaFuncionarioId",
                table: "folhas",
                column: "FuncionarioFolhaFuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
