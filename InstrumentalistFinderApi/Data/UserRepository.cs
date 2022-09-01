using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentalistFinderApi.Models;
using InstrumentalistFinderApi.ResponseDtos;
using Microsoft.EntityFrameworkCore;

namespace InstrumentalistFinderApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {

           return  await appDbContext.Users.ToListAsync();
            
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
           return await appDbContext.Users.FirstAsync(x => x.Id == id);     
        }
    }
}
