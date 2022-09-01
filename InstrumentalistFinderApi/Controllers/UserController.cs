using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentalistFinderApi.Data;
using InstrumentalistFinderApi.Models;
using InstrumentalistFinderApi.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentalistFinderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("GetUsers")]
        public async Task<IEnumerable<GetUserResponse>> GetAllUsers()
        {
           var users =  await  userRepository.GetAllUsers();
            var GetAllUsersResponse = new List<GetUserResponse>();
            foreach (var user in users)
            {
                var newUserResponse = new GetUserResponse()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,

                };
                GetAllUsersResponse.Add(newUserResponse);       

            }
            return GetAllUsersResponse;
            
        }
        [HttpGet("GetUserById{id:int}")]
        public async Task<GetUserResponse> GetUser(string id)
        {
           var user =  await userRepository.GetUserById(id);
            GetUserResponse userResponse = new GetUserResponse()
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return userResponse;
        }
    }
}
