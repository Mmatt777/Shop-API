using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;

namespace Shop.Application.SubCategories.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryForCategoryCommandHandler(ILogger<UpdateSubCategoryForCategoryCommandHandler> logger,
        ICategoriesRepository categoriesRepository,
        ISubCategoriesRepository subCategoriesRepository,
        IMapper mapper) 
        : IRequestHandler<UpdateSubCategoryForCategoryCommand>
    {
        public async Task Handle(UpdateSubCategoryForCategoryCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Update subcategory with id:{subcateogryId} for category with id:{categoryId}",
                request.CategoryId, request.CategoryId);

            var category = await categoriesRepository.GetCategoryByIdWithsubCategoryAsync(request.CategoryId);
            if (category == null) throw new NotFoundException(nameof(Category), request.CategoryId.ToString());

            var subCategory = category.SubCategories.FirstOrDefault(s => s.Id == request.SubCategoryId);
            if (subCategory == null) throw new NotFoundException(nameof(SubCategory), request.SubCategoryId.ToString());

            //subCategory.Name = request.Name;

            mapper.Map(request, subCategory);

            await subCategoriesRepository.SaveUpdate();
        }
    }
}
