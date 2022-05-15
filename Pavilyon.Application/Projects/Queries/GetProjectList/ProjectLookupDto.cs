using Pavilyon.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Application.Projects.Queries.GetProjectList
{
    public class ProjectLookupDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
    }
}
