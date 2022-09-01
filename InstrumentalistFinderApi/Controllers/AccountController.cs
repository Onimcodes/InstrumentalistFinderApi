using System.Threading.Tasks;
using InstrumentalistFinderApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentalistFinderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, 
                                SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Route("/SignUp")]
        [HttpPost]   
        public async Task<ActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    State = model.State,
                    Street = model.Street,  
                    Age = model.Age,
                    YearsOfExperience = model.YearsOfExperience
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false); 
                   return Ok(result);
                }
                return BadRequest();

             
            }
            return BadRequest(ModelState);  
        }
        [Route("/Login")]
        [HttpPost]
        public async Task<ActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email,model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return Ok(result);   
                }
            }
            return BadRequest(model);
        }
    }
}
