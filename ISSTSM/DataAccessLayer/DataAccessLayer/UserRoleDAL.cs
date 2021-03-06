﻿// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： UserRole.cs
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
    /// 数据层实例化接口类 dbo.UserRole.
    /// </summary>
    public partial class UserRoleDataAccessLayer : IUserRoleDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public UserRoleDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_UserRoleModel">UserRole实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_UserRoleInsert(UserRoleEntity _UserRoleModel)
		{
			string sqlStr="CreateUpdateDelete_UserRoleEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@UserID",SqlDbType.Int),
			new SqlParameter("@RoleID",SqlDbType.Int),
			new SqlParameter("@CreateUserID",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime)
			};
			_param[0].Value=0;
			_param[1].Value=_UserRoleModel.ID;
			_param[2].Value=_UserRoleModel.UserID;
			_param[3].Value=_UserRoleModel.RoleID;
			_param[4].Value=_UserRoleModel.CreateUserID;
			_param[5].Value=_UserRoleModel.CreateDate;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_UserRoleModel">UserRole实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_UserRoleInsert(SqlTransaction sp,UserRoleEntity _UserRoleModel)
		{
			string sqlStr="CreateUpdateDelete_UserRoleEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@UserID",SqlDbType.Int),
			new SqlParameter("@RoleID",SqlDbType.Int),
			new SqlParameter("@CreateUserID",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime)
			};
			_param[0].Value=0;
			_param[1].Value=_UserRoleModel.ID;
			_param[2].Value=_UserRoleModel.UserID;
			_param[3].Value=_UserRoleModel.RoleID;
			_param[4].Value=_UserRoleModel.CreateUserID;
			_param[5].Value=_UserRoleModel.CreateDate;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表UserRole更新一条记录。
		/// </summary>
		/// <param name="_UserRoleModel">_UserRoleModel</param>
		/// <returns>影响的行数</returns>
		public int Create_UserRoleUpdate(UserRoleEntity _UserRoleModel)
		{
            string sqlStr="CreateUpdateDelete_UserRoleEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.Int),
				new SqlParameter("@RoleID",SqlDbType.Int),
				new SqlParameter("@CreateUserID",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime)
				};
				_param[0].Value=1;
				_param[1].Value=_UserRoleModel.ID;
				_param[2].Value=_UserRoleModel.UserID;
				_param[3].Value=_UserRoleModel.RoleID;
				_param[4].Value=_UserRoleModel.CreateUserID;
				_param[5].Value=_UserRoleModel.CreateDate;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表UserRole更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_UserRoleModel">_UserRoleModel</param>
		/// <returns>影响的行数</returns>
		public int Create_UserRoleUpdate(SqlTransaction sp,UserRoleEntity _UserRoleModel)
		{
            string sqlStr="CreateUpdateDelete_UserRoleEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.Int),
				new SqlParameter("@RoleID",SqlDbType.Int),
				new SqlParameter("@CreateUserID",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime)
				};
				_param[0].Value=1;
				_param[1].Value=_UserRoleModel.ID;
				_param[2].Value=_UserRoleModel.UserID;
				_param[3].Value=_UserRoleModel.RoleID;
				_param[4].Value=_UserRoleModel.CreateUserID;
				_param[5].Value=_UserRoleModel.CreateDate;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表UserRole中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_UserRoleDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_UserRoleEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表UserRole中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_UserRoleDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_UserRoleEntity";
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
		/// 得到  userrole 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>userrole 数据实体</returns>
		public UserRoleEntity Populate_UserRoleEntity_FromDr(DataRow row)
		{
			UserRoleEntity Obj = new UserRoleEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.UserID = (( row["UserID"])==DBNull.Value)?0:Convert.ToInt32( row["UserID"]);
				Obj.RoleID = (( row["RoleID"])==DBNull.Value)?0:Convert.ToInt32( row["RoleID"]);
				Obj.CreateUserID = (( row["CreateUserID"])==DBNull.Value)?0:Convert.ToInt32( row["CreateUserID"]);
				Obj.CreateDate = (( row["CreateDate"])==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime( row["CreateDate"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  userrole 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>userrole 数据实体</returns>
		public UserRoleEntity Populate_UserRoleEntity_FromDr(IDataReader dr)
		{
			UserRoleEntity Obj = new UserRoleEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.RoleID = (( dr["RoleID"])==DBNull.Value)?0:Convert.ToInt32( dr["RoleID"]);
				Obj.CreateUserID = (( dr["CreateUserID"])==DBNull.Value)?0:Convert.ToInt32( dr["CreateUserID"]);
				Obj.CreateDate = (( dr["CreateDate"])==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime( dr["CreateDate"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个UserRole对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>UserRole对象</returns>
		public UserRoleEntity Get_UserRoleEntity (int iD)
		{
			UserRoleEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from UserRole where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_UserRoleEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表UserRole所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< UserRoleEntity> Get_UserRoleAll()
		{
			IList< UserRoleEntity> Obj=new List< UserRoleEntity>();
			string sqlStr="select * from UserRole";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_UserRoleEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistUserRole(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from UserRole where ID=@iD";
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
