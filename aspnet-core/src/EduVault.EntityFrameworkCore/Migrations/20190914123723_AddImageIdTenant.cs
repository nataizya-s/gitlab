using Microsoft.EntityFrameworkCore.Migrations;

namespace EduVault.Migrations
{
    public partial class AddImageIdTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProfilePhotoAttachmentId",
                table: "AbpTenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhotoAttachmentId",
                table: "AbpTenants");
        }
    }
}
