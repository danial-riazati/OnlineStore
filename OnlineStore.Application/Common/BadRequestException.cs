using System;
namespace OnlineStore.Application.Common
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException(string[] errors) : base($"Multiple errors occurred. See error details: {String.Join(", ", errors)}")
        {
        }

    }
}

