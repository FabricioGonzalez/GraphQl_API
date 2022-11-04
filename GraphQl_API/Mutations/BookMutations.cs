using GraphQl_API.Schemas;

using Graphql_Repository.Repository;

using HotChocolate.Subscriptions;

namespace GraphQl_API.Mutations
{
    public class BookMutations
    {
        BookOperations bookOperations;
        public BookMutations(BookOperations bookOperation)
        {
            bookOperations = bookOperation;
        }
        public async Task<BookAddedPayload> AddBook(Book book, [Service] ITopicEventSender sender)
        {
            // Omitted code for brevity

            await sender.SendAsync("ExampleTopic", book);

            await bookOperations.AddBook(book.toDto());

            return new()
            {
                Title = book.Title,
                Author = book.Author,
            };
        }
    }
}
