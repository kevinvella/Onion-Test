using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCore.Repo.Context;

namespace EFCore.Repo.Context.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170515195711_NewDatabaseTables")]
    partial class NewDatabaseTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.Data.Models.tb_File", b =>
                {
                    b.Property<int>("fl_Pk")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("fl_Description")
                        .HasMaxLength(300);

                    b.Property<Guid>("fl_Guid");

                    b.Property<bool>("fl_IsPrimary");

                    b.Property<string>("fl_Name")
                        .HasMaxLength(100);

                    b.Property<string>("fl_Path")
                        .HasMaxLength(1000);

                    b.Property<int>("fl_ftyp_fk");

                    b.HasKey("fl_Pk");

                    b.ToTable("tb_File");
                });

            modelBuilder.Entity("EFCore.Data.Models.tb_FileType", b =>
                {
                    b.Property<int>("ftyp_Pk")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ftyp_Guid");

                    b.Property<string>("ftyp_Type")
                        .HasMaxLength(50);

                    b.HasKey("ftyp_Pk");

                    b.ToTable("tb_FileType");
                });

            modelBuilder.Entity("EFCore.Data.Models.tb_Item", b =>
                {
                    b.Property<int>("itm_Pk")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("itm_Description")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<Guid>("itm_Guid");

                    b.Property<string>("itm_Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("itm_typ_fk");

                    b.Property<int>("itm_usr_fk");

                    b.HasKey("itm_Pk");

                    b.ToTable("tb_Item");
                });

            modelBuilder.Entity("EFCore.Data.Models.tb_Type", b =>
                {
                    b.Property<int>("typ_Pk")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("typ_Guid");

                    b.Property<string>("typ_Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("typ_Pk");

                    b.ToTable("tb_Type");
                });

            modelBuilder.Entity("EFCore.Data.Models.tb_User", b =>
                {
                    b.Property<int>("usr_Pk")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("usr_Email")
                        .IsRequired();

                    b.Property<string>("usr_Firstname")
                        .IsRequired();

                    b.Property<Guid>("usr_Guid");

                    b.Property<string>("usr_LastName")
                        .IsRequired();

                    b.Property<string>("usr_Password")
                        .IsRequired();

                    b.HasKey("usr_Pk");

                    b.ToTable("tb_User");
                });
        }
    }
}
