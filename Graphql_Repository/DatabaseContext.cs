using Graphql_Repository.DbModels;

using Microsoft.EntityFrameworkCore;

namespace Graphql_Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            Task.Run(async () =>
            {
                await Database.MigrateAsync();
            });

            optionsBuilder.UseNpgsql("User ID=kaskin;Password=kaskin@2022;Host=192.168.1.184;Port=5432;Database=graphql;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BookDbModel.Build(modelBuilder);
            AuthorDbModel.Build(modelBuilder);

        }
    }
}