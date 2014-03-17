// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： Permission.cs
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
    /// 数据层 dbo.Permission 接口。
    /// </summary>
    public interface IPermissionDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_PermissionModel">Permission实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_PermissionInsert(PermissionEntity _PermissionModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_PermissionModel">Permission实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_PermissionInsert(SqlTransaction sp,PermissionEntity _PermissionModel);
		
		/// <summary>
		/// 向数据表Permission更新一条记录。
		/// </summary>
		/// <param name="_PermissionModel">_PermissionModel</param>
		/// <returns>影响的行数</returns>
		int Create_PermissionUpdate(PermissionEntity _PermissionModel);
		
		/// <summary>
		/// 向数据表Permission更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_PermissionModel">_PermissionModel</param>
		/// <returns>影响的行数</returns>
		int Create_PermissionUpdate(SqlTransaction sp,PermissionEntity _PermissionModel);
		
		/// <summary>
		/// 删除数据表Permission中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_PermissionDelete(int iD);
		
		/// <summary>
		/// 删除数据表Permission中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_PermissionDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据Permission返回的查询DataRow创建一个PermissionEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>Permission对象</returns>
		PermissionEntity Populate_PermissionEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 permission 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>permission 数据实体</returns>
		PermissionEntity Get_PermissionEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表Permission所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< PermissionEntity> Get_PermissionAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistPermission(int iD);

        #endregion
    }
}

