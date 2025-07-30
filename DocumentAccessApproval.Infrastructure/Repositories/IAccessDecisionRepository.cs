using DocumentAccessApproval.Application.DTO;

namespace DocumentAccessApproval.Infrastructure.Repositories
{
    public interface IAccessDecisionRepository
    {
        Task<IEnumerable<CreateAccessRequestDto>> GetAllPendingRequestsAsync();
        Task<DecisionDto> ApproveRequestAsync(int requestId, DecisionDto approveDto);
        Task<DecisionDto> RejectRequestAsync(int requestId, DecisionDto approveDto);
    }
}
