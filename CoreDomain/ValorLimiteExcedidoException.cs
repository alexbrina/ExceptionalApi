using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CoreDomain
{
    [Serializable]
    public sealed class ValorLimiteExcedidoException : DomainException
    {
        private static readonly string message =
            "O valor limite para empréstimos foi excedido.";

        public ValorLimiteExcedidoException(IDictionary<string, string> extras)
            : base(message, null, extras)
        {
        }

        private ValorLimiteExcedidoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
