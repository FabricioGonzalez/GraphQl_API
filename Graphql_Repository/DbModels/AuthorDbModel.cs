using Domain.Dto;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace Graphql_Repository.DbModels
{
    [Table("Authors")]
    public class AuthorDbModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookDbModel> Books { get; set; }

        public AuthorDbModel()
        {

        }

        public AuthorDbModel(Guid Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public static void Build(ModelBuilder builder)
        {
            builder.Entity<AuthorDbModel>(entity =>
            {
                entity
                .HasKey(e => e.Id);

                entity
                .HasIndex(e => new { e.Name })
                .IsUnique();

                entity.HasMany(book => book.Books)
              .WithOne(author => author.Auhtor);

                entity.ToTable("Authors");
            });
        }
    }

}
