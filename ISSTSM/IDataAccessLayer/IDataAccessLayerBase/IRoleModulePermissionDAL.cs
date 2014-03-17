// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： RoleModulePermission.cs
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
    /// 数据层 dbo.RoleModulePermission 接口。
    /// </summary>
    public interface IRoleModulePermissionDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_RoleModulePermissionModel">RoleModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_RoleModulePermissionInsert(RoleModulePermissionEntity _RoleModulePermissionModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_RoleModulePermissionModel">RoleModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_RoleModulePermissionInsert(SqlTransaction sp,RoleModulePermissionEntity _RoleModulePermissionModel);
		
		/// <summary>
		/// 向数据表RoleModulePermission更新一条记录。
		/// </summary>
		/// <param name="_RoleModulePermissionModel">_RoleModulePermissionModel</param>
		/// <returns>影响的行数</returns>
		int Create_RoleModulePermissionUpdate(RoleModulePermissionEntity _RoleModulePermissionModel);
		
		/// <summary>
		/// 向数据表RoleModulePermission更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_RoleModulePermissionModel">_RoleModulePermissionModel</param>
		/// <returns>影响的行数</returns>
		int Create_RoleModulePermissionUpdate(SqlTransaction sp,RoleModulePermissionEntity _RoleModulePermissionModel);
		
		/// <summary>
		/// 删除数据表RoleModulePermission中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_RoleModulePermissionDelete(int iD);
		
		/// <summary>
		/// 删除数据表RoleModulePermission中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_RoleModulePermissionDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据RoleModulePermission返回的查询DataRow创建一个RoleModulePermissionEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>RoleModulePermission对象</returns>
		RoleModulePermissionEntity Populate_RoleModulePermissionEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 rolemodulepermission 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>rolemodulepermission 数据实体</returns>
		RoleModulePermissionEntity Get_RoleModulePermissionEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表RoleModulePermission所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< RoleModulePermissionEntity> Get_RoleModulePermissionAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistRoleModulePermission(int iD);

        /// <summary>
        /// 根据RoleID以及ModulePermissionID删除数据表RoleModulePermission中的一条记录
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>影响的行数</returns>
        int Create_RoleModulePermissionDelete(int RoleID,int MolPerID);

        #endregion
    }
}

