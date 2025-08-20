using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Authorization;
using Shop.Infrastructure.Authorization.Services;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommandHandler
        (ILogger<CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommandHandler> logger,
        IProductsRepository productsRepository,
        IShopAuthorizationService shopAuthorizationService,
        IMapper mapper) 
        : IRequestHandler<CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating product for category with id:{categoryId}, subcategory with id:{subcategoryId}" +
                "and brand with id{brandId}",
                request.CategoryId,
                request.SubCategoryId,
                request.BrandId);

            var category = await productsRepository.GetAllProductForCategoryWithSubCategoryAndBrand(request.CategoryId)
                ?? throw new NotFoundException(nameof(Category), request.CategoryId.ToString());

            var subcategory = category.SubCategories.FirstOrDefault(s => s.Id == request.SubCategoryId)
                ?? throw new NotFoundException(nameof(SubCategory), request.SubCategoryId.ToString());

            var brand = subcategory.Brands.FirstOrDefault(s => s.Id == request.BrandId)
                ?? throw new NotFoundException(nameof(Brand), request.BrandId.ToString());

            if (!shopAuthorizationService.IsAuthorize(ResourceOperation.Create))
                throw new ForbidException();

            var product = mapper.Map<Product>(request);

            return await productsRepository.CreateProduct(product);
        }
    }
}
