using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Contracts;

public interface ITokenService
{
    string CreateToken(AppUser user);
}