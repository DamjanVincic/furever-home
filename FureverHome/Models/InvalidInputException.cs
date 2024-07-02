using System;

namespace FureverHome.Models { 

    public class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string message) : base(message)
        {
        }
    }
}