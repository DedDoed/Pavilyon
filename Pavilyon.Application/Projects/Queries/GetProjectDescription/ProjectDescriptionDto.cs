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
        public List<ProjectMember> Team { get; set; }
        public List<Tag> Tags { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ProjectTargets { get; set; }
        public string ProjectObjectives { get; set; }
        public string RequieredPersonal { get; set; }
        public string Contacts { get; set; }
        public List<Stage> Stages { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
