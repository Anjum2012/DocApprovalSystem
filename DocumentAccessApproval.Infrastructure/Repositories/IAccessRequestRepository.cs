using DocumentAccessApproval.Application.DTO;

namespace DocumentAccessApproval.Application.Repositories
{
    public interface IAccessRequestRepository
    {
        Task<CreateAccessRequestDto> CreateAccessRequestAsync(CreateAccessRequestDto request);
        Task<IEnumerable<AccessRequestDto>> GetAllAccessIdByUserId(int userid);
    }
}
