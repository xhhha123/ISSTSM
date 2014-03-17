// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： UserInfo.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：Chris
// ===================================================================
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using ISSTSM.Entity;
using System.Collections.Generic;
namespace ISSTSM.IDataAccessLayer
{
    /// <summary>
    /// 数据层 dbo.UserInfo 接口。
    /// </summary>
    public interface IUserInfoDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_UserInfoModel">UserInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_UserInfoInsert(UserInfoEntity _UserInfoModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_UserInfoModel">UserInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_UserInfoInsert(SqlTransaction sp,UserInfoEntity _UserInfoModel);
		
		/// <summary>
		/// 向数据表UserInfo更新一条记录。
		/// </summary>
		/// <param name="_UserInfoModel">_UserInfoModel</param>
		/// <returns>影响的行数</returns>
		int Create_UserInfoUpdate(UserInfoEntity _UserInfoModel);
		
		/// <summary>
		/// 向数据表UserInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_UserInfoModel">_UserInfoModel</param>
		/// <returns>影响的行数</returns>
		int Create_UserInfoUpdate(SqlTransaction sp,UserInfoEntity _UserInfoModel);
		
		/// <summary>
		/// 删除数据表UserInfo中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_UserInfoDelete(int iD);
		
		/// <summary>
		/// 删除数据表UserInfo中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_UserInfoDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据UserInfo返回的查询DataRow创建一个UserInfoEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>UserInfo对象</returns>
		UserInfoEntity Populate_UserInfoEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 userinfo 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>userinfo 数据实体</returns>
		UserInfoEntity Get_UserInfoEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表UserInfo所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< UserInfoEntity> Get_UserInfoAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistUserInfo(int iD);

        #endregion
    }
}

