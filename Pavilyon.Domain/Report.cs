using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Domain
{
    public class Report
    {
        public Guid Id { get; set; }
        public Stage Stage { get; set; }
        public ProjectMember Sender { get; set; }
        public string ReportName { get; set; }
        public string Content { get; set; }
    }
}
