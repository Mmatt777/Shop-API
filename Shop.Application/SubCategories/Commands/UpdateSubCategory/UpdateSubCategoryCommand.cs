using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SubCategories.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommand() : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
    }
}
