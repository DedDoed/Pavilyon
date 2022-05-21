using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Domain
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public string Path { get; set; }
    }
}
