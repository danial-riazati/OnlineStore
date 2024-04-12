using System;
namespace OnlineStore.Application.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}

