using System.ComponentModel.DataAnnotations;

namespace DocumentAccessApproval.Application.DTO
{
    public class DecisionDto
    {
        [Required]
        public int ApproverUserId { get; set; }

        [StringLength(500)]
        public string ApproverComment { get; set; } = string.Empty;
    }
}
