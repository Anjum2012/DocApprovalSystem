using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DocumentAccessApproval.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRepository tokenRepository;

        public AuthController(ITokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var jwtToken = tokenRepository.CreateJWTToken(userDto);

            var response = new TokenResponseDto
            {
                JwtToken = jwtToken
            };
            return Ok(response);
        }
    }
}
