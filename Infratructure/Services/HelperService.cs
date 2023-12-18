using Application.Abstraction;
using Application.AppModel;
using Application.HttpModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure.Services
{
    public class HelperService : IHelperService
    {
        
        private readonly List<GameOperation> gameOperations = new List<GameOperation>() { new GameOperation { Id = 1, Operation = (objects) => Console.WriteLine(objects[1]) } };

        public Game CreateGame(List<GameObject> gameObjects, string name)
        {
            var game = Fabrics.Fabrics.CreateGame(name, gameObjects, gameOperations);
            Fabrics.Fabrics.games.Add(game);
            return game;
        }

        public string GetToket(AuthPlayer authPlayer)
        {
            var game = Fabrics.Fabrics.games.FirstOrDefault(g => g.Id == authPlayer.IdGame);
            if (game == default)
            {
                return string.Empty;
            }

            var identity = GetIdentity(game.GameObjects, authPlayer);

            var playerExist = game.GameObjects.Exists(p => p.Id == authPlayer.IdObject);

            if (!playerExist)
            {
                return string.Empty;
            }

            var jwt = new JwtSecurityToken(
                   issuer: AuthOptions.ISSUER,
                   audience: AuthOptions.AUDIENCE,
                   notBefore: DateTime.UtcNow,
                   claims: identity.Claims,
                   expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                   signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private ClaimsIdentity GetIdentity(List<GameObject> GameObjects, AuthPlayer authPlayer)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, GameObjects.FirstOrDefault(p => p.Id == authPlayer.IdObject).ToString()),
            };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, 
                "Token", 
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}
