using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentAccessApproval.Api.Controllers
{
    public class RequestDecisionController : ControllerBase
    {
        private readonly IAccessDecisionRepository _accessdecisionRepository;

        public RequestDecisionController(IAccessDecisionRepository accessdecisionRepository)
        {
            _accessdecisionRepository = accessdecisionRepository;
        }
        /// <summary>
        /// Get all pending access requests (for approvers)
        /// </summary>
        [HttpGet("GetAllPendingRequest")]
        [Authorize(Roles = "Approver")]
        public async Task<IActionResult> GetPendingRequests()
        {
            var result = await _accessdecisionRepository.GetAllPendingRequestsAsync();
            if (result == null)
            {
                return NotFound(new { message = "Pending Access request not found" });
            }
            return Ok(result);
        }

        /// <summary>
        /// Approve an access request
        /// </summary>
        [HttpPatch("ApproveRequest/{AccessRequestid}")]
        [Authorize(Roles = "Approver")]
        public async Task<IActionResult> ApproveRequest(int AccessRequestid, [FromBody] DecisionDto approveDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accessdecisionRepository.ApproveRequestAsync(AccessRequestid, approveDto);

            if (result == null)
            {
                return BadRequest(new { message = "Something went wrong" });
            }

            return Ok(result);
        }

        /// <summary>
        /// Reject an access request
        /// </summary>
        [HttpPatch("RejectRequest/{AccessRequestid}")]
        [Authorize(Roles = "Approver")]
        public async Task<IActionResult> RejectRequest(int AccessRequestid, [FromBody] DecisionDto rejectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _accessdecisionRepository.RejectRequestAsync(AccessRequestid, rejectDto);
            if (result == null)
            {
                return BadRequest(new { message = "Something went wrong" });
            }
            return Ok(result);
        }
    }
}
