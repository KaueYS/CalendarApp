using Blog.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        // Cria manipulador de token do EntityFramework
        // Cria a chave em caracteres ASCII buscando o codigo no JWTKEY - predefinido na configurationJWT
        // Cria um encriptador de token do EF e define tempo para expirar
        // Cria o token final, uisando as classes. obtido pelo EF ( tokenManipulador e token encriptador)
        // retorna o tokenManipulador passando o codigo "escrito" que esta no "token"
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Name, "Kaue"),
                new (ClaimTypes.Role, "Admin"),
                //new ("fruta", "Banana")
            }),

            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
