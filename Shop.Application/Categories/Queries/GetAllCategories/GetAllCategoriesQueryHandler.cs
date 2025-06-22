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

namespace Shop.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler(ILogger<GetAllCategoriesQueryHandler> logger,
        IMapper mapper, ICategoriesRepository categoriesRepository) : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDTO>>
    {
        public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all categories");
            var categories = await categoriesRepository.GetAllAsync();

            var categoryDTO = mapper.Map<IEnumerable<CategoryDTO>>(categories); // Automapper is used here  

            //var categoryDTO = categories.Select(CategoryDTO.FromEntity); // Manual mapping is used here

            return categoryDTO!;
        }
    }
}
