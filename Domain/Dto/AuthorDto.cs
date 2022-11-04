namespace Domain.Dto
{
    public class AuthorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public AuthorDto(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
