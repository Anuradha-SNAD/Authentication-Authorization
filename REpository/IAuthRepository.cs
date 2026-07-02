using ProductManagement.DTOs;
using ProductManagement.Model;

namespace ProductManagement.Repository
{
    public interface IAuthRepository
    {
        void Register(UserRegistrationRequestDTO dto);
        User Login(LoginRequestDTO dto);
    }
}
