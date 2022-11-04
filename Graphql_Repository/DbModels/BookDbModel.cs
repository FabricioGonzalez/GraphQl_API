using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace Graphql_Repository.DbModels
{
    [Table("Books")]
    public class BookDbModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public AuthorDbModel Auhtor {get;set;}
        public BookDbModel()
        {

        }

        public BookDbModel(Guid id, string title, AuthorDbModel auhtor)
        {
            Id = id;
            Title = title;
            Auhtor = auhtor;
        }

        public static void Build(ModelBuilder builder)
        {
            builder.Entity<BookDbModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(book => book.Auhtor)
                .WithMany(author => author.Books);

                entity.ToTable("Books");
            });
        }

    }
}
