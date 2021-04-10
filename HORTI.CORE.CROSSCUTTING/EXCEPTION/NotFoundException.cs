using System;
using System.Runtime.Serialization;

namespace HORTI.CORE.CROSSCUTTING.EXCEPTION
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
