using Shop.Application.SubCategories.DTOS;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SubCategories
{
    public interface ISubCategoriesService
    {
        Task<int> CreateSubCategory(CreateSubCategoryDTO dto);
    }
}
