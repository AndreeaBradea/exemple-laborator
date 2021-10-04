using System;
using System.Runtime.Serialization;

namespace Lucrarea01.Domain
{
    [Serializable]
    internal class InvalidStatusPlata : Exception
    {
        public InvalidStatusPlata()
        {
        }

        public InvalidStatusPlata(string message) : base(message)
        {
        }

        public InvalidStatusPlata(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidStatusPlata(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}