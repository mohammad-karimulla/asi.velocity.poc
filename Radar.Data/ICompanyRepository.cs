using Radar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Data
{
    interface ICompanyRepository
    {
        IEnumerable<ProductDetails> GetAllProducts();
        int AddProduct(ProductDetails objProjectModel);
        ProductDetails GetProductById(int productID);
    }
}
