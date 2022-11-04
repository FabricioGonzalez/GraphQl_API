using Domain.Dto;

using GraphQl_API.Schemas;

namespace GraphQl_API
{
    public static class Extensions
    {
        public static AuthorDto toDto(this Author author)
        {
            return new AuthorDto(
                id: Guid.NewGuid().ToString(),
                name: author.Name
                );
        }
        public static BookDto toDto(this Book book)
        {
            return new BookDto(
                id: Guid.NewGuid().ToString(),
                title: book.Title,
                author: book.Author.toDto()
                );
        }

        public static Author toSchema(this AuthorDto author)
        {
            return new Author()
            {
                Name = author.Name
            };
        }
        public static Book toSchema(this BookDto book)
        {
            return new Book()
            {
                Title = book.Title,
                Author= book.Author.toSchema()
            };
        }
    }
}
