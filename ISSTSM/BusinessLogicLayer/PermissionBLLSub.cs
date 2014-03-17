// =================================================================== 
// 项目说明
//====================================================================
// 文件： Permission.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
using System.Data;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;
using ISSTSM.DALFactory;
using System.Collections.Generic;

namespace ISSTSM.BusinessLogicLayer
{
    /// <summary>
    /// BLL Layer For dbo.Permission.
    /// </summary>
    public class Permission_BLLSub : PermissionBLLBase
    {
		#region ----------变量定义----------
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public Permission_BLLSub()
		{
		}
		#endregion
		
		#region----------函数定义---------
        public static IList<PermissionEntity> GetPermissionByUserID(int UserID, int ModuleId)
        {
            return _dal.GetPermissionByUserID(UserID,ModuleId);
        }
		#endregion


	}
}
