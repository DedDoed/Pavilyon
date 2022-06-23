using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public string AboutMe { get; set; }
        public List<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
    }
}
