using System;

namespace Source
{
    public class KooException : Exception
    {
        public KooException(string errorMessage, Exception e)
            : base(errorMessage, e)
        {
        }
    }
}