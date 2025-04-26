using System;


namespace Module9
{
    public class IllegalKeyException : Exception
    {
        public IllegalKeyException(string message) : base(message){ }
    }
}
