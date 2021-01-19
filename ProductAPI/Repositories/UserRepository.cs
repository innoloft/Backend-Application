namespace ProductAPI.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ProductAPI.Interfaces;
    using ProductAPI.Models;

    public class UserRepository : IUserRepository
    {
        private readonly ProductDBContext dbContext;

        public UserRepository(ProductDBContext injectedDbContext)
        {
            dbContext = injectedDbContext;
        }

        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            return await dbContext.Users.Where(u => u.username == userName)
                                        .FirstOrDefaultAsync();
        }
    }
}