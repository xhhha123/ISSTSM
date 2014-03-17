// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： DataDictionary.cs
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
    /// 数据层 dbo.DataDictionary 接口。
    /// </summary>
    public interface IDataDictionaryDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_DataDictionaryModel">DataDictionary实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_DataDictionaryInsert(DataDictionaryEntity _DataDictionaryModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_DataDictionaryModel">DataDictionary实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_DataDictionaryInsert(SqlTransaction sp,DataDictionaryEntity _DataDictionaryModel);
		
		/// <summary>
		/// 向数据表DataDictionary更新一条记录。
		/// </summary>
		/// <param name="_DataDictionaryModel">_DataDictionaryModel</param>
		/// <returns>影响的行数</returns>
		int Create_DataDictionaryUpdate(DataDictionaryEntity _DataDictionaryModel);
		
		/// <summary>
		/// 向数据表DataDictionary更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_DataDictionaryModel">_DataDictionaryModel</param>
		/// <returns>影响的行数</returns>
		int Create_DataDictionaryUpdate(SqlTransaction sp,DataDictionaryEntity _DataDictionaryModel);
		
		/// <summary>
		/// 删除数据表DataDictionary中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_DataDictionaryDelete(int iD);
		
		/// <summary>
		/// 删除数据表DataDictionary中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_DataDictionaryDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据DataDictionary返回的查询DataRow创建一个DataDictionaryEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DataDictionary对象</returns>
		DataDictionaryEntity Populate_DataDictionaryEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 datadictionary 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>datadictionary 数据实体</returns>
		DataDictionaryEntity Get_DataDictionaryEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表DataDictionary所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< DataDictionaryEntity> Get_DataDictionaryAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistDataDictionary(int iD);

        #endregion
    }
}

