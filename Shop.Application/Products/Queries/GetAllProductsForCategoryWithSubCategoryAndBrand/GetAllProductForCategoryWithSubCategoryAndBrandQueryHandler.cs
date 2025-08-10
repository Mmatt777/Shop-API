using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Products.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;


namespace Shop.Application.Products.Queries.GetAllProductForCategoryWithSubCategoryAndBrand
{
    public class GetAllProductForCategoryWithSubCategoryAndBrandQueryHandler
        (ILogger<GetAllProductForCategoryWithSubCategoryAndBrandQueryHandler> logger,
        IProductsRepository productsRepository,
        IMapper mapper)
        : IRequestHandler<GetAllProductForCategoryWithSubCategoryAndBrandQuery, IEnumerable<ProductDTO>>
    {
        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductForCategoryWithSubCategoryAndBrandQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting products for category with id:{categoryId}, subcategory with id:{subCateogryId}" +
                "and brand with id:{brandId}.", request.categoryId, request.subCategoryId, request.brandId);

            var category = await productsRepository.GetAllProductForCategoryWithSubCategoryAndBrand(request.categoryId)
                ?? throw new NotFoundException(nameof(Category), request.categoryId.ToString());

            var subcategory = category.SubCategories.FirstOrDefault(s => s.Id == request.subCategoryId)
                ?? throw new NotFoundException(nameof(SubCategory), request.subCategoryId.ToString());

            var brand = subcategory.Brands.FirstOrDefault(b => b.Id == request.brandId) 
                ?? throw new NotFoundException(nameof(Brand), request.brandId.ToString());

            var products= brand.Products.ToList();

            var result = mapper.Map<IEnumerable<ProductDTO>>(products);

            return result;
        }
    }
}
