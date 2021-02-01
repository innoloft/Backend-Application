using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProductApi.Helpers
{
    public class ErrorConst
    {
        public const string REQUIRED = "Required";
        public const string NOT_VALID_EMAIL = "NOT_VALID_EMAIL";
        public const string CONFIRM_PASSWORD = "CONFIRM_PASSWORD";
        public const string PASSWORD_LONG = "PASSWORD_LONG";
        public const string NOT_VALID_PHONENUMBER = "NOT_VALID_PHONENUMBER";

        public readonly static string NO_ITEM = "NO_ITEM";
        public readonly static string InvalidType = "InvalidType";
    }
}
