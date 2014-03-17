// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： RoleModulePermission.cs
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
    /// 数据层实例化接口类 dbo.RoleModulePermission.
    /// </summary>
    public partial class RoleModulePermissionDataAccessLayer : IRoleModulePermissionDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public RoleModulePermissionDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_RoleModulePermissionModel">RoleModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_RoleModulePermissionInsert(RoleModulePermissionEntity _RoleModulePermissionModel)
		{
			string sqlStr="CreateUpdateDelete_RoleModulePermissionEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@RoleID",SqlDbType.Int),
			new SqlParameter("@ModulePermissionID",SqlDbType.Int),
			new SqlParameter("@CreateUserID",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime)
			};
			_param[0].Value=0;
			_param[1].Value=_RoleModulePermissionModel.ID;
			_param[2].Value=_RoleModulePermissionModel.RoleID;
			_param[3].Value=_RoleModulePermissionModel.ModulePermissionID;
			_param[4].Value=_RoleModulePermissionModel.CreateUserID;
			_param[5].Value=_RoleModulePermissionModel.CreateDate;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_RoleModulePermissionModel">RoleModulePermission实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_RoleModulePermissionInsert(SqlTransaction sp,RoleModulePermissionEntity _RoleModulePermissionModel)
		{
			string sqlStr="CreateUpdateDelete_RoleModulePermissionEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@RoleID",SqlDbType.Int),
			new SqlParameter("@ModulePermissionID",SqlDbType.Int),
			new SqlParameter("@CreateUserID",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime)
			};
			_param[0].Value=0;
			_param[1].Value=_RoleModulePermissionModel.ID;
			_param[2].Value=_RoleModulePermissionModel.RoleID;
			_param[3].Value=_RoleModulePermissionModel.ModulePermissionID;
			_param[4].Value=_RoleModulePermissionModel.CreateUserID;
			_param[5].Value=_RoleModulePermissionModel.CreateDate;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表RoleModulePermission更新一条记录。
		/// </summary>
		/// <param name="_RoleModulePermissionModel">_RoleModulePermissionModel</param>
		/// <returns>影响的行数</returns>
		public int Create_RoleModulePermissionUpdate(RoleModulePermissionEntity _RoleModulePermissionModel)
		{
            string sqlStr="CreateUpdateDelete_RoleModulePermissionEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@RoleID",SqlDbType.Int),
				new SqlParameter("@ModulePermissionID",SqlDbType.Int),
				new SqlParameter("@CreateUserID",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime)
				};
				_param[0].Value=1;
				_param[1].Value=_RoleModulePermissionModel.ID;
				_param[2].Value=_RoleModulePermissionModel.RoleID;
				_param[3].Value=_RoleModulePermissionModel.ModulePermissionID;
				_param[4].Value=_RoleModulePermissionModel.CreateUserID;
				_param[5].Value=_RoleModulePermissionModel.CreateDate;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表RoleModulePermission更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_RoleModulePermissionModel">_RoleModulePermissionModel</param>
		/// <returns>影响的行数</returns>
		public int Create_RoleModulePermissionUpdate(SqlTransaction sp,RoleModulePermissionEntity _RoleModulePermissionModel)
		{
            string sqlStr="CreateUpdateDelete_RoleModulePermissionEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@RoleID",SqlDbType.Int),
				new SqlParameter("@ModulePermissionID",SqlDbType.Int),
				new SqlParameter("@CreateUserID",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime)
				};
				_param[0].Value=1;
				_param[1].Value=_RoleModulePermissionModel.ID;
				_param[2].Value=_RoleModulePermissionModel.RoleID;
				_param[3].Value=_RoleModulePermissionModel.ModulePermissionID;
				_param[4].Value=_RoleModulePermissionModel.CreateUserID;
				_param[5].Value=_RoleModulePermissionModel.CreateDate;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表RoleModulePermission中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_RoleModulePermissionDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_RoleModulePermissionEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表RoleModulePermission中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_RoleModulePermissionDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_RoleModulePermissionEntity";
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
		/// 得到  rolemodulepermission 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>rolemodulepermission 数据实体</returns>
		public RoleModulePermissionEntity Populate_RoleModulePermissionEntity_FromDr(DataRow row)
		{
			RoleModulePermissionEntity Obj = new RoleModulePermissionEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.RoleID = (( row["RoleID"])==DBNull.Value)?0:Convert.ToInt32( row["RoleID"]);
				Obj.ModulePermissionID = (( row["ModulePermissionID"])==DBNull.Value)?0:Convert.ToInt32( row["ModulePermissionID"]);
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
		/// 得到  rolemodulepermission 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>rolemodulepermission 数据实体</returns>
		public RoleModulePermissionEntity Populate_RoleModulePermissionEntity_FromDr(IDataReader dr)
		{
			RoleModulePermissionEntity Obj = new RoleModulePermissionEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.RoleID = (( dr["RoleID"])==DBNull.Value)?0:Convert.ToInt32( dr["RoleID"]);
				Obj.ModulePermissionID = (( dr["ModulePermissionID"])==DBNull.Value)?0:Convert.ToInt32( dr["ModulePermissionID"]);
				Obj.CreateUserID = (( dr["CreateUserID"])==DBNull.Value)?0:Convert.ToInt32( dr["CreateUserID"]);
				Obj.CreateDate = (( dr["CreateDate"])==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime( dr["CreateDate"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个RoleModulePermission对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoleModulePermission对象</returns>
		public RoleModulePermissionEntity Get_RoleModulePermissionEntity (int iD)
		{
			RoleModulePermissionEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from RoleModulePermission where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_RoleModulePermissionEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表RoleModulePermission所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< RoleModulePermissionEntity> Get_RoleModulePermissionAll()
		{
			IList< RoleModulePermissionEntity> Obj=new List< RoleModulePermissionEntity>();
			string sqlStr="select * from RoleModulePermission";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_RoleModulePermissionEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistRoleModulePermission(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from RoleModulePermission where ID=@iD";
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
