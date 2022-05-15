using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pavilyon.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public Guid CreatorId { get; set; }
        public string Tags { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
