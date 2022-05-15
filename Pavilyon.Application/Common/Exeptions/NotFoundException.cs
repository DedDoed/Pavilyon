using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Application.Common.Exeptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\"({key}) not found.") { }
    }
}
