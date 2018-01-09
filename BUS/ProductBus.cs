using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using Entities;
namespace BUS
{
    public class ProductBus
    {
        static ProductBus instance;
        public static ProductBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductBus();
                return instance;
            }
        }
        public DataTable GetTable()
        {
            string sql = "select product.*, categoryname from  product,category where product.categoryid = category.categoryid";
            DataTable dt = DataConfig.Instance.GetTable(sql);
            return dt;
        }

        public ProductEntity GetProductById(string id)
        {
            string sql = "select * tb_product where productid = @id";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@id",id)
            };

            DataTable dt = DataConfig.Instance.GetTable(sql, pars);
            if (dt.Rows.Count < 1)
                return null;
            return RowToProduct(dt.Rows[0]);
        }

        public int DeleteProduct(string id)
        {
            string sql = "delete from tb_product where productid = @id";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DataConfig.Instance.ExecuteNonQuery(sql, pars);
        }

        public int InsertProduct(Entities.ProductEntity p)
        {
            string sql = "insert into tb_product values("+
                "@id,@name,@feature,@discription,@price,@finalprice,@image,@quantity,@status,@by,@date,@cate"+
                ")";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@id", p.ID),
                new SqlParameter("@name", p.ProductName),
                new SqlParameter("@feature", p.Feature),
                new SqlParameter("@discription", p.Discription),
                new SqlParameter("@price", p.Price),
                new SqlParameter("@finalprice", p.FinalPrice),
                new SqlParameter("@image", p.DisplayImage),
                new SqlParameter("@quantity", p.Quantity),
                new SqlParameter("@status",p.StatusId),
                new SqlParameter("@by", p.Username),
                new SqlParameter("@date",p.CreatedDate),
                new SqlParameter("@cate", p.ProductCategory.ID)
            };
            return DataConfig.Instance.ExecuteNonQuery(sql, pars);
        }

        public int UpdateProduct(Dictionary<string, object> value, string id)
        {
            string sql = "update tb_product set {0} where productid = @id";
            string parameter = String.Empty;
            SqlParameter[] pars = new SqlParameter[value.Count + 1];
            pars[value.Count] = new SqlParameter("@id", id);
            int count = 0;
            foreach (var item in value)
            {
                if (count != 0)
                    parameter += ",";
                parameter += "@" + item.Key + " = " + item.Value;
                pars[count] = new SqlParameter("@"+item.Key, item.Value);
            }
            sql = String.Format(sql, parameter);
            return DataConfig.Instance.ExecuteNonQuery(sql, pars);
        }

        public ProductEntity RowToProduct(DataRow row)
        {
            var p = new ProductEntity();
            p.ID = row["productid"].ToString();
            p.ProductName = row["productname"].ToString();
            p.Feature = row["feature"].ToString();
            p.Discription = row["discription"].ToString();
            p.Price = Convert.ToSingle(row["price"]);
            p.FinalPrice = Convert.ToSingle(row["finalprice"]);
            p.DisplayImage = row["displayimage"].ToString();
            p.Quantity = (int)row["quantity"];
            p.Status = StatusBus.Instance.GetStatus((int)row["statusid"]);
            p.CreatedDate = (DateTime)row["createddate"];
            p.CreatedBy = UserBus.Instance.GetUser(row["createdby"].ToString());
            p.ProductCategory = CategoryBus.Instance.GetBasicCategoryById(row["categoryid"].ToString());
            return p;
        }

        public List<ProductEntity> DataTableToList(DataTable dt)
        {
            List<ProductEntity> ls = new List<ProductEntity>();
            foreach (DataRow row in dt.Rows)
            {
                var p = RowToProduct(row);
                ls.Add(p);
            }
            return ls;
        }
        public List<ProductEntity> GetProducts()
        {
            string sql = "select * from tb_product";
            DataTable dt = DataConfig.Instance.GetTable(sql);
            return DataTableToList(dt);
        }

        public int UpdateStatus(int value, string id)
        {
            string sql = "update tb_product set statusid = @status where productid = @id";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@status", value),
                new SqlParameter("@id", id)
            };
            return DataConfig.Instance.ExecuteNonQuery(sql, pars);
        }

        public List<ProductEntity> GetRandomProducts(int number)
        {
            string sql = "select top " + number.ToString() + " * from tb_product";
            DataTable dt = DataConfig.Instance.GetTable(sql);
            return DataTableToList(dt);
        }
    }
}
