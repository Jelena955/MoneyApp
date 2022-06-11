using Application.Core;
using Application.CustomExceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json;

namespace MoneyApp.Core
{
    public class JwtGenerator
    {
        private readonly Context context;
        private readonly string issuer;
        private readonly string secretKey;
        private readonly IPasswordEncryptor passwordEncryptor;


        public JwtGenerator(Context context,IPasswordEncryptor passwordEncryptor)
        {
            this.issuer = JwtConfig.JWTIssuer;
            this.secretKey = JwtConfig.SecretKey;
            this.context = context;
            this.passwordEncryptor = passwordEncryptor;
        }

        public List<string> MakeToken(string username, string password)
        {
            var encPass = passwordEncryptor.HashPassword(password);
            var actorr = this.context.Users.Where(x => (x.Username == username && x.Password == encPass)).Select(x => new JwtUser()
            {
                AllowedActions = x.UseCases.Select(x => x.UseCaseID).ToList(),
                Identity = x.Name + " " + x.LastName,
                Id = x.Id
            });

            if (actorr.Count() != 1)
            {
                throw new UserNotFoundException("User does not exist with the given credentials");
            }
            var actor = actorr.First();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, this.issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, this.issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, this.issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, this.issuer),
                new Claim("Identity", actor.Identity, ClaimValueTypes.String, this.issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.AllowedActions), ClaimValueTypes.String, this.issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: this.issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddHours(2),
                signingCredentials: credentials);

            var firstStringToReturn = new JwtSecurityTokenHandler().WriteToken(token);
            var secondStringToReturn = actor.Id.ToString();
            return new List<string>() { firstStringToReturn, secondStringToReturn };
        }

    }
}
