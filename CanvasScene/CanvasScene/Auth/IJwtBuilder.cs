using System.Security.Claims;
using System.Threading.Tasks;

namespace CanvasScene.Auth
{
    public interface IJwtBuilder
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);

        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}
