using System;

namespace Contests.Common
{
    public class InvalidProgramStateException : Exception
    {
        public InvalidProgramStateException(string? message) : base(message)
        {
        }
    }
}