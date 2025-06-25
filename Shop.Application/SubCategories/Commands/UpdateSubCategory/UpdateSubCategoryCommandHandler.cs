using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SubCategories.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommandHandler(ILogger<UpdateSubCategoryCommand> logger, 
        IMapper mapper, ISubCategoriesRepository subCategoriesRepository) : IRequestHandler<UpdateSubCategoryCommand, bool>
    {
        public async Task<bool> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating subcategory");

            var subCategory = await subCategoriesRepository.GetSubCategoryByIdAsync(request.Id);
            if (subCategory is null)
                return false;

            mapper.Map(request, subCategory);
            //subCategory.Name = request.Name;

            await subCategoriesRepository.SaveUpdate();
            
            return true;
        }
    }
}
