namespace GraphQl_API.Schemas
{
    public class BookAddedPayload
    {
        public string? Title { get; set; }

        public Author? Author { get; set; }
    }
}