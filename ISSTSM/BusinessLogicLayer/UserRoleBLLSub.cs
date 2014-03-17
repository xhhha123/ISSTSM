// =================================================================== 
// 项目说明
//====================================================================
// 文件： UserRole.cs
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
    using ISSTSM.Enity;
    /// <summary>
    /// BLL Layer For dbo.UserRole.
    /// </summary>
    public class UserRole_BLLSub : UserRoleBLLBase
    {
        
		
		
		#region ----------构造函数----------
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public UserRole_BLLSub()
		{
		}
		#endregion
		
		#region----------函数定义---------
		#endregion
        public static List<UserRoleEntity> GetAllByUserID(int Id)
        {
            return _dal.GetAllByUserId(Id);
        }
  
	}
}
