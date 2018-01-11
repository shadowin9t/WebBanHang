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
    public class PermissionBus
    {
        static PermissionBus instance;
        public static PermissionBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new PermissionBus();
                return instance;
            }
        }
        PermissionBus() { }
        public DataTable GetTable()
        {
            string sql = "select * from tb_permission";
            return new DAO.DataConfig().GetTable(sql);
        }


        public List<PermissionEntity> GetPermissions()
        {
            DataTable dt = GetTable();
            List<PermissionEntity> ls = new List<PermissionEntity>();
            foreach(DataRow row in dt.Rows)
            {
                PermissionEntity p = new PermissionEntity();
                p.Name = row["permissionname"].ToString();
                p.ID = row["permissionid"].ToString().Trim();
                ls.Add(p);
            }
            return ls;
        }
    }
}
