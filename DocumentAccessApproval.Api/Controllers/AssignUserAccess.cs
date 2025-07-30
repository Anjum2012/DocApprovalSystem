using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Domain.Enums;
using DocumentAccessApproval.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentAccessApproval.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignUserAccess : ControllerBase
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public AssignUserAccess(IUserRoleRepository userRoleRepository) 
        {
            _userRoleRepository= userRoleRepository;
        }

        /// <summary>
        /// Assign Role to User
        /// </summary>
        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userRoleRepository.AssignRole(userDto);
            if (result == null)
            {
                return BadRequest(new { message = "Something went wrong" });
            }
            return Ok(result);
        }
    }
}
