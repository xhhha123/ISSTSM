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
    /// BLL Layer For dbo.DataDictionary.
    /// </summary>
    public class DataDictionaryBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IDataDictionaryDataAccessLayer _dal=DataAccessFactory.Create_DataDictionary();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public DataDictionaryBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oDataDictionaryInfo">DataDictionary??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_DataDictionaryInsert(DataDictionaryEntity oDataDictionaryInfo)
		{
			// Validate input
			if (oDataDictionaryInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_DataDictionaryInsert(oDataDictionaryInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oDataDictionaryInfo">DataDictionary实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_DataDictionaryInsert(SqlTransaction sp,DataDictionaryEntity oDataDictionaryInfo)
		{
			if (oDataDictionaryInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_DataDictionaryInsert(sp,oDataDictionaryInfo);
		}
		/// <summary>
		/// 向数据表DataDictionary更新一条记录。
		/// </summary>
		/// <param name="oDataDictionaryInfo">oDataDictionaryInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_DataDictionaryUpdate(DataDictionaryEntity oDataDictionaryInfo)
		{
            // Validate input
			if (oDataDictionaryInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_DataDictionaryUpdate(oDataDictionaryInfo);
		}
		/// <summary>
		/// 向数据表DataDictionary更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oDataDictionaryInfo">oDataDictionaryInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_DataDictionaryUpdate(SqlTransaction sp,DataDictionaryEntity oDataDictionaryInfo)
		{
			// Validate input
			if (oDataDictionaryInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_DataDictionaryUpdate(sp,oDataDictionaryInfo);
		}
		
		/// <summary>
		/// 删除数据表DataDictionary中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_DataDictionaryDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_DataDictionaryDelete(iD);
		}
		/// <summary>
		/// 删除数据表DataDictionary中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_DataDictionaryDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_DataDictionaryDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 datadictionary 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>datadictionary 数据实体</returns>
		public static DataDictionaryEntity Get_DataDictionaryEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_DataDictionaryEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表DataDictionary所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< DataDictionaryEntity> Get_DataDictionaryAll()
		{
			// Use the dal to get all records 
			return _dal.Get_DataDictionaryAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistDataDictionary(int iD)
		{
			return _dal.IsExistDataDictionary(iD);
		}

        #endregion
		
		
    }
}

