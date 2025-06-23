using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Repositories;

namespace Shop.Application.SubCategories.Commands.DeleteSubCategory
{
    public class DeleteSubCategoryCommandHandler(ILogger<DeleteSubCategoryCommandHandler> logger,
        ISubCategoriesRepository subCategoriesRepository) : IRequestHandler<DeleteSubCategoryCommand, bool>
    {
        public async Task<bool> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting subcategory");

            var subCategory = await subCategoriesRepository.GetSubCategoryByIdAsync(request.id);
            if (subCategory is null)
                return false;

            await subCategoriesRepository.Delete(subCategory);
            return true;
        }
    }
}
