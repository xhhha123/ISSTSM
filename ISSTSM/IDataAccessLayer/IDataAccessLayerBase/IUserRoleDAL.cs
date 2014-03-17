// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： UserRole.cs
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
    /// 数据层 dbo.UserRole 接口。
    /// </summary>
    public interface IUserRoleDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_UserRoleModel">UserRole实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_UserRoleInsert(UserRoleEntity _UserRoleModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_UserRoleModel">UserRole实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_UserRoleInsert(SqlTransaction sp,UserRoleEntity _UserRoleModel);
		
		/// <summary>
		/// 向数据表UserRole更新一条记录。
		/// </summary>
		/// <param name="_UserRoleModel">_UserRoleModel</param>
		/// <returns>影响的行数</returns>
		int Create_UserRoleUpdate(UserRoleEntity _UserRoleModel);
		
		/// <summary>
		/// 向数据表UserRole更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_UserRoleModel">_UserRoleModel</param>
		/// <returns>影响的行数</returns>
		int Create_UserRoleUpdate(SqlTransaction sp,UserRoleEntity _UserRoleModel);
		
		/// <summary>
		/// 删除数据表UserRole中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_UserRoleDelete(int iD);
		
		/// <summary>
		/// 删除数据表UserRole中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_UserRoleDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据UserRole返回的查询DataRow创建一个UserRoleEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>UserRole对象</returns>
		UserRoleEntity Populate_UserRoleEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 userrole 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>userrole 数据实体</returns>
		UserRoleEntity Get_UserRoleEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表UserRole所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< UserRoleEntity> Get_UserRoleAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistUserRole(int iD);

        #endregion
    }
}

