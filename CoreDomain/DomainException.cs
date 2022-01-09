using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace CoreDomain
{
    public abstract class DomainException : Exception
    {
        public readonly ImmutableDictionary<string, string> Extras;

        protected DomainException(string message,
            IDictionary<string, string> extras = null)
            : this(message, null, extras)
        {
        }

        protected DomainException(string message, Exception innerException,
            IDictionary<string, string> extras)
            : base(message, innerException)
        {
            if (extras != null)
            {
                Extras = extras.ToImmutableDictionary();
            }
        }

        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
