// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： Section.cs
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
    /// 数据层 dbo.Section 接口。
    /// </summary>
    public interface ISectionDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_SectionModel">Section实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_SectionInsert(SectionEntity _SectionModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_SectionModel">Section实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_SectionInsert(SqlTransaction sp,SectionEntity _SectionModel);
		
		/// <summary>
		/// 向数据表Section更新一条记录。
		/// </summary>
		/// <param name="_SectionModel">_SectionModel</param>
		/// <returns>影响的行数</returns>
		int Create_SectionUpdate(SectionEntity _SectionModel);
		
		/// <summary>
		/// 向数据表Section更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_SectionModel">_SectionModel</param>
		/// <returns>影响的行数</returns>
		int Create_SectionUpdate(SqlTransaction sp,SectionEntity _SectionModel);
		
		/// <summary>
		/// 删除数据表Section中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_SectionDelete(int iD);
		
		/// <summary>
		/// 删除数据表Section中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_SectionDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据Section返回的查询DataRow创建一个SectionEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>Section对象</returns>
		SectionEntity Populate_SectionEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 section 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>section 数据实体</returns>
		SectionEntity Get_SectionEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表Section所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< SectionEntity> Get_SectionAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistSection(int iD);

        #endregion
    }
}

