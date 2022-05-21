using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Application.Users.Queries.GetUserData
{
    public class UserDataDto
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
    }
}
