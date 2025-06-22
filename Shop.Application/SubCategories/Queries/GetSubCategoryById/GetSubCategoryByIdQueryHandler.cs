using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.SubCategories.DTOS;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQueryHandler(ILogger<GetSubCategoryByIdQuery> logger,
        IMapper mapper, ISubCategoriesRepository subCategoriesRepository) 
        : IRequestHandler<GetSubCategoryByIdQuery, SubCategoryDTO?>
    {
        public async Task<SubCategoryDTO> Handle(GetSubCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Geting subcategory by {request.Id}");

            var subCategoryById = await subCategoriesRepository.GetSubCategoryByIdAsync(request.Id);

            var subCategoryDTO = mapper.Map<SubCategoryDTO?>(subCategoryById);

            // var subCategoryDTO = SubCategoryDTO.FromEntity(subCategoryById); // Manual mapping is used here
            return subCategoryDTO;
        }
    }
}
