using System;
using System.Runtime.Serialization;

namespace CoreDomain
{
    public abstract class DomainException : Exception
    {
        protected DomainException()
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
