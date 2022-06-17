using ProductApplication.BAL.Interface;
using ProductApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProductApplication.Model.Product;

namespace ProductApplication.BAL.Service
{
    public class Service : IService
    {
        DBCall _oLayer = new DBCall();
        //private DBCall _oLayer;

        //public Service(DBCall dbcall)
        //{
        //    _oLayer = dbcall;
        //}
        public  GenericResponse ProductOperations(ProductAttribute product)
        {
            GenericResponse res = new GenericResponse();
            res =  _oLayer.ProductOperations(product);
            return res;
        }
    }
}
