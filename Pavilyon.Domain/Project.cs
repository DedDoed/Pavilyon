using System;
using System.Collections.Generic;

namespace Pavilyon.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectMember> Team { get; set; } = new List<ProjectMember>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ProjectTargets { get; set; }
        public string ProjectObjectives { get; set; }
        public string RequieredPersonal { get; set; }
        public string Contacts { get; set; }
        public List<Stage> Stages { get; set; } = new List<Stage>();
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
