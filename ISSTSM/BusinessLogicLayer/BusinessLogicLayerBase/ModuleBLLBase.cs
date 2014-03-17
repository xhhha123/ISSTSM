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
    /// BLL Layer For dbo.Module.
    /// </summary>
    public class ModuleBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly IModuleDataAccessLayer _dal=DataAccessFactory.Create_Module();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public ModuleBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oModuleInfo">Module??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_ModuleInsert(ModuleEntity oModuleInfo)
		{
			// Validate input
			if (oModuleInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_ModuleInsert(oModuleInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oModuleInfo">Module实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_ModuleInsert(SqlTransaction sp,ModuleEntity oModuleInfo)
		{
			if (oModuleInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_ModuleInsert(sp,oModuleInfo);
		}
		/// <summary>
		/// 向数据表Module更新一条记录。
		/// </summary>
		/// <param name="oModuleInfo">oModuleInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_ModuleUpdate(ModuleEntity oModuleInfo)
		{
            // Validate input
			if (oModuleInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_ModuleUpdate(oModuleInfo);
		}
		/// <summary>
		/// 向数据表Module更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oModuleInfo">oModuleInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_ModuleUpdate(SqlTransaction sp,ModuleEntity oModuleInfo)
		{
			// Validate input
			if (oModuleInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_ModuleUpdate(sp,oModuleInfo);
		}
		
		/// <summary>
		/// 删除数据表Module中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_ModuleDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_ModuleDelete(iD);
		}
		/// <summary>
		/// 删除数据表Module中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_ModuleDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_ModuleDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 module 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>module 数据实体</returns>
		public static ModuleEntity Get_ModuleEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_ModuleEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表Module所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< ModuleEntity> Get_ModuleAll()
		{
			// Use the dal to get all records 
			return _dal.Get_ModuleAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistModule(int iD)
		{
			return _dal.IsExistModule(iD);
		}

        #endregion
		
		
    }
}

