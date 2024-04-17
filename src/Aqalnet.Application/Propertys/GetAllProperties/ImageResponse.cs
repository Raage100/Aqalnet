using Newtonsoft.Json;

namespace Aqalnet.Application.Propertys.GetAllProperties;

public class ImageResponse
{
    public Guid Id { get; set; }

    public Guid PropertyId { get; set; }

    public string Alt { get; set; }

    public string Description { get; set; }

    public string Title { get; set; }

    public string Url { get; set; }
}
