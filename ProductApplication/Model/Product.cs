using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApplication.Model
{
    public class Product
    {
        public class ProductAttribute
        {
            public int ProductId { get; set; }
            public string Name  { get; set; }
            public string Description { get; set; }
            public decimal  Price { get; set; }
            public int  Optype { get; set; }
            public bool  IsDelete { get; set; }

        }
        
        public class GenericResponse
        {
            public int ResponseCode { get; set; }
            public bool ResponseStatus { get; set; }
            public string ResponseMsg { get; set; }
            public object ResponseData { get; set; }
        }
    }
}
