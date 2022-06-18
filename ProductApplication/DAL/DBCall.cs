using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProductApplication.Model.Product;
using System.Data;
using System.Data.SqlClient;

namespace ProductApplication.DAL
{
    public class DBCall
    {
        public GenericResponse ProductOperations(ProductAttribute product)
        {
            DataSet ds = new DataSet();
            List<ProductAttribute> list = new List<ProductAttribute>();
            string DBCon = "Add Connection String";
            GenericResponse res = new GenericResponse();
            try
            {
                SqlConnection con = new SqlConnection(DBCon);
                using (SqlCommand sqlComm = new SqlCommand("product_crud_operation", con))
                {
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Connection = con;
                    sqlComm.Parameters.AddWithValue("@product_id", product.ProductId);
                    sqlComm.Parameters.AddWithValue("@desc", product.Description);
                    sqlComm.Parameters.AddWithValue("@is_delete", product.IsDelete);
                    sqlComm.Parameters.AddWithValue("@name", product.Name);
                    sqlComm.Parameters.AddWithValue("@op_type", product.Optype);
                    sqlComm.Parameters.AddWithValue("@price", product.Price);
                    con.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(sqlComm);
                    adp.Fill(ds);
                    con.Close();
                }
                if (ds != null && ds.Tables[0].Columns.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (product.Optype == 1 || product.Optype == 2 || product.Optype == 3 || product.Optype == 5)//1-Insert,2-Update,3-Delete,4-Fetch,5-Activate
                    {
                        res.ResponseStatus = true;
                        res.ResponseMsg = ds.Tables[0].Rows[0].ToString();
                    }
                    else
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            product.ProductId = Convert.ToInt32(item["ProductId"]);
                            product.Description = Convert.ToString(item["Description"]);
                            product.Price = Convert.ToInt32(item["Price"]);
                            product.IsDelete = Convert.ToBoolean(item["IsDelete"]);
                            product.Name = Convert.ToString(item["Name"]);
                        }
                    }
                }
                else
                {
                    res.ResponseStatus = false;
                    res.ResponseMsg = "Something is wrong ";
                } 
            }         
            catch(Exception ex)
            {
                return res;
            }
            
            return res;
        }

    }
}
