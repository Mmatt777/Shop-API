using MediatR;


namespace Shop.Application.SubCategories.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryForCategoryCommand(int categoryId, int subCategoryId, string name) : IRequest
    {
        public string Name { get; set; } = name;
        public int CategoryId { get; set; } = categoryId;
        public int SubCategoryId { get; set; } = subCategoryId;
    }
}
