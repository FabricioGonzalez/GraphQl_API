using GraphQl_API.Schemas;

using Graphql_Repository.Repository;

namespace GraphQl_API.Queries
{
    public class BookQuery
    {
        BookOperations operations;
        public BookQuery(BookOperations bookOperations)
        {
            operations = bookOperations;
        }
        public async Task<IEnumerable<Book>> GetBook() => (await operations.GetBooks()).Select(book => book.toSchema());
    }
}
