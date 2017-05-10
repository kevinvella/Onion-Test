using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCore.Repo.Context;

namespace EFCore.Repo.Context.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
