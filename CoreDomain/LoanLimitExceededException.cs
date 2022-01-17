using System;
using System.Runtime.Serialization;

namespace CoreDomain
{
    [Serializable]
    public sealed class LoanLimitExceededException : DomainException
    {
        private static readonly string message =
            "Loan limit was exceeded.";

        public LoanLimitExceededException()
            : base(message, null)
        {
        }

        private LoanLimitExceededException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
