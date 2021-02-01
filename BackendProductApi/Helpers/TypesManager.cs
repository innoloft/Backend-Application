using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProductApi.Helpers
{
    public class TypesManager
    {
        public const string Hardware = "Hardware";
        public const string Software = "Software";

        public static bool checkStatus(string status)
        {
            if(status.Equals(Hardware) || status.Equals(Software))
            {
                return true; 
            }
            return false; 
        }
    }
}
