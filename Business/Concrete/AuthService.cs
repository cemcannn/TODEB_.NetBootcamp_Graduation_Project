using Business.Abstract;
using Business.Configuration.Auth;
using Business.Configuration.Helper;
using Business.Configuration.Response;
using DAL.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _distributedCache;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, IDistributedCache distributedCache)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _distributedCache = distributedCache;
        }

        public CommandResponse VerifyPassword(string email, string password)
        {
            var user = _userRepository.GetUserWithPassword(email);

            if (HashHelper.VerifyPasswordHash(password, user.Password.PasswordHash, user.Password.PasswordSalt))
            {
                return new CommandResponse
                {
                    Success = true,
                    Message = "Password is correct"
                };
            }
            return new CommandResponse
            {
                Success = false,
                Message = "Password is incorrect"
            };
        }

        public AccessToken Login(string email, string password)
        {
            #region Token

            var verifyPassword = VerifyPassword(email, password);

            var user = _userRepository.Get(x => x.Email == email);

            if (verifyPassword.Success)
            {
                var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOption>();

                var expireDate = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.Name),
                    new Claim(ClaimTypes.Role,user.Role.ToString()),
                    new Claim("PermissionCache",StringHelper.CreateCacheKey(user.Name,user.Id))
                };

                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
                var jwtToken = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    claims: claims,
                    expires: expireDate,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                );

                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                #endregion

                #region Cache

                _distributedCache.SetString($"USR_{user.Id}", token);

                #endregion
                return new AccessToken()
                {
                    Token = token,
                    ExpireDate = expireDate
                };
            }

            return new AccessToken()
            {

            };
        }
    }
}

