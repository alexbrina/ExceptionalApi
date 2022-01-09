using System;
using System.Runtime.Serialization;

namespace CoreDomain
{
    [Serializable]
    public sealed class ValorLimiteExcedidoException : DomainException
    {
        public ValorLimiteExcedidoException()
        {
        }

        private ValorLimiteExcedidoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
