using System.ComponentModel.DataAnnotations;

namespace DocumentAccessApproval.Application.DTO
{
    public class CreateAccessRequestDto
    {
        [Required]
        public int RequestorUserId { get; set; }

        [Required]
        public int DocumentId { get; set; }

        [Required]
        public int AccessType { get; set; }

        [Required]
        public string Reason { get; set; } = string.Empty;
    }
}
