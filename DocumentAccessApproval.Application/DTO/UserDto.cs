using System.ComponentModel.DataAnnotations;

namespace DocumentAccessApproval.Application.DTO
{
    public class UserDto
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int Role { get; set; }
    }
}
