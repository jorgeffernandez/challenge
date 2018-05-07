namespace Challenge.Shared.Models.Exceptions
{
    using System;
    using System.Runtime.Serialization;
  
    [System.Serializable]
    public class TokenException : Exception
    {
        public TokenException(string message) : base(message) { }

        protected TokenException(SerializationInfo serializationInfo, StreamingContext streamingContext) { }
    }
}