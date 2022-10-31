namespace GraphQl_API.Subscriptions
{
    public class BookSubscription
    {
        [Subscribe]
        [Topic("ExampleTopic")]
        public Book BookAdded([EventMessage] Book book) => book;
    }
}
