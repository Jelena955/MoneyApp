using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Currencys> Currencys { get; set; }
        public DbSet<MoneyOnAccounts> MoneyOnAccounts { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<TraceObjects> TraceObjects { get; set; }
        public DbSet<Use_Cases> UseCases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_UseCase> UserUseCases { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PaymentCategory> PaymentCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Localhost;Initial Catalog=BaseMoneyApp;Integrated Security=True;MultipleActiveResultSets=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Accounts>()
                .HasOne(a => a.User)
                .WithOne(b => b.Account)
                .HasForeignKey<Accounts>(b => b.Id_User);

            modelBuilder.Entity<Use_Cases>().HasKey(x => x.IdUseCase).HasName("PKUseCase");


            //Adding restriction to every deletion
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());

                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }


            modelBuilder.ApplyConfiguration(new AccountsConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new MoneyOnAccountConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentsConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TraceObjectConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserUseCaseConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentCategoryConfiguration());


            modelBuilder.Entity<Accounts>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Currencys>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<MoneyOnAccounts>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Payments>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PaymentType>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<TraceObjects>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Use_Cases>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<User_UseCase>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PaymentCategory>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Use_Cases>().Property(x => x.IdUseCase).ValueGeneratedNever();
        
        
        
        }


        public override int SaveChanges()
        {
            foreach (var obj in ChangeTracker.Entries())
            {
                if (obj.Entity is EntityBase entitet)
                {
                    switch (obj.State)
                    {
                        case EntityState.Added:
                            entitet.Date_Deleted = null;
                            entitet.Date_Created = DateTime.UtcNow;
                            entitet.IsDeleted = false;
                            entitet.Date_Updated = null;
                            break;
                        case EntityState.Modified:
                            entitet.Date_Updated = DateTime.UtcNow;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

    }
}
