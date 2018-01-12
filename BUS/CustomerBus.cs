using DAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CustomerBus
    {
        static CustomerBus instance;
        public static CustomerBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerBus();
                return instance;
            }
        }
       
        public bool HasCustomer(string email)
        {
            string sql = "select * from tb_customer where email = @email;";
            SqlParameter[] par = new SqlParameter[] {
                new SqlParameter("@email",email)
            };
            return DataConfig.Instance.GetTable(sql, par).Rows.Count > 0;
        }
      
        public CustomerEntity GetCustomer(string email)
        {
            string sql = "select * from tb_user where email = @email;";
            SqlParameter[] par = new SqlParameter[] {
                new SqlParameter("@email",email)
            };
            DataTable dt = DataConfig.Instance.GetTable(sql, par);
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                return new CustomerEntity(row);
            }
            return null;            
        }

        public bool AddCustomer(CustomerEntity cus)
        {
            string sql = "insert into tb_customer values(@customerid, @phone, @address, @firtname, @lastname, @createddate, @email, @pass);";
            SqlParameter[] par = new SqlParameter[] {
                new SqlParameter("@customerid",cus.CustomerId),
                new SqlParameter("@pass", cus.Pass),
                new SqlParameter("@firtname",cus.FirstName),
                new SqlParameter("@lastname",cus.LastName),
                new SqlParameter("@email",cus.Email),
                new SqlParameter("@createddate",cus.CreatedDate),
                new SqlParameter("@address",cus.Adress),
                new SqlParameter("@phone",cus.Phone),
            };
            int n = DataConfig.Instance.ExecuteNonQuery(sql, par);
            return n == 1;
        }
        /*
                public List<CustomerEntity> GetAllCustomer(string email)
                {
                    string sql = "select * from tb_user where email = @email;";
                    SqlParameter[] par = new SqlParameter[] {
                        new SqlParameter("@email",email)
                    };
                    DataTable dt = DataConfig.Instance.GetTable(sql, par);
                    if (dt.Rows.Count == 1)
                    {
                        DataRow row = dt.Rows[0];
                        return new CustomerEntity(row);
                    }
                    return null;
                }

                public bool AddUser(UserEntity user)
                {
                    string sql = "insert into tb_user values(@username, @password, @firstname, @lastname,@email);";
                    SqlParameter[] par = new SqlParameter[] {
                        new SqlParameter("@username",user.Username),
                        new SqlParameter("@password",Hash.getHashSha256(user.Password)),
                        new SqlParameter("@firstname",user.Firstname),
                        new SqlParameter("@lastname",user.Lastname),
                        new SqlParameter("@email",user.Email)
                    };
                    int n = DataConfig.Instance.ExecuteNonQuery(sql, par);
                    return n == 1;
                }

                public bool DeleteUser(string username)
                {
                    string sql = "delete from tb_user where username = @username;";
                    SqlParameter[] par = new SqlParameter[]
                    {
                        new SqlParameter("@username",username)
                    };
                    return DataConfig.Instance.ExecuteNonQuery(sql, par) == 1;
                }

                public bool UpdatePassword(string username, string oldpwd)
                {
                    string sql = "update tb_user set password = @pwd where username = @username";
                    var pars = new SqlParameter[] {
                        new SqlParameter("@username", username),
                        new SqlParameter("@pwd",Hash.getHashSha256(oldpwd))
                    };
                    return DataConfig.Instance.ExecuteNonQuery(sql, pars) > 0;
                }

                public bool UpdateUser(UserEntity user)
                {
                    string sql = "update tb_user set firstname = @firstname, lastname = @lastname, email = @email where username = @username";
                    SqlParameter[] par = new SqlParameter[] {
                        new SqlParameter("@username",user.Username),
                        new SqlParameter("@firstname",user.Firstname),
                        new SqlParameter("@lastname",user.Lastname),
                        new SqlParameter("@email",user.Email)
                    };
                    return DataConfig.Instance.ExecuteNonQuery(sql, par) == 1;
                }

                public DataTable GetTable()
                {
                    string sql = "select * from tb_user;";
                    DataTable dt = DataConfig.Instance.GetTable(sql);
                    return dt;
                }

                public List<UserEntity> GetUsers()
                {
                    DataTable dt = GetTable();
                    List<UserEntity> ls = new List<UserEntity>();
                    foreach (DataRow row in dt.Rows)
                    {
                        ls.Add(GetUser(row));
                    }
                    return ls;
                }

                public string GetRole(string username)
                {
                    return "";
                }

                public List<PermissionEntity> GetPermission(string username)
                {
                    string sql = "select * from tb_permission_user where username=@username;";
                    SqlParameter[] pars = new SqlParameter[]
                    {
                        new SqlParameter("@username", username)
                    };
                    DataTable dt = DataConfig.Instance.GetTable(sql, pars);
                    List<PermissionEntity> roles = new List<PermissionEntity>();
                    foreach (DataRow row in dt.Rows)
                    {
                        var p = new PermissionEntity();
                        p.ID = row["permissionid"].ToString().Trim();
                        roles.Add(p);
                    }
                    return roles;
                }

                public string GetPermissionStr(string username)
                {
                    var ls = GetPermission(username);
                    string str = "admin";
                    foreach (var p in ls)
                    {
                        str += "," + p.ID;
                    }
                    return str;
                }

                public int AddPermission(UserEntity user, PermissionEntity p)
                {
                    string sql = "insert into tb_permission_user values(@permission, @username)";
                    var pars = new SqlParameter[] {
                        new SqlParameter("@username", user.Username),
                        new SqlParameter("@permission", p.ID)
                    };
                    return DataConfig.Instance.ExecuteNonQuery(sql, pars);
                }

                public int UpdatePermission(UserEntity user, List<PermissionEntity> pers)
                {
                    string sql = "delete from tb_permission_user where username = @username";
                    SqlParameter[] pars = new SqlParameter[] {
                        new SqlParameter("@username", user.Username)
                    };
                    DataConfig.Instance.ExecuteNonQuery(sql, pars);
                    int count = 0;
                    foreach (var p in pers)
                    {
                        count += AddPermission(user, p);
                    }
                    return count;
                }*/
    }
}
