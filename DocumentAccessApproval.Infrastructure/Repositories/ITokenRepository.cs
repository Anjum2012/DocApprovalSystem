using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Domain.Entities;

namespace DocumentAccessApproval.Infrastructure.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(UserDto user);
    }
}
