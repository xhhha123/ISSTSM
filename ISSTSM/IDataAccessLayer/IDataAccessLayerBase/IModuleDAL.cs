// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： Module.cs
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
using ISSTSM.Enity;
namespace ISSTSM.IDataAccessLayer
{
    /// <summary>
    /// 数据层 dbo.Module 接口。
    /// </summary>
    public interface IModuleDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_ModuleModel">Module实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_ModuleInsert(ModuleEntity _ModuleModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ModuleModel">Module实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_ModuleInsert(SqlTransaction sp,ModuleEntity _ModuleModel);
		
		/// <summary>
		/// 向数据表Module更新一条记录。
		/// </summary>
		/// <param name="_ModuleModel">_ModuleModel</param>
		/// <returns>影响的行数</returns>
		int Create_ModuleUpdate(ModuleEntity _ModuleModel);
		
		/// <summary>
		/// 向数据表Module更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ModuleModel">_ModuleModel</param>
		/// <returns>影响的行数</returns>
		int Create_ModuleUpdate(SqlTransaction sp,ModuleEntity _ModuleModel);
		
		/// <summary>
		/// 删除数据表Module中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_ModuleDelete(int iD);
		
		/// <summary>
		/// 删除数据表Module中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_ModuleDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据Module返回的查询DataRow创建一个ModuleEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>Module对象</returns>
		ModuleEntity Populate_ModuleEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 module 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>module 数据实体</returns>
		ModuleEntity Get_ModuleEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表Module所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< ModuleEntity> Get_ModuleAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistModule(int iD);

        #endregion
    }
}

