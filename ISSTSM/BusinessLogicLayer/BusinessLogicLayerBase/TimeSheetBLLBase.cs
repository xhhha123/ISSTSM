using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;
using ISSTSM.DALFactory;

namespace ISSTSM.BusinessLogicLayer
{
    /// <summary>
    /// BLL Layer For dbo.TimeSheet.
    /// </summary>
    public class TimeSheetBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly ITimeSheetDataAccessLayer _dal=DataAccessFactory.Create_TimeSheet();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public TimeSheetBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oTimeSheetInfo">TimeSheet??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_TimeSheetInsert(TimeSheetEntity oTimeSheetInfo)
		{
			// Validate input
			if (oTimeSheetInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_TimeSheetInsert(oTimeSheetInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oTimeSheetInfo">TimeSheet实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_TimeSheetInsert(SqlTransaction sp,TimeSheetEntity oTimeSheetInfo)
		{
			if (oTimeSheetInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_TimeSheetInsert(sp,oTimeSheetInfo);
		}
		/// <summary>
		/// 向数据表TimeSheet更新一条记录。
		/// </summary>
		/// <param name="oTimeSheetInfo">oTimeSheetInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_TimeSheetUpdate(TimeSheetEntity oTimeSheetInfo)
		{
            // Validate input
			if (oTimeSheetInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_TimeSheetUpdate(oTimeSheetInfo);
		}
		/// <summary>
		/// 向数据表TimeSheet更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oTimeSheetInfo">oTimeSheetInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_TimeSheetUpdate(SqlTransaction sp,TimeSheetEntity oTimeSheetInfo)
		{
			// Validate input
			if (oTimeSheetInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_TimeSheetUpdate(sp,oTimeSheetInfo);
		}
		
		/// <summary>
		/// 删除数据表TimeSheet中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_TimeSheetDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_TimeSheetDelete(iD);
		}
		/// <summary>
		/// 删除数据表TimeSheet中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_TimeSheetDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_TimeSheetDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 timesheet 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>timesheet 数据实体</returns>
		public static TimeSheetEntity Get_TimeSheetEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_TimeSheetEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表TimeSheet所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< TimeSheetEntity> Get_TimeSheetAll()
		{
			// Use the dal to get all records 
			return _dal.Get_TimeSheetAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistTimeSheet(int iD)
		{
			return _dal.IsExistTimeSheet(iD);
		}

        #endregion
		
		
    }
}

