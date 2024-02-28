using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public sealed class Image : Entity
{
    public Image(Guid id, Guid propertyId, string url, string alt, string title, string description)
        : base(id)
    {
        PropertyId = propertyId;
        Url = url;
        Alt = alt;
        Title = title;
        Description = description;
    }

    public Guid PropertyId { get; set; }
    public string Url { get; private set; }
    public string Alt { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public static Image Create(
        Guid id,
        Guid propertyId,
        string url,
        string alt,
        string title,
        string description
    )
    {
        return new Image(id, propertyId, url, alt, title, description);
    }

    public Image() { }
}
