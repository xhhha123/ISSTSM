// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： ModulePermission.cs
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
    /// 数据层 dbo.ModulePermission 接口。
    /// </summary>
    public interface IModulePermissionDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_ModulePermissionModel">ModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_ModulePermissionInsert(ModulePermissionEntity _ModulePermissionModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ModulePermissionModel">ModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_ModulePermissionInsert(SqlTransaction sp,ModulePermissionEntity _ModulePermissionModel);
		
		/// <summary>
		/// 向数据表ModulePermission更新一条记录。
		/// </summary>
		/// <param name="_ModulePermissionModel">_ModulePermissionModel</param>
		/// <returns>影响的行数</returns>
		int Create_ModulePermissionUpdate(ModulePermissionEntity _ModulePermissionModel);
		
		/// <summary>
		/// 向数据表ModulePermission更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ModulePermissionModel">_ModulePermissionModel</param>
		/// <returns>影响的行数</returns>
		int Create_ModulePermissionUpdate(SqlTransaction sp,ModulePermissionEntity _ModulePermissionModel);
		
		/// <summary>
		/// 删除数据表ModulePermission中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_ModulePermissionDelete(int iD);
		
		/// <summary>
		/// 删除数据表ModulePermission中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_ModulePermissionDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据ModulePermission返回的查询DataRow创建一个ModulePermissionEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>ModulePermission对象</returns>
		ModulePermissionEntity Populate_ModulePermissionEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 modulepermission 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>modulepermission 数据实体</returns>
		ModulePermissionEntity Get_ModulePermissionEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表ModulePermission所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< ModulePermissionEntity> Get_ModulePermissionAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistModulePermission(int iD);

        #endregion
    }
}

