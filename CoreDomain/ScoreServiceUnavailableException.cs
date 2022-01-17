using System;
using System.Runtime.Serialization;

namespace CoreDomain
{
    [Serializable]
    public sealed class ScoreServiceUnavailableException : Exception
    {
        public ScoreServiceUnavailableException()
        {
        }

        private ScoreServiceUnavailableException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
