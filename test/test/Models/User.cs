using System;
namespace test.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
