using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProductApplication.Model.Product;

namespace ProductApplication.BAL.Interface
{
    public interface IService
    {
        async Task<GenericResponse> ProductOperations(ProductAttribute product);

    }
}
