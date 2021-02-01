using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProductApi.Helpers
{
    public  class GetErrorListFromModelState
    {
        public static Object GetErrorList(ModelStateDictionary modelState)
        {
            //var query = from state in modelState.Values
            //            from error in state.Errors
            //            select error.ErrorMessage;

            //var errorList = query.ToList();
            //return errorList;

            //var errorList = modelState.ToDictionary(kvp => kvp.Key,
            //    kvp => kvp.Value.Errors
            //                    .Select(e => e.ErrorMessage));

            //var errorList = modelState.ToDictionary(kvp => kvp.Key.Replace("model.", ""), kvp => kvp.Value.Errors.First().ErrorMessage);
            //var errorList = modelState.ToDictionary(kvp => kvp.Key.Replace("model.", ""), kvp => "test");
            //var errorList = from modelstate in modelState.AsQueryable().Where(f => f.Value.Errors.Count > 0) select new
            //{
            //    Title = modelstate.Key
            //};
            var errorList = modelState.Where(f => f.Value.Errors.Count > 0).ToDictionary(kvp =>kvp.Key, kvp => kvp.Value.Errors.First().ErrorMessage);
            // var errorList = modelState.ToDictionary(kvp => kvp.Key., kvp =>
            //{
            //    if (kvp.Value.Errors.Count > 0)
            //    {
            //        return "";
            //    }

            //});
            var errors = new
            {
                errors = errorList
            };
            return errors;
        }
    }
}
