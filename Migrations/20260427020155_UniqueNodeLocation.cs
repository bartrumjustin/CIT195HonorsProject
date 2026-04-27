using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIT195HonorsProject.Migrations
{
    /// <inheritdoc />
    public partial class UniqueNodeLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NodeClusters_NodeLocation",
                table: "NodeClusters",
                column: "NodeLocation",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NodeClusters_NodeLocation",
                table: "NodeClusters");
        }
    }
}
