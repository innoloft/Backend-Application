using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Aes = System.Security.Cryptography.Aes;

namespace InnoLoft.Utility
{
    public class Helper
    {
        public static int success_code = 1;
        public static int failure_code = 0;
        public static int badrequest_code = -1;
        public static int reference_error_code = -2;
        public static int somethingwentwrong = 0;
    }
    public class CommonResponse<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public T dataenum { get; set; }
        public Int64 totalRecords { get; set; }
    }

    public class Datatable
    {
        public int? first { get; set; }
        public int? rows { get; set; }
        public string sortField { get; set; }
        public int? sortOrder { get; set; }
        public string search { get; set; }
    }

    public class ProductSearchRequest
    {
        public int rows { get; set; }
        public int sortOrder { get; set; }
        public string filterColumn { get; set; }
        public string search { get; set; }
        public Int64 typeId { get; set; }
    }
}
