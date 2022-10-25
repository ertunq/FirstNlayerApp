using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nlayer.Core.DTOs;
using Nlayer.Core.Models;

namespace Nlayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductsWithCategory();
    }
}
