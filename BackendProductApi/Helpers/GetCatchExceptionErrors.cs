using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProductApi.Helpers
{
    public class GetCatchExceptionErrors
    {
        public static IActionResult getErrors(ControllerBase c, Exception ex)
        {
            if(ex.GetType() == typeof(DbUpdateException))
            {
                if (ex.InnerException is SqlException sqlException)
                {
                    switch (sqlException.Number)
                    {
                        case 2627: return c.BadRequest(new { errors = new { UniqueConstraint = sqlException.Message } }); // Unique constraint error
                        case 547: return c.BadRequest(new { errors = new { constraintViolation = sqlException.Message } });  // Constraint check violation
                        case 2601: return c.BadRequest(new { errors = new { duplicatedkey = "Cannot insert duplicate key row in object" } }); // Duplicated key row error
                                                                                                                       // Constraint violation exception
                                                                                                                       // A custom exception of yours for concurrency issues

                        default:
                            return c.StatusCode(500, new { errors = new { unhandleException = sqlException.Message } });
                            // A custom exception of yours for other DB issues

                    }
                }
            }
            return c.StatusCode(500, new { errors = new { unhandleException = ex.Message } });
        }
    }
}
