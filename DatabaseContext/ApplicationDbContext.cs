using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PersonalBudgetNabiullin.Entities;

namespace PersonalBudgetNabiullin.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TransactionEntity> Transactions { get; set; } = null!;
        public ApplicationDbContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.Current.AppDataDirectory, "PersonalBudgetDb.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
