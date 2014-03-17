// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： TimeSheet.cs
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
    /// 数据层 dbo.TimeSheet 接口。
    /// </summary>
    public interface ITimeSheetDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_TimeSheetModel">TimeSheet实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_TimeSheetInsert(TimeSheetEntity _TimeSheetModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_TimeSheetModel">TimeSheet实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_TimeSheetInsert(SqlTransaction sp,TimeSheetEntity _TimeSheetModel);
		
		/// <summary>
		/// 向数据表TimeSheet更新一条记录。
		/// </summary>
		/// <param name="_TimeSheetModel">_TimeSheetModel</param>
		/// <returns>影响的行数</returns>
		int Create_TimeSheetUpdate(TimeSheetEntity _TimeSheetModel);
		
		/// <summary>
		/// 向数据表TimeSheet更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_TimeSheetModel">_TimeSheetModel</param>
		/// <returns>影响的行数</returns>
		int Create_TimeSheetUpdate(SqlTransaction sp,TimeSheetEntity _TimeSheetModel);
		
		/// <summary>
		/// 删除数据表TimeSheet中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_TimeSheetDelete(int iD);
		
		/// <summary>
		/// 删除数据表TimeSheet中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_TimeSheetDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据TimeSheet返回的查询DataRow创建一个TimeSheetEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>TimeSheet对象</returns>
		TimeSheetEntity Populate_TimeSheetEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 timesheet 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>timesheet 数据实体</returns>
		TimeSheetEntity Get_TimeSheetEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表TimeSheet所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< TimeSheetEntity> Get_TimeSheetAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistTimeSheet(int iD);

        #endregion
    }
}

