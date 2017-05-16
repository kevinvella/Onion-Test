using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.Repo.Context.Migrations
{
    public partial class NewDatabaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_File",
                columns: table => new
                {
                    fl_Pk = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fl_Description = table.Column<string>(maxLength: 300, nullable: true),
                    fl_Guid = table.Column<Guid>(nullable: false),
                    fl_IsPrimary = table.Column<bool>(nullable: false),
                    fl_Name = table.Column<string>(maxLength: 100, nullable: true),
                    fl_Path = table.Column<string>(maxLength: 1000, nullable: true),
                    fl_ftyp_fk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_File", x => x.fl_Pk);
                });

            migrationBuilder.CreateTable(
                name: "tb_FileType",
                columns: table => new
                {
                    ftyp_Pk = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ftyp_Guid = table.Column<Guid>(nullable: false),
                    ftyp_Type = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_FileType", x => x.ftyp_Pk);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_File");

            migrationBuilder.DropTable(
                name: "tb_FileType");
        }
    }
}
