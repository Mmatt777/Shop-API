using FluentValidation;

namespace Shop.Application.SubCategories.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommandValidator : AbstractValidator<CreateSubCategoryCommnad>
    {
        public CreateSubCategoryCommandValidator()
        {

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required! Enter name please.")
                .MinimumLength(3)
                .MaximumLength(99);                
           
        }
    }
}
