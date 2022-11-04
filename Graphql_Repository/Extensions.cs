using Domain.Dto;

using Graphql_Repository.DbModels;
namespace Graphql_Repository
{
    public static class Extensions
    {
        public static AuthorDbModel toDbModel(this AuthorDto author)
        {
            return new AuthorDbModel(
                Id: Guid.Parse(author.Id),
                Name: author.Name
                );
        }
        public static BookDbModel toDbModel(this BookDto book)
        {
            return new BookDbModel(
                id: Guid.Parse(book.Id),
                title: book.Title,
                auhtor: book.Author.toDbModel()
                );
        }

        public static AuthorDto toDto(this AuthorDbModel author)
        {
            return new AuthorDto(
                id: author.Id.ToString(),
                name: author.Name
                );
        }
        public static BookDto toDto(this BookDbModel book)
        {
            return new BookDto(
                id: book.Id.ToString(),
                title: book.Title,
                author: book.Auhtor.toDto()
                );
        }

    }
}
