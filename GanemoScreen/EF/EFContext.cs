using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GanemoScreen.Model;
namespace GanemoScreen.EF
{
    public class EFContext: DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ImageEntity> imageEntities { get; set; }
        public EFContext()
        {

        }
        public EFContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = GanemoScreen; Trusted_Connection = True; ConnectRetryCount = 0");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
