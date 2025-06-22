using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Categories.DTOS;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Queries.GetCategoryByIdWithsubCategory
{
    public class GetCategoryByIdWithsubCategoryQueryHandler(ILogger<GetCategoryByIdWithsubCategoryQueryHandler> logger,
        IMapper mapper, ICategoriesRepository categoriesRepository) 
        : IRequestHandler<GetCategoryByIdWithsubCategoryQuery, CategoryDTO?>
    {
        public async Task<CategoryDTO?> Handle(GetCategoryByIdWithsubCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting category by {request.Id}");
            var category = await categoriesRepository.GetCategoryByIdWithsubCategoryAsync(request.Id);

            var categoryDTO = mapper.Map<CategoryDTO?>(category);

            //var categoryDTO = CategoryDTO.FromEntity(category); Manual mapping is used here


            return categoryDTO;
        }
    }
}
