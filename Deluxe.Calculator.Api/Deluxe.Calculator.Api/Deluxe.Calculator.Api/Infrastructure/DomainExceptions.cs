using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Deluxe.Calculator.Api.Infrastructure
{
    [Serializable]
    public class DomainExceptions : Exception
    {
        public DomainExceptions()
        {

        }
        public DomainExceptions(string message) : base(message)
        {

        }

        public DomainExceptions(string message, Exception innerException) : base(message, innerException)
        {

        }

        public DomainExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
