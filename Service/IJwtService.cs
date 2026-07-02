using ProductManagement.Model;

namespace ProductManagement.Service
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
