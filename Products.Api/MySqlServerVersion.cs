using System;

namespace Products.Api
{
    internal class MySqlServerVersion
    {
        private Version version;

        public MySqlServerVersion(Version version)
        {
            this.version = version;
        }
    }
}