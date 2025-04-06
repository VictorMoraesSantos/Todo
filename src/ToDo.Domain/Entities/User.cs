using Microsoft.AspNetCore.Identity;

namespace ToDo.Domain.Entities
{
    public class User : IdentityUser
    {
        public User(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            NormalizedEmail = email.ToUpper();
            EmailConfirmed = true;
        }
        public User() { }

        public void Update(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            NormalizedEmail = email.ToUpper();
        }
    }
}
