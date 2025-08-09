using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Products.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;

namespace Shop.Application.Products.Queries.GetAllProductForCategoryQuery
{
    public class GetAllProductsForCategoryQueryHandler(ILogger<GetAllProductsForCategoryQueryHandler> logger,
        IProductsRepository productsRepository,
        IMapper mapper)
        : IRequestHandler<GetAllProductsForCategoryQuery, IEnumerable<ProductDTO>>
    {
        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsForCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all products for category with id:{categoryId}", request.categoryId);

            var category = await productsRepository.GetAllProductsForCategory(request.categoryId);
            if (category == null) throw new NotFoundException(nameof(Category), request.categoryId.ToString());
            var products = category.Products.ToList();

            var result = mapper.Map<IEnumerable<ProductDTO>>(products);

            return result;
        }
    }
}
