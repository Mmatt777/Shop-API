using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Brands.Queries.GetAllBrandsForCategory;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductForCategoryCommandHandler(ILogger<DeleteProductForCategoryCommandHandler> logger,
        IProductsRepository productsRepository) : IRequestHandler<DeleteProductForCategoryCommand>
    {
        public async Task Handle(DeleteProductForCategoryCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting product for category with id:{categoryId}",
                request.categoryId);

            var category = await productsRepository.GetAllProductsForCategory(request.categoryId)
                ?? throw new NotFoundException(nameof(Category), request.categoryId.ToString());

            var product = category.Products.FirstOrDefault(p => p.Id == request.productId);

            await productsRepository.DeleteProduct(product!);
        }
    }
}
