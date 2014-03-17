// =================================================================== 
// 项目说明
//====================================================================
// 文件： Module.cs
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
    /// 数据层实例化接口类  dbo.Module.
    /// </summary>
    public partial class ModuleDataAccessLayer : IModuleDataAccessLayer
    {

        /// <summary>
        /// 根据用户ID得到用户所在的模块
        /// </summary>
        /// <returns>数据集</returns>
        public List<ModuleEntity> Get_ModuleAllByUserID(int id)
        {
            StringBuilder sbsql = new StringBuilder(500);
            string sqlStr = "select * from Module m where m.ID in  ";
            sbsql.Append(sqlStr);
            sbsql.AppendLine(" (select mp.ModuleID from ModulePermission mp where mp.ID in");
            sbsql.AppendLine(" (select rmp.ModulePermissionID from RoleModulePermission rmp");
            sbsql.AppendLine("inner join [Role] r on rmp.RoleID=r.ID");
            sbsql.AppendLine("inner join UserRole ur on ur.RoleID=r.ID");
            sbsql.AppendLine("inner join UserInfo u on u.ID=ur.UserID where u.ID="+id+" and m.IsVisible='1'))");
            sbsql.AppendLine("union all");
            sbsql.AppendLine("select * from Module m where m.ID in ");
            sbsql.AppendLine("(select m.ParentID from Module m where m.ID in ");
            sbsql.AppendLine("(select mp.ModuleID from ModulePermission mp where mp.ID in");
            sbsql.AppendLine("(select rmp.ModulePermissionID from RoleModulePermission rmp");
            sbsql.AppendLine("inner join [Role] r on rmp.RoleID=r.ID");
            sbsql.AppendLine("inner join UserRole ur on ur.RoleID=r.ID");
            sbsql.AppendLine("inner join UserInfo u on u.ID=ur.UserID where u.ID=" + id + " and m.IsVisible='1')))");
            sbsql.AppendLine("order by m.Sort desc");
            List<ModuleEntity> Obj = new List<ModuleEntity>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sbsql.ToString()))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_ModuleEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        /// <summary>
        /// 根据parentID得到用户所在的模块
        /// </summary>
        /// <returns>数据集</returns>
        public List<ModuleEntity> Get_ModuleAllByParentID(int id)
        {
            StringBuilder sbsql = new StringBuilder(500);
            string sqlStr = "select * from Module m where m.ParentID=" + id + "and m.IsVisible='1' order by m.Sort desc";
            sbsql.Append(sqlStr);
            List<ModuleEntity> Obj = new List<ModuleEntity>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sbsql.ToString()))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_ModuleEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        /// <summary>
        /// 根据RoleID得到所有其RoleID为传入值的模块
        /// </summary>
        /// <param name="RoleID">RoleID</param>
        /// <returns></returns>
        public  List<ModuleEntity> Get_ModuleAllByRoleID(int RoleID)
        {
            StringBuilder sbsql = new StringBuilder(500);
            sbsql.Append("select * from Module where Module.ID in");
            sbsql.Append("(select ModuleID from ModulePermission where ModulePermission.ID in");
            sbsql.Append("(select ModulePermissionID from RoleModulePermission where RoleID="+RoleID+")");
            sbsql.Append("  )");
            List<ModuleEntity> Obj = new List<ModuleEntity>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sbsql.ToString()))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_ModuleEntity_FromDr(dr));
                }
            }
            return Obj;
        }
    }


}
