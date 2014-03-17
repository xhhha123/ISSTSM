// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： Incident.cs
// 项目名称：SunCity_MS 
// 创建时间：2014/1/9
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
    /// 数据层 dbo.Incident 接口。
    /// </summary>
    public interface IIncidentDataAccessLayerBase
    {
		#region 基本方法
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_IncidentModel">Incident实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_IncidentInsert(IncidentEntity _IncidentModel);
		
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_IncidentModel">Incident实体</param>
		/// <returns>新插入记录的编号</returns>
		int Create_IncidentInsert(SqlTransaction sp,IncidentEntity _IncidentModel);
		
		/// <summary>
		/// 向数据表Incident更新一条记录。
		/// </summary>
		/// <param name="_IncidentModel">_IncidentModel</param>
		/// <returns>影响的行数</returns>
		int Create_IncidentUpdate(IncidentEntity _IncidentModel);
		
		/// <summary>
		/// 向数据表Incident更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_IncidentModel">_IncidentModel</param>
		/// <returns>影响的行数</returns>
		int Create_IncidentUpdate(SqlTransaction sp,IncidentEntity _IncidentModel);
		
		/// <summary>
		/// 删除数据表Incident中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_IncidentDelete(int iD);
		
		/// <summary>
		/// 删除数据表Incident中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		int Create_IncidentDelete(SqlTransaction sp,int iD);
		
		
		/// <summary>
		/// 根据Incident返回的查询DataRow创建一个IncidentEntity对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>Incident对象</returns>
		IncidentEntity Populate_IncidentEntity_FromDr(DataRow row);
		
        /// <summary>
		/// 得到 incident 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>incident 数据实体</returns>
		IncidentEntity Get_IncidentEntity(int iD);
		
		
		/// <summary>
		/// 得到数据表Incident所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< IncidentEntity> Get_IncidentAll();
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		bool IsExistIncident(int iD);

        #endregion
    }
}

