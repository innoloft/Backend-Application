using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProductApi.Helpers
{
    public class GetErrorListFromResult
    {

        public static Object GetErrorList(IdentityResult result)
        {
            //var query = from error in result.Errors
            //            select error.Description;

            //var errorList = query.ToList();
            //return errorList;
            
            var errorList = result.Errors.ToDictionary(kvp => kvp.Code.Replace("DuplicateUserName", "email"), kvp => kvp.Description.Replace("User name", "email"));
            var errors = new
            {
                errors = errorList
            };
            return errors;
        }
      
    }
}
