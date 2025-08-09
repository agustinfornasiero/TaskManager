using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Common
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
