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
    /// BLL Layer For dbo.Section.
    /// </summary>
    public class SectionBLLBase
    {
		#region ----------变量定义----------
		///<summary>
		///
		///</summary>
		public static readonly ISectionDataAccessLayer _dal=DataAccessFactory.Create_Section();
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 构造函数
		/// </summary>
		public SectionBLLBase()
		{
		}
		#endregion

        #region ----------函数定义----------
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="oSectionInfo">Section??</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_SectionInsert(SectionEntity oSectionInfo)
		{
			// Validate input
			if (oSectionInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_SectionInsert(oSectionInfo);
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oSectionInfo">Section实体</param>
		/// <returns>新插入记录的编号</returns>
		public static int Create_SectionInsert(SqlTransaction sp,SectionEntity oSectionInfo)
		{
			if (oSectionInfo == null)
				return 0;
			// Use the dal to insert a new record 
			return _dal.Create_SectionInsert(sp,oSectionInfo);
		}
		/// <summary>
		/// 向数据表Section更新一条记录。
		/// </summary>
		/// <param name="oSectionInfo">oSectionInfo</param>
		/// <returns>影响的行数</returns>
		public  static void Create_SectionUpdate(SectionEntity oSectionInfo)
		{
            // Validate input
			if (oSectionInfo==null)
				return;
			// Use the dal to update a new record 
			_dal.Create_SectionUpdate(oSectionInfo);
		}
		/// <summary>
		/// 向数据表Section更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="oSectionInfo">oSectionInfo</param>
		/// <returns>影响的行数</returns>
		public static int Create_SectionUpdate(SqlTransaction sp,SectionEntity oSectionInfo)
		{
			// Validate input
			if (oSectionInfo==null)
				return 0;
			// Use the dal to update a new record 
			return _dal.Create_SectionUpdate(sp,oSectionInfo);
		}
		
		/// <summary>
		/// 删除数据表Section中的一条记录
		/// </summary>
	    /// <param name="iD">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_SectionDelete(int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_SectionDelete(iD);
		}
		/// <summary>
		/// 删除数据表Section中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public static int Create_SectionDelete(SqlTransaction sp,int iD)
		{
			// Validate input
			if(iD<0)
				return 0;
			return _dal.Create_SectionDelete(sp,iD);
		}
		#endregion
		
        /// <summary>
		/// 得到 section 数据实体
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>section 数据实体</returns>
		public static SectionEntity Get_SectionEntity(int iD)
		{
			// Validate input
			if(iD<0)
				return null;

			// Use the dal to get a record 
			return _dal.Get_SectionEntity(iD);
		}
		
		/// <summary>
		/// 得到数据表Section所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public static IList< SectionEntity> Get_SectionAll()
		{
			// Use the dal to get all records 
			return _dal.Get_SectionAll();
		}
			
		
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public static bool IsExistSection(int iD)
		{
			return _dal.IsExistSection(iD);
		}

        #endregion
		
		
    }
}

