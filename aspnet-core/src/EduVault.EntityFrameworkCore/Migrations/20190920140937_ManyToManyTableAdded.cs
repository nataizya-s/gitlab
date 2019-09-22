using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduVault.Migrations
{
    public partial class ManyToManyTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AbpTenants_TenantId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AbpTenants_TenantId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_TenantId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_TenantId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Addresses");

            migrationBuilder.CreateTable(
                name: "TenantAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantAddresses_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ContactId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantContacts_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantAddresses_AddressId",
                table: "TenantAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantAddresses_TenantId",
                table: "TenantAddresses",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantContacts_ContactId",
                table: "TenantContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantContacts_TenantId",
                table: "TenantContacts",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantAddresses");

            migrationBuilder.DropTable(
                name: "TenantContacts");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TenantId",
                table: "Contacts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TenantId",
                table: "Addresses",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AbpTenants_TenantId",
                table: "Addresses",
                column: "TenantId",
                principalTable: "AbpTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AbpTenants_TenantId",
                table: "Contacts",
                column: "TenantId",
                principalTable: "AbpTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
