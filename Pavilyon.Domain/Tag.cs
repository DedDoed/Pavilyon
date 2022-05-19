using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public List<Project> Projects { get; set; }
        public string TagName { get; set; }
    }
}
