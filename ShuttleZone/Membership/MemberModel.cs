using System;

namespace ShuttleZone.Membership
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string MemberCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MembershipType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public bool IsArchived { get; set; }
    }
}