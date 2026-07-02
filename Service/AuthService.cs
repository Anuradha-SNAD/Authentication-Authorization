using ProductManagement.DTOs;
using ProductManagement.Exceptions;
using ProductManagement.Model;
using ProductManagement.Repository;
using System.Security.Authentication;

namespace ProductManagement.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository repository;

        public AuthService(IAuthRepository repository)
        {
            this.repository = repository;
        }

        public User Login(LoginRequestDTO dto)
        {
            var user = repository.Login(dto);
            if(user == null)
            {
                throw new InvalidCredentialsException("Invalid Email or Password");
            }
            return user;
        }

        public void Register(UserRegistrationRequestDTO dto)
        {
            repository.Register(dto);
        }
    }
}
