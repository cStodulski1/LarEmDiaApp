using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LarEmDia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColunaFinalidadeEmTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Finalidade",
                table: "Transacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finalidade",
                table: "Transacoes");
        }
    }
}
