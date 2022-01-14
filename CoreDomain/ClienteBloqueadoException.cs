using System;
using System.Runtime.Serialization;

namespace CoreDomain
{
    [Serializable]
    public sealed class ClienteBloqueadoException : DomainException
    {
        private static readonly string message =
            "Serviço de empréstimos bloqueado para este cliente.";

        public ClienteBloqueadoException()
            : base(message, null)
        {
        }

        private ClienteBloqueadoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
