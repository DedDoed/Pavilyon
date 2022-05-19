using Pavilyon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Domain
{
    public class Stage
    {
        public Guid Id { get; set; }
        public Project Project { get; set; }
        public string StageName { get; set; }
        public Status StageStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public List<Report> Reports { get; set; }
        public List<ProjectMember> ProjectMembers { get; set; }
    }
}
