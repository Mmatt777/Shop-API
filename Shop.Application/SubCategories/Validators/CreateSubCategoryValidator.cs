using FluentValidation;
using Shop.Application.SubCategories.DTOS;

namespace Shop.Application.SubCategories.Validators
{
    public class CreateSubCategoryValidator : AbstractValidator<CreateSubCategoryDTO>
    {
        public CreateSubCategoryValidator()
        {

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required! Enter name please.")
                .MinimumLength(3)
                .MaximumLength(99);                
           
        }
    }
}
