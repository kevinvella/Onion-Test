using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.Repo.Context.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Item",
                columns: table => new
                {
                    itm_Pk = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    itm_Description = table.Column<string>(maxLength: 150, nullable: false),
                    itm_Guid = table.Column<Guid>(nullable: false),
                    itm_Name = table.Column<string>(maxLength: 50, nullable: false),
                    itm_typ_fk = table.Column<int>(nullable: false),
                    itm_usr_fk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Item", x => x.itm_Pk);
                });

            migrationBuilder.CreateTable(
                name: "tb_Type",
                columns: table => new
                {
                    typ_Pk = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    typ_Guid = table.Column<Guid>(nullable: false),
                    typ_Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Type", x => x.typ_Pk);
                });

            migrationBuilder.CreateTable(
                name: "tb_User",
                columns: table => new
                {
                    usr_Pk = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    usr_Email = table.Column<string>(nullable: false),
                    usr_Firstname = table.Column<string>(nullable: false),
                    usr_Guid = table.Column<Guid>(nullable: false),
                    usr_LastName = table.Column<string>(nullable: false),
                    usr_Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_User", x => x.usr_Pk);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Item");

            migrationBuilder.DropTable(
                name: "tb_Type");

            migrationBuilder.DropTable(
                name: "tb_User");
        }
    }
}
