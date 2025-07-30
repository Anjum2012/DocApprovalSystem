using AutoMapper;
using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Application.Repositories;
using DocumentAccessApproval.Domain.Entities;
using DocumentAccessApproval.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApproval.Infrastructure.Repositories
{
    public class AccessRequestRepository : IAccessRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AccessRequestRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateAccessRequestDto> CreateAccessRequestAsync(CreateAccessRequestDto createAccessRequestDto)
        {
            var createAccess = _mapper.Map<AccessRequest>(createAccessRequestDto);
            await _context.AccessRequests.AddAsync(createAccess);
            await _context.SaveChangesAsync();
            var createAccessDto = _mapper.Map<CreateAccessRequestDto>(createAccess);
            return createAccessDto;
        }

        public async Task<IEnumerable<AccessRequestDto>> GetAllAccessIdByUserId(int userid)
        {
            var getallaccessbyuserid = await _context.AccessRequests
                                        .Include(ar => ar.RequestorUser)
                                        .Include(ar => ar.ApproverUser)
                                        .Include(ar => ar.Document)
                                        .OrderBy(ar => ar.UpdatedAt)
                                        .Where(ar => ar.RequestorUserId == userid)
                                        .AsNoTracking()
                                        .ToListAsync();
            return _mapper.Map<List<AccessRequestDto>>(getallaccessbyuserid);
        }
    }
}
