using Pavilyon.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Application.Projects.Queries
{
    public class ProjectDescriptionDto
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
