using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;
namespace BUS
{
    public class PromotionBus
    {
        static PromotionBus instance;
        public static PromotionBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PromotionBus();
                }
                return instance;
            }
        }

        PromotionEntity RowToEntity (DataRow row)
        {
            var p = new PromotionEntity();
            p.ID = row["promotionid"].ToString().Trim();
            p.Title = row["promotiontitle"].ToString();
            p.ShortDiscription = row["shortdiscription"].ToString();
            p.Discription = row["discription"].ToString();
            p.Image = row["displayimage"].ToString();
            p.Status = StatusBus.Instance.GetStatus((int)row["statusid"]);
            p.CreatedBy = UserBus.Instance.GetUser(row["createdby"].ToString());
            p.CreatedDate = (DateTime)row["createddate"];
            return p;
        }

        public bool HasPromotion(string id)
        {
            string sql = "select * from tb_promotion where promotionid = @id;";
            var pars = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            DataTable dt = DAO.DataConfig.Instance.GetTable(sql, pars);
            return dt.Rows.Count > 0;
        }

        public List<PromotionEntity> GetPromotions()
        {
            string sql = "select * from tb_promotion;";
            DataTable dt = DAO.DataConfig.Instance.GetTable(sql);
            var ls = new List<PromotionEntity>();
            foreach(DataRow row in dt.Rows)
            {
                ls.Add(RowToEntity(row));
            }
            return ls;
        }

        public PromotionEntity GetPromotion(string id)
        {
            string sql = "select * from tb_promotion where promotionid = @id;";
            var pars = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            DataTable dt = DAO.DataConfig.Instance.GetTable(sql, pars);
            if (dt.Rows.Count < 1)
                return null;
            return RowToEntity(dt.Rows[0]);
        }

        public int InsertPromotion(PromotionEntity p)
        {
            string sql = "insert into tb_promotion values(@id, @title, @short, @discription, @image, @status, @createdby, @createddate)";
            var pars = new SqlParameter[] {
                new SqlParameter("@id",p.ID),
                new SqlParameter("@title", p.Title),
                new SqlParameter("@short", p.ShortDiscription),
                new SqlParameter("@discription", p.Discription),
                new SqlParameter("@image", p.Image),
                new SqlParameter("@status", p.StatusID),
                new SqlParameter("@createdby", p.CreatedBy.Username),
                new SqlParameter("@createddate", p.CreatedDate)
            };
            return DAO.DataConfig.Instance.ExecuteNonQuery(sql,pars);
        }

        public int UpdatePromotion(PromotionEntity p, string id)
        {
            string sql = "update tb_promotion set promotiontitle=@title, shortdiscription=@short, discription=@discription, displayimage=@image, statusid=@status where promotionid = @id";
            var pars = new SqlParameter[] {
                new SqlParameter("@id",p.ID),
                new SqlParameter("@title", p.Title),
                new SqlParameter("@short", p.ShortDiscription),
                new SqlParameter("@discription", p.Discription),
                new SqlParameter("@image", p.Image),
                new SqlParameter("@status", p.StatusID)
            };
            return DAO.DataConfig.Instance.ExecuteNonQuery(sql, pars);
        }
        
    }
}
