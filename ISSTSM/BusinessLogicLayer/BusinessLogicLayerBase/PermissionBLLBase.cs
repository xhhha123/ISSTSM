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
    /// BLL Layer For dbo.Permission.
    /// </summary>
    public class PermissionBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IPermissionDataAccessLayer _dal=DataAccessFactory.Create_Permission();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public PermissionBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oPermissionInfo">Permission??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_PermissionInsert(PermissionEntity oPermissionInfo)
		{
			// Validate input
			if (oPermissionInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_PermissionInsert(oPermissionInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oPermissionInfo">Permission实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_PermissionInsert(SqlTransaction sp,PermissionEntity oPermissionInfo)
		{
			if (oPermissionInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_PermissionInsert(sp,oPermissionInfo);
		}
		/// <summary>
		/// 向数据表Permission更新一条记录。
		/// </summary>
		/// <param name="oPermissionInfo">oPermissionInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_PermissionUpdate(PermissionEntity oPermissionInfo)
		{
            // Validate input
			if (oPermissionInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_PermissionUpdate(oPermissionInfo);
		}
		/// <summary>
		/// 向数据表Permission更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oPermissionInfo">oPermissionInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_PermissionUpdate(SqlTransaction sp,PermissionEntity oPermissionInfo)
		{
			// Validate input
			if (oPermissionInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_PermissionUpdate(sp,oPermissionInfo);
		}
		
		/// <summary>
		/// 删除数据表Permission中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_PermissionDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_PermissionDelete(iD);
		}
		/// <summary>
		/// 删除数据表Permission中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_PermissionDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_PermissionDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 permission 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>permission 数据实体</returns>
		public static PermissionEntity Get_PermissionEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_PermissionEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表Permission所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< PermissionEntity> Get_PermissionAll()
		{
			// Use the dal to get all records 
			return _dal.Get_PermissionAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistPermission(int iD)
		{
			return _dal.IsExistPermission(iD);
		}

        #endregion
		
		
    }
}

