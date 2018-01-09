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
    public class CategoryBus
    {
        static CategoryBus instance;
        public static CategoryBus Instance {
            get
            {
                if (instance == null)
                    instance = new CategoryBus();
                return instance;
            }
        }
        public DataTable GetTable()
        {
            string sql = "select * from tb_category, tb_status, tb_user where tb_category.statusid = tb_status.statusid and tb_category.username=tb_user.username;";
            DataTable dt = DataConfig.Instance.GetTable(sql);
            return dt;
        }

        public List<ProductEntity.Category> GetCategories()
        {
            DataTable dt = GetTable();
            List<ProductEntity.Category> ls = new List<ProductEntity.Category>();
            foreach (DataRow row in dt.Rows)
            {
                ProductEntity.Category category = new ProductEntity.Category();
                category.ID = row["categoryid"].ToString();
                category.Name = row["categoryname"].ToString();
                category.Discription = row["discription"].ToString();
                category.CreatedBy = new UserEntity()
                {
                    Username = row["username"].ToString()
                };
                category.CreatedDate = (DateTime) row["createddate"];
                category.CategoryImage = row["categoryimage"].ToString();
                category.StatusId = (int) row["statusid"];
                category.StatusName = row["statusname"].ToString();
                ls.Add(category);
            }
            return ls;
        }

        public ProductEntity.Category GetBasicCategoryById(string id)
        {
            string sql = "select * from tb_category where categoryid = @id";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@id",id)
            };

            DataTable dt = DataConfig.Instance.GetTable(sql, pars);
            if (dt.Rows.Count < 1)
                return null;
            var cate = new ProductEntity.Category();
            cate.ID = dt.Rows[0]["categoryid"].ToString();
            cate.Name = dt.Rows[0]["categoryname"].ToString();
            return cate;
        }

        public int AddCategory(ProductEntity.Category e)
        {
            string sql = "insert into tb_category values(@categoryid, @name, @discription, @image, @date, @by, @status)";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@categoryid", e.ID),
                new SqlParameter("@name", e.Name),
                new SqlParameter("@discription", e.Discription),
                new SqlParameter("@image", e.CategoryImage==null?(object)DBNull.Value : e.CategoryImage),
                new SqlParameter("@date", e.CreatedDate),
                new SqlParameter("@by", e.CreatedBy.Username),
                new SqlParameter("@status", e.StatusId)
            };
            return DataConfig.Instance.ExecuteNonQuery(sql, pars);
        }

        public int DeleteCategory(string id)
        {
            string sql = "delete from tb_category where categoryid = @id";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DataConfig.Instance.ExecuteNonQuery(sql, pars);
        }

        public int UpdateStatus(int statusid, string id)
        {
            string sql = "update tb_category set statusid = @statusid where categoryid = @id";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@statusid", statusid),
                new SqlParameter("@id", id)
            };
            return DataConfig.Instance.ExecuteNonQuery(sql, pars);
        }
    }
}
