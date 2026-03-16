using System;

namespace ShuttleZone.UserManagement
{
    public class UserModel
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime LastLogin { get; set; }
    }
}