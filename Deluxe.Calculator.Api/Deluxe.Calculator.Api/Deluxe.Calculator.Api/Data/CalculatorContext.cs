using System;
using Microsoft.EntityFrameworkCore;
using Deluxe.Calculator.Api.Models;

namespace Deluxe.Calculator.Api
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            : base(options)
        {

        }

        public DbSet<CalculatorErrors> CalculatorErrors { get; set; }
        public DbSet<CalculatorOperationsStore> CalculatorOperationStore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("There is no connection string configurated...cannot continue");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
