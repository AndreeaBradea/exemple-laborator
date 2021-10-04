using System;
using System.Runtime.Serialization;

namespace Lucrarea01.Domain
{
    [Serializable]
    internal class InvalidCantitate : Exception
    {
        public InvalidCantitate()
        {
        }

        public InvalidCantitate(string message) : base(message)
        {
        }

        public InvalidCantitate(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCantitate(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}