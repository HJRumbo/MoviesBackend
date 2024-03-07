﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInNameOfCategoryIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CatrgotyId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CatrgotyId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CatrgotyId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Movies",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Movies",
                newName: "MyProperty");

            migrationBuilder.AddColumn<int>(
                name: "CatrgotyId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CatrgotyId",
                table: "Movies",
                column: "CatrgotyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CatrgotyId",
                table: "Movies",
                column: "CatrgotyId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
