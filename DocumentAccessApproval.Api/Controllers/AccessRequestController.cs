using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Application.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentAccessApproval.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessRequestController : ControllerBase
    {
        private readonly IAccessRequestRepository _accessRequestRepository;

        public AccessRequestController(
            IAccessRequestRepository accessRequestRepository)
        {
            _accessRequestRepository = accessRequestRepository;
        }

        /// <summary>
        /// Submit a new access request
        /// </summary>
        [HttpPost("CreateNewAccessRequest")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateAccessRequest([FromBody] CreateAccessRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _accessRequestRepository.CreateAccessRequestAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Get access request by User ID
        /// </summary>
        [HttpGet("GetAccessRequestbyUserID{userid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAccessRequestByUserId([FromRoute] int userid)
        {
            var accessRequestById = await _accessRequestRepository.GetAllAccessIdByUserId(userid);
            if (accessRequestById == null)
            {
                return NotFound(new { message = "Access request not found" });
            }
            return Ok(accessRequestById);
        }
    }
}
