using System;
using System.Runtime.Serialization;

namespace CoreDomain
{
    [Serializable]
    public sealed class ServicoProtecaoCreditoIndisponivelException : Exception
    {
        public ServicoProtecaoCreditoIndisponivelException()
        {
        }

        private ServicoProtecaoCreditoIndisponivelException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
