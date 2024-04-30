
namespace JwtOnRazorPages;

public interface ITokenService
{
    string GenerateJwtToken(string username, IConfiguration configuration);
}