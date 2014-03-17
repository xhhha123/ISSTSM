// =================================================================== 
// 项目说明
//====================================================================
// 文件： UserRole.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;

namespace ISSTSM.DataAccessLayer
{
    /// <summary>
    /// 数据层实例化接口类  dbo.UserRole.
    /// </summary>
    public partial class UserRoleDataAccessLayer : IUserRoleDataAccessLayer
    {
        public List<UserRoleEntity> GetAllByUserId(int id)
        {
            List<UserRoleEntity> _obj = new List<UserRoleEntity>();
            string sqlStr = "select * from UserRole where UserID="+id;
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    _obj.Add(Populate_UserRoleEntity_FromDr(dr));
                }
            }
            return _obj;
        }
	}
}
