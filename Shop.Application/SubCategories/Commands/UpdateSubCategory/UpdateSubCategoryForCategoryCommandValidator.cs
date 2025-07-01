using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SubCategories.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryForCategoryCommandValidator : AbstractValidator<UpdateSubCategoryForCategoryCommand>
    {
        public UpdateSubCategoryForCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .Length(3, 99);
        }
    }
}
