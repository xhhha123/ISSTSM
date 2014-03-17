// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： Role.cs
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
    /// 数据层 dbo.Role 接口。
    /// </summary>
    public interface IRoleDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_RoleModel">Role实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_RoleInsert(RoleEntity _RoleModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_RoleModel">Role实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_RoleInsert(SqlTransaction sp,RoleEntity _RoleModel);
		
		/// <summary>
		/// 向数据表Role更新一条记录。
		/// </summary>
		/// <param name="_RoleModel">_RoleModel</param>
		/// <returns>影响的行数</returns>
		int Create_RoleUpdate(RoleEntity _RoleModel);
		
		/// <summary>
		/// 向数据表Role更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_RoleModel">_RoleModel</param>
		/// <returns>影响的行数</returns>
		int Create_RoleUpdate(SqlTransaction sp,RoleEntity _RoleModel);
		
		/// <summary>
		/// 删除数据表Role中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_RoleDelete(int iD);
		
		/// <summary>
		/// 删除数据表Role中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_RoleDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据Role返回的查询DataRow创建一个RoleEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>Role对象</returns>
		RoleEntity Populate_RoleEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 role 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>role 数据实体</returns>
		RoleEntity Get_RoleEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表Role所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< RoleEntity> Get_RoleAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistRole(int iD);

        #endregion
    }
}

