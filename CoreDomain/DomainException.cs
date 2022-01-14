using System;
using System.Runtime.Serialization;

namespace CoreDomain
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message)
            : this(message, null)
        {
        }

        protected DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
