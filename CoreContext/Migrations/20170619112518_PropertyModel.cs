using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreContext.Migrations
{
    public partial class PropertyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedUserId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    ModifiedUserId = table.Column<Guid>(nullable: false),
                    NumberOfBedrooms = table.Column<int>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    PhysicalAddressId = table.Column<Guid>(nullable: true),
                    PostalAddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Address_PhysicalAddressId",
                        column: x => x.PhysicalAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_Address_PostalAddressId",
                        column: x => x.PostalAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_OwnerId",
                table: "Property",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PhysicalAddressId",
                table: "Property",
                column: "PhysicalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PostalAddressId",
                table: "Property",
                column: "PostalAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
