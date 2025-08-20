using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommandValidator 
        : AbstractValidator<CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommand>
    {
        public CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().Length(3, 99);
            RuleFor(p => p.Cost).NotEmpty().GreaterThan(0.0f);
            RuleFor(p => p.Description).NotEmpty().Length(100, 500);
            RuleFor(p => p.StockQuantity).NotEmpty().GreaterThan(0);
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.SubCategoryId).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty();
        }
    }
}
