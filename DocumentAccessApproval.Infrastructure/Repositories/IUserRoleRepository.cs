using DocumentAccessApproval.Application.DTO;

namespace DocumentAccessApproval.Infrastructure.Repositories
{
    public interface IUserRoleRepository
    {
        Task<UserDto> AssignRole(UserDto userDto);
    }
}
