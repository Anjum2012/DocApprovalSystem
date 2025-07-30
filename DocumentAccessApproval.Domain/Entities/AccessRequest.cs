using DocumentAccessApproval.Domain.Enums;

namespace DocumentAccessApproval.Domain.Entities
{
    public class AccessRequest
    {
        public int Id { get; set; }
        public int RequestorUserId { get; set; }
        public int DocumentId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public AccessType AccessType { get; set; }
        public AccessStatus Status { get; set; } = AccessStatus.Pending;
        public string ApproverComment { get; set; } = string.Empty;
        public int? ApproverUserId { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime? UpdatedAt { get; set; }=DateTime.Now;

        // Navigation properties
        public User RequestorUser { get; set; } = null!;
        public User? ApproverUser { get; set; }
        public Document Document { get; set; } = null!;

    }
}
