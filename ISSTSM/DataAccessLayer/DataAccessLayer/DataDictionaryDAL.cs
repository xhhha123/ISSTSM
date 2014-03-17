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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;

namespace ISSTSM.DataAccessLayer
{
    /// <summary>
    /// 数据层实例化接口类 dbo.DataDictionary.
    /// </summary>
    public partial class DataDictionaryDataAccessLayer : IDataDictionaryDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public DataDictionaryDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_DataDictionaryModel">DataDictionary实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_DataDictionaryInsert(DataDictionaryEntity _DataDictionaryModel)
		{
			string sqlStr="CreateUpdateDelete_DataDictionaryEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ParentID",SqlDbType.Int),
			new SqlParameter("@ItemCode",SqlDbType.VarChar),
			new SqlParameter("@ItemName",SqlDbType.VarChar),
			new SqlParameter("@IsVisible",SqlDbType.Bit),
            new SqlParameter("@Sort",SqlDbType.Int)
			};
			_param[0].Value=0;
			_param[1].Value=_DataDictionaryModel.ID;
			_param[2].Value=_DataDictionaryModel.ParentID;
			_param[3].Value=_DataDictionaryModel.ItemCode;
			_param[4].Value=_DataDictionaryModel.ItemName;
			_param[5].Value=_DataDictionaryModel.IsVisible;
            _param[6].Value = _DataDictionaryModel.Sort;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_DataDictionaryModel">DataDictionary实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_DataDictionaryInsert(SqlTransaction sp,DataDictionaryEntity _DataDictionaryModel)
		{
			string sqlStr="CreateUpdateDelete_DataDictionaryEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ParentID",SqlDbType.Int),
			new SqlParameter("@ItemCode",SqlDbType.VarChar),
			new SqlParameter("@ItemName",SqlDbType.VarChar),
			new SqlParameter("@IsVisible",SqlDbType.Bit)
			};
			_param[0].Value=0;
			_param[1].Value=_DataDictionaryModel.ID;
			_param[2].Value=_DataDictionaryModel.ParentID;
			_param[3].Value=_DataDictionaryModel.ItemCode;
			_param[4].Value=_DataDictionaryModel.ItemName;
			_param[5].Value=_DataDictionaryModel.IsVisible;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表DataDictionary更新一条记录。
		/// </summary>
		/// <param name="_DataDictionaryModel">_DataDictionaryModel</param>
		/// <returns>影响的行数</returns>
		public int Create_DataDictionaryUpdate(DataDictionaryEntity _DataDictionaryModel)
		{
            string sqlStr="CreateUpdateDelete_DataDictionaryEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ParentID",SqlDbType.Int),
				new SqlParameter("@ItemCode",SqlDbType.VarChar),
				new SqlParameter("@ItemName",SqlDbType.VarChar),
				new SqlParameter("@IsVisible",SqlDbType.Bit),
                new SqlParameter("@Sort",SqlDbType.Int)
				};
				_param[0].Value=1;
				_param[1].Value=_DataDictionaryModel.ID;
				_param[2].Value=_DataDictionaryModel.ParentID;
				_param[3].Value=_DataDictionaryModel.ItemCode;
				_param[4].Value=_DataDictionaryModel.ItemName;
				_param[5].Value=_DataDictionaryModel.IsVisible;
                _param[6].Value = _DataDictionaryModel.Sort;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表DataDictionary更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_DataDictionaryModel">_DataDictionaryModel</param>
		/// <returns>影响的行数</returns>
		public int Create_DataDictionaryUpdate(SqlTransaction sp,DataDictionaryEntity _DataDictionaryModel)
		{
            string sqlStr="CreateUpdateDelete_DataDictionaryEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ParentID",SqlDbType.Int),
				new SqlParameter("@ItemCode",SqlDbType.VarChar),
				new SqlParameter("@ItemName",SqlDbType.VarChar),
				new SqlParameter("@IsVisible",SqlDbType.Bit)
				};
				_param[0].Value=1;
				_param[1].Value=_DataDictionaryModel.ID;
				_param[2].Value=_DataDictionaryModel.ParentID;
				_param[3].Value=_DataDictionaryModel.ItemCode;
				_param[4].Value=_DataDictionaryModel.ItemName;
				_param[5].Value=_DataDictionaryModel.IsVisible;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表DataDictionary中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_DataDictionaryDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_DataDictionaryEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表DataDictionary中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_DataDictionaryDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_DataDictionaryEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  datadictionary 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>datadictionary 数据实体</returns>
		public DataDictionaryEntity Populate_DataDictionaryEntity_FromDr(DataRow row)
		{
			DataDictionaryEntity Obj = new DataDictionaryEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.ParentID = (( row["ParentID"])==DBNull.Value)?0:Convert.ToInt32( row["ParentID"]);
				Obj.ItemCode =  row["ItemCode"].ToString();
				Obj.ItemName =  row["ItemName"].ToString();
				Obj.IsVisible = (bool) row["IsVisible"];
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  datadictionary 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>datadictionary 数据实体</returns>
		public DataDictionaryEntity Populate_DataDictionaryEntity_FromDr(IDataReader dr)
		{
			DataDictionaryEntity Obj = new DataDictionaryEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.ParentID = (( dr["ParentID"])==DBNull.Value)?0:Convert.ToInt32( dr["ParentID"]);
				Obj.ItemCode =  dr["ItemCode"].ToString();
				Obj.ItemName =  dr["ItemName"].ToString();
				Obj.IsVisible = (bool) dr["IsVisible"];
                Obj.Sort =Convert.ToInt32(dr["Sort"]);
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个DataDictionary对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>DataDictionary对象</returns>
		public DataDictionaryEntity Get_DataDictionaryEntity (int iD)
		{
			DataDictionaryEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from DataDictionary where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_DataDictionaryEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表DataDictionary所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< DataDictionaryEntity> Get_DataDictionaryAll()
		{
			IList< DataDictionaryEntity> Obj=new List< DataDictionaryEntity>();
			string sqlStr="select * from DataDictionary";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_DataDictionaryEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistDataDictionary(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from DataDictionary where ID=@iD";
            int a=Convert.ToInt32(SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.Text,sqlStr,_param));
            if(a>0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

        #endregion
		
		#region----------自定义实例化接口函数----------
		#endregion
    }
}
