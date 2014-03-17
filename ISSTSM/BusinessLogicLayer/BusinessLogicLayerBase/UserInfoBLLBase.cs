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
    /// BLL Layer For dbo.UserInfo.
    /// </summary>
    public class UserInfoBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IUserInfoDataAccessLayer _dal=DataAccessFactory.Create_UserInfo();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public UserInfoBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oUserInfoInfo">UserInfo??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_UserInfoInsert(UserInfoEntity oUserInfoInfo)
		{
			// Validate input
			if (oUserInfoInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_UserInfoInsert(oUserInfoInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oUserInfoInfo">UserInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_UserInfoInsert(SqlTransaction sp,UserInfoEntity oUserInfoInfo)
		{
			if (oUserInfoInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_UserInfoInsert(sp,oUserInfoInfo);
		}
		/// <summary>
		/// 向数据表UserInfo更新一条记录。
		/// </summary>
		/// <param name="oUserInfoInfo">oUserInfoInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_UserInfoUpdate(UserInfoEntity oUserInfoInfo)
		{
            // Validate input
			if (oUserInfoInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_UserInfoUpdate(oUserInfoInfo);
		}
		/// <summary>
		/// 向数据表UserInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oUserInfoInfo">oUserInfoInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_UserInfoUpdate(SqlTransaction sp,UserInfoEntity oUserInfoInfo)
		{
			// Validate input
			if (oUserInfoInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_UserInfoUpdate(sp,oUserInfoInfo);
		}
		
		/// <summary>
		/// 删除数据表UserInfo中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_UserInfoDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_UserInfoDelete(iD);
		}
		/// <summary>
		/// 删除数据表UserInfo中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_UserInfoDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_UserInfoDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 userinfo 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>userinfo 数据实体</returns>
		public static UserInfoEntity Get_UserInfoEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_UserInfoEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表UserInfo所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< UserInfoEntity> Get_UserInfoAll()
		{
			// Use the dal to get all records 
			return _dal.Get_UserInfoAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistUserInfo(int iD)
		{
			return _dal.IsExistUserInfo(iD);
		}

        #endregion
		
		
    }
}

