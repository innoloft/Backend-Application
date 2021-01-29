using Backend_Application.WebAPI.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Validators
{
    public class UpdateProdutValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProdutValidator()
        {
            RuleFor(dto => dto).NotNull();
            RuleFor(dto => dto.ProductId).NotNull().GreaterThan(0);
            RuleFor(dto => dto.Title).NotNull().NotEmpty();
            RuleFor(dto => dto.ContactPersonId).NotNull().NotEmpty();
            RuleFor(dto => dto.TypeId).NotNull().GreaterThan(0);
        }
    }
}
