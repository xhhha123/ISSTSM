using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;
using ISSTSM.DALFactory;

namespace ISSTSM.BusinessLogicLayer
{
    /// <summary>
    /// BLL Layer For dbo.ModulePermission.
    /// </summary>
    public class ModulePermissionBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IModulePermissionDataAccessLayer _dal=DataAccessFactory.Create_ModulePermission();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public ModulePermissionBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oModulePermissionInfo">ModulePermission??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_ModulePermissionInsert(ModulePermissionEntity oModulePermissionInfo)
		{
			// Validate input
			if (oModulePermissionInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_ModulePermissionInsert(oModulePermissionInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oModulePermissionInfo">ModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_ModulePermissionInsert(SqlTransaction sp,ModulePermissionEntity oModulePermissionInfo)
		{
			if (oModulePermissionInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_ModulePermissionInsert(sp,oModulePermissionInfo);
		}
		/// <summary>
		/// 向数据表ModulePermission更新一条记录。
		/// </summary>
		/// <param name="oModulePermissionInfo">oModulePermissionInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_ModulePermissionUpdate(ModulePermissionEntity oModulePermissionInfo)
		{
            // Validate input
			if (oModulePermissionInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_ModulePermissionUpdate(oModulePermissionInfo);
		}
		/// <summary>
		/// 向数据表ModulePermission更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oModulePermissionInfo">oModulePermissionInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_ModulePermissionUpdate(SqlTransaction sp,ModulePermissionEntity oModulePermissionInfo)
		{
			// Validate input
			if (oModulePermissionInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_ModulePermissionUpdate(sp,oModulePermissionInfo);
		}
		
		/// <summary>
		/// 删除数据表ModulePermission中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_ModulePermissionDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_ModulePermissionDelete(iD);
		}
		/// <summary>
		/// 删除数据表ModulePermission中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_ModulePermissionDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_ModulePermissionDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 modulepermission 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>modulepermission 数据实体</returns>
		public static ModulePermissionEntity Get_ModulePermissionEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_ModulePermissionEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表ModulePermission所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< ModulePermissionEntity> Get_ModulePermissionAll()
		{
			// Use the dal to get all records 
			return _dal.Get_ModulePermissionAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistModulePermission(int iD)
		{
			return _dal.IsExistModulePermission(iD);
		}

        #endregion
		
		
    }
}

