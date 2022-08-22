using freelanceProject.DTO;
using freelanceProject.Model;
using freelanceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace freelanceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private IAuthRepository authRepository;

        public AccountController
            (UserManager<User> userManager, SignInManager<User> signInManager,IAuthRepository authRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authRepository = authRepository;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserName = registerDto.Username;
                user.PasswordHash = registerDto.Password;

                IdentityResult result = await userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                    IdentityResult roleresult = await userManager.AddToRoleAsync(user,"User");
                    return Ok(authRepository.GetToken(user,""));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return BadRequest();
        }


        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(loginDto.Username);
                if (user != null)
                {
                    bool Pass = await userManager.CheckPasswordAsync(user, loginDto.Password);
                    if (Pass)
                    {
                        var userRoles = await userManager.GetRolesAsync(user);

                        var result = authRepository.GetToken(user, userRoles[0]);
                        this.Response.Headers.Append("Authenticate", result.Token);
                        this.Response.Cookies.Append("SESSIONID", result.Token);

                        return Ok(result);

                    }
                }
                ModelState.AddModelError("", "Username or Password are invalid ");
            }
            return Unauthorized();
        }


    }
}
