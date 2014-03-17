// =================================================================== 
// 项目说明
//====================================================================
// 文件： ModulePermission.cs
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
    /// 数据层实例化接口类  dbo.ModulePermission.
    /// </summary>
    public partial class ModulePermissionDataAccessLayer : IModulePermissionDataAccessLayer
    {
        /// <summary>
        /// 根据modID获取对应模块所具有的权限集合
        /// </summary>
        /// <param name="modID"></param>
        /// <returns></returns>
        public IList<PermissionEntity> Get_PerByModID(int modID)
        {
            IList<PermissionEntity> list = new List<PermissionEntity>();

            string sqlStr = "select p.ID,p.PermissionName" +
                " from ModulePermission mp,Permission p" +
                " where mp.ModuleID=" + modID + " and p.ID=mp.PermissionID and p.IsVisible=1";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    PermissionEntity entity = new PermissionEntity();
                    entity.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                    entity.PermissionName = dr["PermissionName"].ToString(); ;
                    list.Add(entity);
                }
            }
            return list;
        }

        public int Del_MPByMidPid(int Mid, int Pid)
        {
            string sqlStr = "Delete from ModulePermission where ModuleID=" + Mid + " and PermissionID=" + Pid;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sqlStr);
        }

        public ModulePermissionEntity Get_ModulePermissionEntity(int modID, int perID)
        {
            ModulePermissionEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@ModuleID",SqlDbType.Int),
            new SqlParameter("@PermissionID",SqlDbType.Int),
			};
            _param[0].Value = modID;
            _param[1].Value = perID;
            string sqlStr = "select * from ModulePermission where ModuleID=@ModuleID and PermissionID=@PermissionID";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_ModulePermissionEntity_FromDr(dr);
                }
            }
            return _obj;
        }

        public IList<ModulePermissionEntity> GetAllByModID(string where)
        {
            string sqlStr = "select * from ModulePermission  "+where;
            IList<ModulePermissionEntity> list = new List<ModulePermissionEntity>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    ModulePermissionEntity entity = new ModulePermissionEntity();
                    entity.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                    entity.ModuleID = ((dr["ModuleID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ModuleID"]);
                    entity.PermissionID = ((dr["PermissionID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["PermissionID"]);
                    entity.IsDeleted =(bool) dr["IsDeleted"];
                    list.Add(entity);
                }
            }
            return list;
        }
    }
}
