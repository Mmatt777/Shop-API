using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Shop.Application.Products.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;

namespace Shop.Application.Products.Queries.GetProductByIdForCategory
{
    public class GetProductByIdForCategoryQueryHandler(ILogger<GetProductByIdForCategoryQueryHandler> logger,
        IProductsRepository productsRepository,
        IMapper mapper) 
        : IRequestHandler<GetProductByIdForCategoryQuery, ProductDTO>
    {
        public async Task<ProductDTO> Handle(GetProductByIdForCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting product by id:{productId} for category with id:{categoryId}",
                request.productId,
                request.categoryId);

            var category = await productsRepository.GetProductByIdForCategory(request.categoryId) 
                ?? throw new NotFoundException(nameof(Category), request.categoryId.ToString());

            var product = category.Products.FirstOrDefault(p => p.Id == request.productId) 
                ?? throw new NotFoundException(nameof(Product), request.categoryId.ToString());

            var result = mapper.Map<ProductDTO>(product);

            return result;
        }
    }
}
