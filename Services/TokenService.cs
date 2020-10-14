using Backend.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class TokenService
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<IdentityUser> _userManager;
        public TokenService(IOptions<AppSettings> appSettings, UserManager<IdentityUser> userManager)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }
        public async Task<string> GenerateToken(IdentityUser user)
        {
            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));
                
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}