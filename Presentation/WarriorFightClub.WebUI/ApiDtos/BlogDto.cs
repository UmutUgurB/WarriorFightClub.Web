using System.Text.Json.Serialization;

public sealed class BlogDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public string ImageUrl { get; set; } = default!;

    [JsonPropertyName("categoryName")]
    public string CategoryTitle { get; set; } = default!;

    public DateTime CreatedDate { get; set; }
}
