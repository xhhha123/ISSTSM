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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;

namespace ISSTSM.DataAccessLayer
{
    /// <summary>
    /// 数据层实例化接口类 dbo.Section.
    /// </summary>
    public partial class SectionDataAccessLayer : ISectionDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public SectionDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_SectionModel">Section实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_SectionInsert(SectionEntity _SectionModel)
		{
			string sqlStr="CreateUpdateDelete_SectionEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ParentID",SqlDbType.Int),
			new SqlParameter("@SectionName",SqlDbType.VarChar),
			new SqlParameter("@SectionCode",SqlDbType.VarChar),
			new SqlParameter("@Sort",SqlDbType.Int),
			new SqlParameter("@Description",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_SectionModel.ID;
			_param[2].Value=_SectionModel.ParentID;
			_param[3].Value=_SectionModel.SectionName;
			_param[4].Value=_SectionModel.SectionCode;
			_param[5].Value=_SectionModel.Sort;
			_param[6].Value=_SectionModel.Description;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_SectionModel">Section实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_SectionInsert(SqlTransaction sp,SectionEntity _SectionModel)
		{
			string sqlStr="CreateUpdateDelete_SectionEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ParentID",SqlDbType.Int),
			new SqlParameter("@SectionName",SqlDbType.VarChar),
			new SqlParameter("@SectionCode",SqlDbType.VarChar),
			new SqlParameter("@Sort",SqlDbType.Int),
			new SqlParameter("@Description",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_SectionModel.ID;
			_param[2].Value=_SectionModel.ParentID;
			_param[3].Value=_SectionModel.SectionName;
			_param[4].Value=_SectionModel.SectionCode;
			_param[5].Value=_SectionModel.Sort;
			_param[6].Value=_SectionModel.Description;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表Section更新一条记录。
		/// </summary>
		/// <param name="_SectionModel">_SectionModel</param>
		/// <returns>影响的行数</returns>
		public int Create_SectionUpdate(SectionEntity _SectionModel)
		{
            string sqlStr="CreateUpdateDelete_SectionEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ParentID",SqlDbType.Int),
				new SqlParameter("@SectionName",SqlDbType.VarChar),
				new SqlParameter("@SectionCode",SqlDbType.VarChar),
				new SqlParameter("@Sort",SqlDbType.Int),
				new SqlParameter("@Description",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_SectionModel.ID;
				_param[2].Value=_SectionModel.ParentID;
				_param[3].Value=_SectionModel.SectionName;
				_param[4].Value=_SectionModel.SectionCode;
				_param[5].Value=_SectionModel.Sort;
				_param[6].Value=_SectionModel.Description;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表Section更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_SectionModel">_SectionModel</param>
		/// <returns>影响的行数</returns>
		public int Create_SectionUpdate(SqlTransaction sp,SectionEntity _SectionModel)
		{
            string sqlStr="CreateUpdateDelete_SectionEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ParentID",SqlDbType.Int),
				new SqlParameter("@SectionName",SqlDbType.VarChar),
				new SqlParameter("@SectionCode",SqlDbType.VarChar),
				new SqlParameter("@Sort",SqlDbType.Int),
				new SqlParameter("@Description",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_SectionModel.ID;
				_param[2].Value=_SectionModel.ParentID;
				_param[3].Value=_SectionModel.SectionName;
				_param[4].Value=_SectionModel.SectionCode;
				_param[5].Value=_SectionModel.Sort;
				_param[6].Value=_SectionModel.Description;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表Section中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_SectionDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_SectionEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表Section中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_SectionDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_SectionEntity";
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
		/// 得到  section 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>section 数据实体</returns>
		public SectionEntity Populate_SectionEntity_FromDr(DataRow row)
		{
			SectionEntity Obj = new SectionEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.ParentID = (( row["ParentID"])==DBNull.Value)?0:Convert.ToInt32( row["ParentID"]);
				Obj.SectionName =  row["SectionName"].ToString();
				Obj.SectionCode =  row["SectionCode"].ToString();
				Obj.Sort = (( row["Sort"])==DBNull.Value)?0:Convert.ToInt32( row["Sort"]);
				Obj.Description =  row["Description"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  section 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>section 数据实体</returns>
		public SectionEntity Populate_SectionEntity_FromDr(IDataReader dr)
		{
			SectionEntity Obj = new SectionEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.ParentID = (( dr["ParentID"])==DBNull.Value)?0:Convert.ToInt32( dr["ParentID"]);
				Obj.SectionName =  dr["SectionName"].ToString();
				Obj.SectionCode =  dr["SectionCode"].ToString();
				Obj.Sort = (( dr["Sort"])==DBNull.Value)?0:Convert.ToInt32( dr["Sort"]);
				Obj.Description =  dr["Description"].ToString();
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个Section对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Section对象</returns>
		public SectionEntity Get_SectionEntity (int iD)
		{
			SectionEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from Section where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_SectionEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表Section所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< SectionEntity> Get_SectionAll()
		{
			IList< SectionEntity> Obj=new List< SectionEntity>();
			string sqlStr="select * from Section";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_SectionEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistSection(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from Section where ID=@iD";
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
