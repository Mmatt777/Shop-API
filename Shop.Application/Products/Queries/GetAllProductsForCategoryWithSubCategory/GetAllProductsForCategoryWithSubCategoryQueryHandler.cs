using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Products.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;

namespace Shop.Application.Products.Queries.GetAllProductsForCategoryWithSubCategory
{
    public class GetAllProductsForCategoryWithSubCategoryQueryHandler
        (ILogger<GetAllProductsForCategoryWithSubCategoryQueryHandler> logger,
        IProductsRepository productsRepository,
        IMapper mapper)
        :IRequestHandler<GetAllProductsForCategoryWithSubCategoryQuery, IEnumerable<ProductDTO>>
    {
        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsForCategoryWithSubCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting products for category with id:{categoryId} and with subcategory with id:{subCategoryId}", 
                request.categoryId, 
                request.subCategoryId);

            var category = await productsRepository.GetAllProductsForCategoryWithSubCategory(request.categoryId);
            if (category == null) throw new NotFoundException(nameof(Category), request.categoryId.ToString());

            var subcategory = category.SubCategories.FirstOrDefault(s => s.Id == request.subCategoryId);
            if (subcategory == null) new NotFoundException(nameof(SubCategory), request.subCategoryId.ToString());

            var products = subcategory!.Products.ToList();

            var result = mapper.Map<IEnumerable<ProductDTO>>(products);

            return result;
        }
    }
}
