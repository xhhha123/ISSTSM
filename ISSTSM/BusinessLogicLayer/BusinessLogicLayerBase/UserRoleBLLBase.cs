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
    /// BLL Layer For dbo.UserRole.
    /// </summary>
    public class UserRoleBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IUserRoleDataAccessLayer _dal=DataAccessFactory.Create_UserRole();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public UserRoleBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oUserRoleInfo">UserRole??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_UserRoleInsert(UserRoleEntity oUserRoleInfo)
		{
			// Validate input
			if (oUserRoleInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_UserRoleInsert(oUserRoleInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oUserRoleInfo">UserRole实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_UserRoleInsert(SqlTransaction sp,UserRoleEntity oUserRoleInfo)
		{
			if (oUserRoleInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_UserRoleInsert(sp,oUserRoleInfo);
		}
		/// <summary>
		/// 向数据表UserRole更新一条记录。
		/// </summary>
		/// <param name="oUserRoleInfo">oUserRoleInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_UserRoleUpdate(UserRoleEntity oUserRoleInfo)
		{
            // Validate input
			if (oUserRoleInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_UserRoleUpdate(oUserRoleInfo);
		}
		/// <summary>
		/// 向数据表UserRole更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oUserRoleInfo">oUserRoleInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_UserRoleUpdate(SqlTransaction sp,UserRoleEntity oUserRoleInfo)
		{
			// Validate input
			if (oUserRoleInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_UserRoleUpdate(sp,oUserRoleInfo);
		}
		
		/// <summary>
		/// 删除数据表UserRole中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_UserRoleDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_UserRoleDelete(iD);
		}
		/// <summary>
		/// 删除数据表UserRole中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_UserRoleDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_UserRoleDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 userrole 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>userrole 数据实体</returns>
		public static UserRoleEntity Get_UserRoleEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_UserRoleEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表UserRole所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< UserRoleEntity> Get_UserRoleAll()
		{
			// Use the dal to get all records 
			return _dal.Get_UserRoleAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistUserRole(int iD)
		{
			return _dal.IsExistUserRole(iD);
		}

        #endregion
		
		
    }
}

