using Microsoft.AspNetCore.Mvc;
using ProductApplication.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProductApplication.Model.Product;

namespace ProductApplication.Controller
{
    [Route("api/[action]")]
    [ApiController]
    public class ProductInventory : ControllerBase
    {

        private IService _sObj;

        public ProductInventory(IService sObj)
        {
            _sObj = sObj;            
        }
        // GET api/<ProductApplication>/5
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        [HttpPost]        
        public  IActionResult ProductOperations(ProductAttribute product)
        {
            GenericResponse result = new GenericResponse();
            //string result = string.Empty;
            try
            {                
               
                    result =  _sObj.ProductOperations(product);
              
            }
            catch (Exception ex)
            {
              
            }
            return Ok(result);
        }
    }
}
