using ProductManagement.Data;
using ProductManagement.DTOs;
using ProductManagement.Model;

namespace ProductManagement.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext context;

        public AuthRepository(AppDbContext context)
        {
            this.context = context;
        }
        public User Login(LoginRequestDTO dto)
        {
            return context.users.FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);
        }

        public void Register(UserRegistrationRequestDTO dto)
        {
            User u = new User()
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
            };
            context.users.Add(u);
            context.SaveChanges();  
        }
    }
    
}
