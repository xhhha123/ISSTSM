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
    /// BLL Layer For dbo.RoleModulePermission.
    /// </summary>
    public class RoleModulePermissionBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IRoleModulePermissionDataAccessLayer _dal=DataAccessFactory.Create_RoleModulePermission();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public RoleModulePermissionBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oRoleModulePermissionInfo">RoleModulePermission??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_RoleModulePermissionInsert(RoleModulePermissionEntity oRoleModulePermissionInfo)
		{
			// Validate input
			if (oRoleModulePermissionInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_RoleModulePermissionInsert(oRoleModulePermissionInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oRoleModulePermissionInfo">RoleModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_RoleModulePermissionInsert(SqlTransaction sp,RoleModulePermissionEntity oRoleModulePermissionInfo)
		{
			if (oRoleModulePermissionInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_RoleModulePermissionInsert(sp,oRoleModulePermissionInfo);
		}
		/// <summary>
		/// 向数据表RoleModulePermission更新一条记录。
		/// </summary>
		/// <param name="oRoleModulePermissionInfo">oRoleModulePermissionInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_RoleModulePermissionUpdate(RoleModulePermissionEntity oRoleModulePermissionInfo)
		{
            // Validate input
			if (oRoleModulePermissionInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_RoleModulePermissionUpdate(oRoleModulePermissionInfo);
		}
		/// <summary>
		/// 向数据表RoleModulePermission更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oRoleModulePermissionInfo">oRoleModulePermissionInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_RoleModulePermissionUpdate(SqlTransaction sp,RoleModulePermissionEntity oRoleModulePermissionInfo)
		{
			// Validate input
			if (oRoleModulePermissionInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_RoleModulePermissionUpdate(sp,oRoleModulePermissionInfo);
		}
		
		/// <summary>
		/// 删除数据表RoleModulePermission中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_RoleModulePermissionDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_RoleModulePermissionDelete(iD);
		}
		/// <summary>
		/// 删除数据表RoleModulePermission中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_RoleModulePermissionDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_RoleModulePermissionDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 rolemodulepermission 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>rolemodulepermission 数据实体</returns>
		public static RoleModulePermissionEntity Get_RoleModulePermissionEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_RoleModulePermissionEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表RoleModulePermission所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< RoleModulePermissionEntity> Get_RoleModulePermissionAll()
		{
			// Use the dal to get all records 
			return _dal.Get_RoleModulePermissionAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistRoleModulePermission(int iD)
		{
			return _dal.IsExistRoleModulePermission(iD);
		}

        #endregion
		
		
    }
}

