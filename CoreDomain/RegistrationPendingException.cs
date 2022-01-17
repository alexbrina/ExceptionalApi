using System;
using System.Runtime.Serialization;

namespace CoreDomain
{
    [Serializable]
    public sealed class RegistrationPendingException : DomainException
    {
        private static readonly string message =
            "Client registration is pending.";

        public RegistrationPendingException()
            : base(message, null)
        {
        }

        private RegistrationPendingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
