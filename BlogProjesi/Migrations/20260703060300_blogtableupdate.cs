using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProjesi.Migrations
{
    /// <inheritdoc />
    public partial class blogtableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Blogs");
        }
    }
}
