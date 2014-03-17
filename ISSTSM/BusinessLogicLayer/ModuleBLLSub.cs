// =================================================================== 
// 项目说明
//====================================================================
// 文件： Module.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
using System.Data;
using System.Collections.Generic;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;
using ISSTSM.DALFactory;


namespace ISSTSM.BusinessLogicLayer
{
    /// <summary>
    /// BLL Layer For dbo.Module.
    /// </summary>
    public class Module_BLLSub : ModuleBLLBase
    {
		#region ----------变量定义----------
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public Module_BLLSub()
		{
		}
		#endregion
		
		#region----------函数定义---------

        /// <summary>
        /// 根据用户ID得到用户所在的模块
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public static List<ModuleEntity> Get_ModuleAllByUserID(int id)
        {
            return _dal.Get_ModuleAllByUserID(id);
        }

        /// <summary>
        /// 根据parentID得到所有其parentID为传入值的模块
        /// </summary>
        /// <param name="id">parentID</param>
        /// <returns></returns>
        public static List<ModuleEntity> Get_ModuleAllByParentID(int parentID)
        {
            return _dal.Get_ModuleAllByParentID(parentID);
        }
        /// <summary>
        /// 根据RoleID得到所有其RoleID为传入值的模块
        /// </summary>
        /// <param name="RoleID">RoleID</param>
        /// <returns></returns>
        public static List<ModuleEntity> Get_ModuleAllByRoleID(int RoleID)
        {
            return _dal.Get_ModuleAllByRoleID(RoleID);
        }

		#endregion


	}
}
