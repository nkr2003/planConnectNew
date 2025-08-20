using EventManagement.Api.Models;

namespace EventManagement.Models.UserModel
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; } // Navigation property for related users
    }
}