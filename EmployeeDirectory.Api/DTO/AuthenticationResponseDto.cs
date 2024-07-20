namespace EmployeeDirectory.Api.DTO;

public class AuthenticationResponseDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}