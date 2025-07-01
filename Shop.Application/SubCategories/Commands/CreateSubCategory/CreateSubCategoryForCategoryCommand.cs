using MediatR;

namespace Shop.Application.SubCategories.Commands.CreateSubCategory
{
    public class CreateSubCategoryForCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
