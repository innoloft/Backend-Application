using Backend_Application.WebAPI.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Validators
{
    public class AddProductValidator : AbstractValidator<AddProductDto>
    {
        public AddProductValidator()
        {
            RuleFor(dto => dto).NotNull();
            RuleFor(dto => dto.Title).NotNull().NotEmpty();
            RuleFor(dto => dto.ContactPersonId).NotNull().NotEmpty();
            RuleFor(dto => dto.TypeId).NotNull().GreaterThan(0);
        }
        
    }
}
