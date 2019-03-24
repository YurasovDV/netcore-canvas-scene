using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CanvasScene.AppServices;
using CanvasScene.Auth;
using CanvasScene.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CanvasScene.Controllers
{
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IJwtBuilder _jwtBuilder;
        private readonly JwtIssuerOptions _jwtOptions;

        public AccountController(IFiguresService figuresService, 
            UserManager<AppUser> userManager, 
            IJwtBuilder jwtBuilder, IOptions<JwtIssuerOptions> jwtOptions) : base(figuresService, userManager)
        {
            _jwtBuilder = jwtBuilder;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationVM regData)
        {
            var appUser = new AppUser()
            {
                LastLogin = null,
                UserName = regData.Login,
            };

            var result = await _userManager.CreateAsync(appUser, regData.Password);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult("Ошибка сохранения");
            }

            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]RegistrationVM loginData)
        {
            var identity = await GetClaimsIdentity(loginData.Login, loginData.Password);
            if (identity == null)
            {
                return BadRequest("ошибка аутентификации");
            }

            var jwt = await GenerateJwt(identity, 
                _jwtBuilder,
                loginData.Login, _jwtOptions, 
                new JsonSerializerSettings { Formatting = Formatting.Indented });
            return Ok(jwt);
        }


        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var userToVerify = await _userManager.FindByNameAsync(userName);

                if (userToVerify != null)
                {
                    bool passwordCorrect = await _userManager.CheckPasswordAsync(userToVerify, password);
                    if (passwordCorrect)
                    {
                        return await Task.FromResult(_jwtBuilder.GenerateClaimsIdentity(userName, userToVerify.Id));
                    }
                }
            }

            return await Task.FromResult<ClaimsIdentity>(null);
        }

        public static async Task<string> GenerateJwt(ClaimsIdentity identity,
            IJwtBuilder jwtBuilder,
            string userName,
            JwtIssuerOptions jwtOptions,
            JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                auth_token = await jwtBuilder.GenerateEncodedToken(userName, identity),
                expires_in = (int)jwtOptions.ValidFor.TotalSeconds
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }
    }
}
