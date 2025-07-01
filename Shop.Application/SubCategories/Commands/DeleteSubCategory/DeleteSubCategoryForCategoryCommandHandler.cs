using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;
using System.Runtime.InteropServices;

namespace Shop.Application.SubCategories.Commands.DeleteSubCategory
{
    public class DeleteSubCategoryForCategoryCommandHandler(ILogger<DeleteSubCategoryForCategoryCommandHandler> logger,
        ICategoriesRepository categoriesRepository,
        ISubCategoriesRepository subCategoriesRepository) : IRequestHandler<DeleteSubCategoryForCategoryCommand>
    {
        public async Task Handle(DeleteSubCategoryForCategoryCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting subcategory with id:{SubCateogryId} for category with id:{CategoryId}", 
                request.subCategoryId, request.categoryId);

            var category = await categoriesRepository.GetCategoryByIdWithsubCategoryAsync(request.categoryId);
            if (category == null) throw new NotFoundException(nameof(Category), request.categoryId.ToString());

            var subcategory = category.SubCategories.FirstOrDefault(s => s.Id == request.subCategoryId);
            if (subcategory == null) throw new NotFoundException(nameof(SubCategory), request.subCategoryId.ToString());

            await subCategoriesRepository.Delete(subcategory);
        }
    }
}
