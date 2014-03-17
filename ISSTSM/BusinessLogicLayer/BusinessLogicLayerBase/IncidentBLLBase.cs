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
    /// BLL Layer For dbo.Incident.
    /// </summary>
    public class IncidentBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IIncidentDataAccessLayer _dal=DataAccessFactory.Create_Incident();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public IncidentBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oIncidentInfo">Incident??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_IncidentInsert(IncidentEntity oIncidentInfo)
		{
			// Validate input
			if (oIncidentInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_IncidentInsert(oIncidentInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oIncidentInfo">Incident实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_IncidentInsert(SqlTransaction sp,IncidentEntity oIncidentInfo)
		{
			if (oIncidentInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_IncidentInsert(sp,oIncidentInfo);
		}
		/// <summary>
		/// 向数据表Incident更新一条记录。
		/// </summary>
		/// <param name="oIncidentInfo">oIncidentInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_IncidentUpdate(IncidentEntity oIncidentInfo)
		{
            // Validate input
			if (oIncidentInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_IncidentUpdate(oIncidentInfo);
		}
		/// <summary>
		/// 向数据表Incident更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oIncidentInfo">oIncidentInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_IncidentUpdate(SqlTransaction sp,IncidentEntity oIncidentInfo)
		{
			// Validate input
			if (oIncidentInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_IncidentUpdate(sp,oIncidentInfo);
		}
		
		/// <summary>
		/// 删除数据表Incident中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_IncidentDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_IncidentDelete(iD);
		}
		/// <summary>
		/// 删除数据表Incident中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_IncidentDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_IncidentDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 incident 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>incident 数据实体</returns>
		public static IncidentEntity Get_IncidentEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_IncidentEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表Incident所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< IncidentEntity> Get_IncidentAll()
		{
			// Use the dal to get all records 
			return _dal.Get_IncidentAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistIncident(int iD)
		{
			return _dal.IsExistIncident(iD);
		}

        #endregion
		
		
    }
}

