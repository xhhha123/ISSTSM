// =================================================================== 
// 项目说明
//====================================================================
// 文件： RoleModulePermission.cs
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
    /// 数据层实例化接口类  dbo.RoleModulePermission.
    /// </summary>
    public partial class RoleModulePermissionDataAccessLayer : IRoleModulePermissionDataAccessLayer
    {
        /// <summary>
        /// 根据RoleID以及ModulePermissionID删除数据表RoleModulePermission中的一条记录
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>影响的行数</returns>
        public  int Create_RoleModulePermissionDelete(int RoleID, int MolPerID)
        {
            string sqlStr = "delete from RoleModulePermission  where  RoleID = @RoleID and ModulePermissionID=@ModulePermissionID";
            SqlParameter[] _param ={
			new SqlParameter("@RoleID",SqlDbType.Int),
			new SqlParameter("@ModulePermissionID",SqlDbType.Int),
			
			};
            _param[0].Value = RoleID;
            _param[1].Value = MolPerID;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sqlStr, _param);
        }
	}
    
}
