using System;
using System.Runtime.Serialization;

namespace CoreDomain
{
    [Serializable]
    public sealed class ValorLimiteExcedidoException : DomainException
    {
        private static readonly string message =
            "O valor limite para empréstimos foi excedido.";

        public ValorLimiteExcedidoException()
            : base(message, null)
        {
        }

        private ValorLimiteExcedidoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
