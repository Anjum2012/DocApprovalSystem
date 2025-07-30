using AutoMapper;
using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Domain.Entities;
using DocumentAccessApproval.Domain.Enums;
using DocumentAccessApproval.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApproval.Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserRoleRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDto> AssignRole(UserDto userDto)
        {
            _mapper.Map<User>(userDto);
            var existinguser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDto.id);
            if (existinguser == null)
            {
                return null;
            }

            // Update the access request status
            existinguser.Role = (UserRole)userDto.Role;
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(existinguser);
        }
    }
}
