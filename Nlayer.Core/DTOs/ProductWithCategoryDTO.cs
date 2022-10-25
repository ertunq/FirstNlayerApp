using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.DTOs
{
    public class ProductWithCategoryDTO : ProductDTOs
    {
        public CategoryDTOs Category{ get; set; }
    }
}
