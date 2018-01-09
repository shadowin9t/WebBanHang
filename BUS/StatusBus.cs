using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;
using DAO;
namespace BUS
{
    public class StatusBus
    {
        static StatusBus instance;
        public static StatusBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusBus();
                return instance;
            }
        }

        public DataTable GetTable()
        {
            string sql = "select * from tb_status;";
            return DAO.DataConfig.Instance.GetTable(sql);
        }

        public List<StatusEntity> GetStatuses()
        {
            DataTable dt = GetTable();
            List<StatusEntity> ls = new List<StatusEntity>();
            foreach(DataRow row in dt.Rows)
            {
                StatusEntity e = new StatusEntity();
                e.Id = (int) row["statusid"];
                e.Name = row["statusname"].ToString().Trim();
                ls.Add(e);
            }
            return ls;
        }

        public StatusEntity GetStatus(int id)
        {
            string sql = "select * from tb_status where statusid = @id";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            DataTable dt = DataConfig.Instance.GetTable(sql,pars);
            if (dt.Rows.Count < 1)
                return null;
            StatusEntity status = new StatusEntity();
            status.Id = (int)dt.Rows[0]["statusid"];
            status.Name = dt.Rows[0]["statusname"].ToString();
            return status;
        }
    }
}
