using System;
using System.Globalization;

namespace Innoloft.Repositories.Helpers
{
    public class RepositoryException : Exception
    {
        public RepositoryException() : base() { }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public dynamic GetError()
        {
            return new { message = string.Format("Error occured: {0}", Message) };
        }
    }
}
