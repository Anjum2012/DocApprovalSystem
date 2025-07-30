using AutoMapper;
using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Domain.Entities;
using DocumentAccessApproval.Domain.Enums;
using DocumentAccessApproval.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApproval.Infrastructure.Repositories
{
    public class AccessDecisionRepository: IAccessDecisionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AccessDecisionRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CreateAccessRequestDto>> GetAllPendingRequestsAsync()
        {
            var getallpendingrequest = await _context.AccessRequests
                                        .Include(ar => ar.RequestorUser)
                                        .Include(ar => ar.Document)
                                        .Where(ar => ar.Status == AccessStatus.Pending)
                                        .OrderBy(ar => ar.CreatedAt).AsNoTracking()
                                        .ToListAsync();
            return _mapper.Map<List<CreateAccessRequestDto>>(getallpendingrequest);
        }

        public async Task<DecisionDto> ApproveRequestAsync(int requestId, DecisionDto approveDto)
        {
            _mapper.Map<AccessRequest>(approveDto);
            var existingrequest = await _context.AccessRequests.FirstOrDefaultAsync(u => u.Id == requestId);
            if (existingrequest == null)
            {
                return null;
            }
            // Update the access request status
            existingrequest.Status = AccessStatus.Approved;
            existingrequest.UpdatedAt = DateTime.UtcNow;
            existingrequest.ApproverComment = approveDto.ApproverComment;
            existingrequest.ApproverUserId = approveDto.ApproverUserId;
            await _context.SaveChangesAsync();
            return _mapper.Map<DecisionDto>(existingrequest);
        }

        public async Task<DecisionDto> RejectRequestAsync(int requestId, DecisionDto rejectDto)
        {
            _mapper.Map<AccessRequest>(rejectDto);
            var existingrequest = await _context.AccessRequests.FirstOrDefaultAsync(u => u.Id == requestId);
            if (existingrequest == null)
            {
                return null;
            }
            // Update the access request status
            existingrequest.Status = AccessStatus.Rejected;
            existingrequest.UpdatedAt = DateTime.UtcNow;
            existingrequest.ApproverComment = rejectDto.ApproverComment;
            existingrequest.ApproverUserId = rejectDto.ApproverUserId;
            await _context.SaveChangesAsync();
            return _mapper.Map<DecisionDto>(existingrequest);
        }
    }
}
