using ProductManagement.DTOs;
using ProductManagement.Model;

namespace ProductManagement.Service
{
    public interface IAuthService
    {
        void Register(UserRegistrationRequestDTO dto);
        User Login(LoginRequestDTO dto);
    }
}
