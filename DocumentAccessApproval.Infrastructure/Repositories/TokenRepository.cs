using AutoMapper;
using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Domain.Enums;
using DocumentAccessApproval.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocumentAccessApproval.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TokenRepository(IConfiguration configuration, ApplicationDbContext context, IMapper mapper)
        {
            this.configuration = configuration;
            _context = context;
            _mapper = mapper;
        }


        public string CreateJWTToken(UserDto user)
        {
            var userContext = _context.Users.FirstOrDefault(x => x.Id == user.id);
            if (userContext.Role == (UserRole)user.Role)
            {
                // Create claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role.ToString())  // e.g. "Admin"
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return "Incorrect Role or UserId";
        }
    }
}
