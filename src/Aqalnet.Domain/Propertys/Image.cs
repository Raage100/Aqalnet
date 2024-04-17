using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Propertys.ValueObjects;

namespace Aqalnet.Domain.Propertys;

public sealed class Image : Entity
{
    public Image(Guid id, Guid propertyId, Url url, Alt alt, Title title, Description description)
        : base(id)
    {
        PropertyId = propertyId;
        Url = url;
        Alt = alt;
        Title = title;
        Description = description;
    }

    public Guid PropertyId { get; set; }
    public Url Url { get; private set; }
    public Alt Alt { get; private set; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }

    public static Image Create(
        Guid id,
        Guid propertyId,
        Url url,
        Alt alt,
        Title title,
        Description description
    )
    {
        return new Image(id, propertyId, url, alt, title, description);
    }

    public Image() { }
}
