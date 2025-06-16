using Shop.Domain.Entities;

namespace Shop.Application.SubCategories.DTOS
{
    public class CreateSubCategoryDTO
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }

        //Manual mapping
        //public static SubCategory FromDTO(CreateSubCategoryDTO createSubCategoryDTO)
        //{
        //    return new SubCategory()
        //    {
        //        Name = createSubCategoryDTO.Name
        //    };
        //}
    }
}
