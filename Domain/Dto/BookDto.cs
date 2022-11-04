namespace Domain.Dto
{
    public class BookDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public AuthorDto Author { get; set; }
        public BookDto(string id, string title, AuthorDto author)
        {
            Id = id;
            Title = title;
            Author = author;
        }
    }
}
