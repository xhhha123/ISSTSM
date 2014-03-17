// =================================================================== 
// 项目说明
//====================================================================
// 文件： Permission.cs
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
    /// 数据层实例化接口类  dbo.Permission.
    /// </summary>
    public partial class PermissionDataAccessLayer : IPermissionDataAccessLayer
    {
        /// <summary>
        /// 根据UserId和ModuleId,返回一个IList<PermissionEntity>集合
        /// </summary>
        /// <param name="UserID">UserID</param>
        ///  <param name="ModuleId">ModuleId</param>
        /// <returns>List<PermissionEntity></returns>
        public IList<PermissionEntity> GetPermissionByUserID(int UserID, int ModuleId)
        {
            IList<PermissionEntity> Obj = new List<PermissionEntity>();
            StringBuilder sqlStr = new StringBuilder(500);
            sqlStr.AppendLine("select * from Permission p where p.ID in");
            sqlStr.AppendLine("(select mp.PermissionID from ModulePermission mp inner join Module m");
            sqlStr.AppendLine("on mp.ModuleID=m.ID where mp.ID in");
            sqlStr.AppendLine("(select rmp.ModulePermissionID from RoleModulePermission rmp ");
            sqlStr.AppendLine("inner join [Role] r on r.ID=rmp.RoleID");
            sqlStr.AppendLine("inner join UserRole ur on ur.RoleID=r.ID");
            sqlStr.AppendLine("inner join UserInfo u on u.ID=ur.UserID");
            sqlStr.AppendLine("where u.ID=" + UserID + " and m.ID=" + ModuleId + "and p.IsVisible=1 and p.IsButton=1" + "))");
            sqlStr.AppendLine("order by p.Sort");
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr.ToString()))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_PermissionEntity_FromDr(dr));
                }
            }
            return Obj;
        }
	}
}
