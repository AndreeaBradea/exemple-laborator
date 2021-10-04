using System;
using System.Runtime.Serialization;

namespace Lucrarea01.Domain
{
    [Serializable]
    internal class InvalidID : Exception
    {
        public InvalidID()
        {
        }

        public InvalidID(string message) : base(message)
        {
        }

        public InvalidID(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidID(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}