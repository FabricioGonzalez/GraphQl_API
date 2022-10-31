using HotChocolate.Subscriptions;

namespace GraphQl_API.Mutations
{
    public class BookMutations
    {
        public async Task<BookAddedPayload> AddBook(Book book, [Service] ITopicEventSender sender)
        {
            // Omitted code for brevity

            await sender.SendAsync("ExampleTopic", book);

            return new()
            {
                Title = book.Title,
                Author = book.Author,
            };
        }
    }
}
