// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： ModulePermission.cs
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
    /// 数据层实例化接口类 dbo.ModulePermission.
    /// </summary>
    public partial class ModulePermissionDataAccessLayer : IModulePermissionDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public ModulePermissionDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_ModulePermissionModel">ModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_ModulePermissionInsert(ModulePermissionEntity _ModulePermissionModel)
		{
			string sqlStr="CreateUpdateDelete_ModulePermissionEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ModuleID",SqlDbType.Int),
			new SqlParameter("@PermissionID",SqlDbType.Int),
			new SqlParameter("@CreateUserID",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime),
			new SqlParameter("@IsDeleted",SqlDbType.Bit)
			};
			_param[0].Value=0;
			_param[1].Value=_ModulePermissionModel.ID;
			_param[2].Value=_ModulePermissionModel.ModuleID;
			_param[3].Value=_ModulePermissionModel.PermissionID;
			_param[4].Value=_ModulePermissionModel.CreateUserID;
			_param[5].Value=_ModulePermissionModel.CreateDate;
			_param[6].Value=_ModulePermissionModel.IsDeleted;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ModulePermissionModel">ModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_ModulePermissionInsert(SqlTransaction sp,ModulePermissionEntity _ModulePermissionModel)
		{
			string sqlStr="CreateUpdateDelete_ModulePermissionEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ModuleID",SqlDbType.Int),
			new SqlParameter("@PermissionID",SqlDbType.Int),
			new SqlParameter("@CreateUserID",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime),
			new SqlParameter("@IsDeleted",SqlDbType.Bit)
			};
			_param[0].Value=0;
			_param[1].Value=_ModulePermissionModel.ID;
			_param[2].Value=_ModulePermissionModel.ModuleID;
			_param[3].Value=_ModulePermissionModel.PermissionID;
			_param[4].Value=_ModulePermissionModel.CreateUserID;
			_param[5].Value=_ModulePermissionModel.CreateDate;
			_param[6].Value=_ModulePermissionModel.IsDeleted;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表ModulePermission更新一条记录。
		/// </summary>
		/// <param name="_ModulePermissionModel">_ModulePermissionModel</param>
		/// <returns>影响的行数</returns>
		public int Create_ModulePermissionUpdate(ModulePermissionEntity _ModulePermissionModel)
		{
            string sqlStr="CreateUpdateDelete_ModulePermissionEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ModuleID",SqlDbType.Int),
				new SqlParameter("@PermissionID",SqlDbType.Int),
				new SqlParameter("@CreateUserID",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime),
				new SqlParameter("@IsDeleted",SqlDbType.Bit)
				};
				_param[0].Value=1;
				_param[1].Value=_ModulePermissionModel.ID;
				_param[2].Value=_ModulePermissionModel.ModuleID;
				_param[3].Value=_ModulePermissionModel.PermissionID;
				_param[4].Value=_ModulePermissionModel.CreateUserID;
				_param[5].Value=_ModulePermissionModel.CreateDate;
				_param[6].Value=_ModulePermissionModel.IsDeleted;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表ModulePermission更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ModulePermissionModel">_ModulePermissionModel</param>
		/// <returns>影响的行数</returns>
		public int Create_ModulePermissionUpdate(SqlTransaction sp,ModulePermissionEntity _ModulePermissionModel)
		{
            string sqlStr="CreateUpdateDelete_ModulePermissionEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ModuleID",SqlDbType.Int),
				new SqlParameter("@PermissionID",SqlDbType.Int),
				new SqlParameter("@CreateUserID",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime),
				new SqlParameter("@IsDeleted",SqlDbType.Bit)
				};
				_param[0].Value=1;
				_param[1].Value=_ModulePermissionModel.ID;
				_param[2].Value=_ModulePermissionModel.ModuleID;
				_param[3].Value=_ModulePermissionModel.PermissionID;
				_param[4].Value=_ModulePermissionModel.CreateUserID;
				_param[5].Value=_ModulePermissionModel.CreateDate;
				_param[6].Value=_ModulePermissionModel.IsDeleted;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表ModulePermission中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_ModulePermissionDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_ModulePermissionEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表ModulePermission中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_ModulePermissionDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_ModulePermissionEntity";
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
		/// 得到  modulepermission 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>modulepermission 数据实体</returns>
		public ModulePermissionEntity Populate_ModulePermissionEntity_FromDr(DataRow row)
		{
			ModulePermissionEntity Obj = new ModulePermissionEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.ModuleID = (( row["ModuleID"])==DBNull.Value)?0:Convert.ToInt32( row["ModuleID"]);
				Obj.PermissionID = (( row["PermissionID"])==DBNull.Value)?0:Convert.ToInt32( row["PermissionID"]);
				Obj.CreateUserID = (( row["CreateUserID"])==DBNull.Value)?0:Convert.ToInt32( row["CreateUserID"]);
				Obj.CreateDate = (( row["CreateDate"])==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime( row["CreateDate"]);
				Obj.IsDeleted = (bool) row["IsDeleted"];
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  modulepermission 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>modulepermission 数据实体</returns>
		public ModulePermissionEntity Populate_ModulePermissionEntity_FromDr(IDataReader dr)
		{
			ModulePermissionEntity Obj = new ModulePermissionEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.ModuleID = (( dr["ModuleID"])==DBNull.Value)?0:Convert.ToInt32( dr["ModuleID"]);
				Obj.PermissionID = (( dr["PermissionID"])==DBNull.Value)?0:Convert.ToInt32( dr["PermissionID"]);
				Obj.CreateUserID = (( dr["CreateUserID"])==DBNull.Value)?0:Convert.ToInt32( dr["CreateUserID"]);
				Obj.CreateDate = (( dr["CreateDate"])==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime( dr["CreateDate"]);
				Obj.IsDeleted = (bool) dr["IsDeleted"];
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个ModulePermission对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ModulePermission对象</returns>
		public ModulePermissionEntity Get_ModulePermissionEntity (int iD)
		{
			ModulePermissionEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from ModulePermission where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_ModulePermissionEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表ModulePermission所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< ModulePermissionEntity> Get_ModulePermissionAll()
		{
			IList< ModulePermissionEntity> Obj=new List< ModulePermissionEntity>();
			string sqlStr="select * from ModulePermission";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_ModulePermissionEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistModulePermission(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from ModulePermission where ID=@iD";
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
