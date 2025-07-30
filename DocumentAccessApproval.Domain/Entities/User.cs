using DocumentAccessApproval.Domain.Enums;

namespace DocumentAccessApproval.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        //// Navigation properties
        public ICollection<AccessRequest> RequestedAccesses { get; set; } = new List<AccessRequest>();
        public ICollection<AccessRequest> ApprovedAccesses { get; set; } = new List<AccessRequest>();
    }
}
