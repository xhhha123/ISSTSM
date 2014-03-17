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
    /// BLL Layer For dbo.Role.
    /// </summary>
    public class RoleBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IRoleDataAccessLayer _dal=DataAccessFactory.Create_Role();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public RoleBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oRoleInfo">Role??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_RoleInsert(RoleEntity oRoleInfo)
		{
			// Validate input
			if (oRoleInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_RoleInsert(oRoleInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oRoleInfo">Role实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_RoleInsert(SqlTransaction sp,RoleEntity oRoleInfo)
		{
			if (oRoleInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_RoleInsert(sp,oRoleInfo);
		}
		/// <summary>
		/// 向数据表Role更新一条记录。
		/// </summary>
		/// <param name="oRoleInfo">oRoleInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_RoleUpdate(RoleEntity oRoleInfo)
		{
            // Validate input
			if (oRoleInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_RoleUpdate(oRoleInfo);
		}
		/// <summary>
		/// 向数据表Role更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oRoleInfo">oRoleInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_RoleUpdate(SqlTransaction sp,RoleEntity oRoleInfo)
		{
			// Validate input
			if (oRoleInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_RoleUpdate(sp,oRoleInfo);
		}
		
		/// <summary>
		/// 删除数据表Role中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_RoleDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_RoleDelete(iD);
		}
		/// <summary>
		/// 删除数据表Role中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_RoleDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_RoleDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 role 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>role 数据实体</returns>
		public static RoleEntity Get_RoleEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_RoleEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表Role所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< RoleEntity> Get_RoleAll()
		{
			// Use the dal to get all records 
			return _dal.Get_RoleAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistRole(int iD)
		{
			return _dal.IsExistRole(iD);
		}

        #endregion
		
		
    }
}

