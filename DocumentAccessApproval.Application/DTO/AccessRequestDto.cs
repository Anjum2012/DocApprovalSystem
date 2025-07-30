using DocumentAccessApproval.Domain.Enums;

namespace DocumentAccessApproval.Application.DTO
{
    public class AccessRequestDto
    {
        public int Id { get; set; }
        public int RequestorUserId { get; set; }
        public int DocumentId { get; set; }
        public string? Reason { get; set; }
        public AccessType AccessType { get; set; }
        public AccessStatus Status { get; set; }
        public string? ApproverComment { get; set; }
        public int? ApproverUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
