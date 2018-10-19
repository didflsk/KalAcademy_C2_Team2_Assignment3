using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventCatalogAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_date_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_location_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogDate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CatalogDateId = table.Column<int>(nullable: false),
                    CatalogLocationId = table.Column<int>(nullable: false),
                    CatalogTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Fee = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogDate_CatalogDateId",
                        column: x => x.CatalogDateId,
                        principalTable: "CatalogDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogLocation_CatalogLocationId",
                        column: x => x.CatalogLocationId,
                        principalTable: "CatalogLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogDateId",
                table: "Catalog",
                column: "CatalogDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogLocationId",
                table: "Catalog",
                column: "CatalogLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                table: "Catalog",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogDate");

            migrationBuilder.DropTable(
                name: "CatalogLocation");

            migrationBuilder.DropTable(
                name: "CatalogType");

            migrationBuilder.DropSequence(
                name: "catalog_date_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_location_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_type_hilo");
        }
    }
}
