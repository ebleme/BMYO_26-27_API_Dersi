using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H05_SqlConnection.Migrations
{
    /// <inheritdoc />
    public partial class addedOkParamToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ok",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ok",
                table: "Books");
        }
    }
}
