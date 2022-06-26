using System;

namespace ForbiddenLands.Core.Managers
{
    [Serializable]
    public class NotFoundException : Exception
    {
        private Type notFound;

        public Type NotFound { get; }

        public NotFoundException(object obj) : base()
        {
            notFound = obj.GetType();
        }

        public NotFoundException(object obj, string message) : base(message)
        {
            notFound = obj.GetType();
        }

        public NotFoundException(object obj, string message, Exception innerException) : base(message, innerException)
        {
            notFound = obj.GetType();
        }

        public override string Message => $"[{notFound}] - {base.Message}";
    }
}