using FluentValidation;


namespace Shop.Application.SubCategories.Commands.CreateSubCategory
{
    public class CreateSubCategoryForCategoryCommandValidator : AbstractValidator<CreateSubCategoryForCategoryCommand>
    {
        public CreateSubCategoryForCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required!")
                .MinimumLength(3)
                .MaximumLength(99);
        }
    }
}
