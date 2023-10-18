using LaboLocation_API.LaboLocation_DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LaboLocation_API.Tools
{
    public class TokenGenerator
    {
        public static string secretKey = "µpiçaezjrkuyjfgk:ghmkjghmiugl:hjfvtFSDMOifnZAE MOVjkµ$)'éàipornjfd ù)'$piç";

        public string GenerateToken(Personne p)
        {
            //Générer la clé de signature du token

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Création du payload (Donnée contenues dans le token)

            Claim[] userInfo = new[]
            {
                new Claim(ClaimTypes.Role,
                        (p.Id_role == 3 ? "Admin" : p.Id_role == 2 ? "Modo" : "User")),
                new Claim(ClaimTypes.Sid, p.Id_personne.ToString()),
                new Claim(ClaimTypes.Email, p.Email)
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                claims: userInfo,
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(1)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}
