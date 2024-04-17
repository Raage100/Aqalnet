namespace Aqalnet.Application.Propertys.GetAllProperties;

public class UserResponse
{
    public Guid Id { get; set; }
    public DateOnly CreatedAt { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }

    public string ProfilePicture { get; set; }
}
