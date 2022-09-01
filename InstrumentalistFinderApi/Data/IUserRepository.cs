using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentalistFinderApi.Models;

namespace InstrumentalistFinderApi.Data
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserById(string id);
    }
}
