using EFCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore.Repo.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        DbSet<tb_User> tb_User { get; set; }
        DbSet<tb_Item> tb_Item { get; set; }
        DbSet<tb_Type> tb_Type { get; set; }

        DbSet<tb_File> tb_File { get; set; }
        DbSet<tb_FileType> tb_FileType { get; set; }
    }
}
