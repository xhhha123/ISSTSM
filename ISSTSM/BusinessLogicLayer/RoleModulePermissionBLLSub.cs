// =================================================================== 
// 项目说明
//====================================================================
// 文件： RoleModulePermission.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
using System.Data;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;
using ISSTSM.DALFactory;

namespace ISSTSM.BusinessLogicLayer
{
    /// <summary>
    /// BLL Layer For dbo.RoleModulePermission.
    /// </summary>
    public class RoleModulePermission_BLLSub : RoleModulePermissionBLLBase
    {
		#region ----------变量定义----------
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public RoleModulePermission_BLLSub()
		{
		}
		#endregion
		
		#region----------函数定义---------
        /// <summary>
        /// 根据RoleID以及ModulePermissionID删除数据表RoleModulePermission中的一条记录
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>影响的行数</returns>
        public static int Create_RoleModulePermissionDelete(int RoleID, int MolPerID)
        {
            return _dal.Create_RoleModulePermissionDelete(RoleID,MolPerID);
        }

		#endregion
	}
}
