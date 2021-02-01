using BackendProductApi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProductApi.InputModels
{
    public class EditProductInputModel
    {

        [Required(ErrorMessage = ErrorConst.REQUIRED)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = ErrorConst.REQUIRED)]
        public string Name { get; set; }

        [Required(ErrorMessage = ErrorConst.REQUIRED)]
        public string Description { get; set; }

        [Required(ErrorMessage = ErrorConst.REQUIRED)]
        public string Type { get; set; }

        [Required(ErrorMessage = ErrorConst.REQUIRED)]
        public int  OwnerId { get; set; }

    }
}
