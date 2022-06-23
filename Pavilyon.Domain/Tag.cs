using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
        public string TagName { get; set; }
    }
}
