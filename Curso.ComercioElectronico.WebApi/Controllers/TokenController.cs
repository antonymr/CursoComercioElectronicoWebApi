using Curso.ComercioElectronico.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly JwtConfiguration jwtConfiguration;
    public TokenController(IOptions<JwtConfiguration> options)
    {
        this.jwtConfiguration = options.Value;
    }
    [HttpPost]
    public async Task<string> TokenAsync(UserInput input)
    {
        //1. Validar User.
        var users = new[] { 
            new {Nombre= "Antony", Roles= new[] {"Admin"}, TieneLicencia= true, Ecuatoriano= true, Seguro="0987654321" },
            new {Nombre= "Alex", Roles= new[] {"Consulta", "Soporte"}, TieneLicencia= false, Ecuatoriano= true, Seguro="1092837465" },
            new {Nombre= "Pat", Roles= new[] {"Contabilidad", "Facturacion"}, TieneLicencia= true, Ecuatoriano= false, Seguro="7890654321" }
        };
        if (!users.Any(x => x.Nombre.Equals(input.UserName)) || input.Password != "123")
        {
            throw new AuthenticationException("User or Passowrd incorrect!");
        }
        //2. Generar claims
        //create claims details based on the user information
        var claims = new List<Claim>();

        var user = users.Single(x => x.Nombre.Equals(input.UserName));

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Nombre));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));
        claims.Add(new Claim("UserName", user.Nombre));

        foreach (var item in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, item));
        }

        claims.Add(new Claim("TieneLicencia", user.TieneLicencia.ToString()));
        claims.Add(new Claim("Ecuatoriano", user.Ecuatoriano.ToString()));
        claims.Add(new Claim("Seguro", user.Seguro));



        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new JwtSecurityToken(
            jwtConfiguration.Issuer,
            jwtConfiguration.Audience,
            claims,
            expires: DateTime.UtcNow.Add(jwtConfiguration.Expires),
            signingCredentials: signIn);

        var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        return jwt;
    }

}
public class UserInput
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}