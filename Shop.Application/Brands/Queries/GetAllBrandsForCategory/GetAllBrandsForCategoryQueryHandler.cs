using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Brands.DTOS;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Brands.Queries.GetAllBrandsForCategory
{
    class GetAllBrandsForCategoryQueryHandler(ILogger<GetAllBrandsForCategoryQueryHandler> logger,
        ICategoriesRepository categoriesRepository,
        IMapper mapper) 
        : IRequestHandler<GetAllBrandsForCategoryQuery, IEnumerable<BrandDTO>>
    {
        public async Task<IEnumerable<BrandDTO>> Handle(GetAllBrandsForCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Geting all brands for category: {CategoryId}", request.categoryId);
            var category = await categoriesRepository.GetCategoryByIdWithBrandsAsync(request.categoryId);
            if (category == null)
                throw new NotFoundException(nameof(Category), request.categoryId.ToString());

            var brands = mapper.Map<IEnumerable<BrandDTO>>(category.Brands);

            return brands;           
        }
    }
}
