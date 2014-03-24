// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： Role.cs
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
    /// 数据层实例化接口类 dbo.Role.
    /// </summary>
    public partial class RoleDataAccessLayer : IRoleDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public RoleDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_RoleModel">Role实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_RoleInsert(RoleEntity _RoleModel)
		{
			string sqlStr="CreateUpdateDelete_RoleEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@RoleName",SqlDbType.VarChar),
			new SqlParameter("@CreateUserID",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime),
			new SqlParameter("@Sort",SqlDbType.Int),
			new SqlParameter("@IsDeleted",SqlDbType.Bit),
			new SqlParameter("@Description",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_RoleModel.ID;
			_param[2].Value=_RoleModel.RoleName;
			_param[3].Value=_RoleModel.CreateUserID;
			_param[4].Value=_RoleModel.CreateDate;
			_param[5].Value=_RoleModel.Sort;
			_param[6].Value=_RoleModel.IsDeleted;
			_param[7].Value=_RoleModel.Description;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_RoleModel">Role实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_RoleInsert(SqlTransaction sp,RoleEntity _RoleModel)
		{
			string sqlStr="CreateUpdateDelete_RoleEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@RoleName",SqlDbType.VarChar),
			new SqlParameter("@CreateUserID",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime),
			new SqlParameter("@Sort",SqlDbType.Int),
			new SqlParameter("@IsDeleted",SqlDbType.Bit),
			new SqlParameter("@Description",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_RoleModel.ID;
			_param[2].Value=_RoleModel.RoleName;
			_param[3].Value=_RoleModel.CreateUserID;
			_param[4].Value=_RoleModel.CreateDate;
			_param[5].Value=_RoleModel.Sort;
			_param[6].Value=_RoleModel.IsDeleted;
			_param[7].Value=_RoleModel.Description;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表Role更新一条记录。
		/// </summary>
		/// <param name="_RoleModel">_RoleModel</param>
		/// <returns>影响的行数</returns>
		public int Create_RoleUpdate(RoleEntity _RoleModel)
		{
            string sqlStr="CreateUpdateDelete_RoleEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@RoleName",SqlDbType.VarChar),
				new SqlParameter("@CreateUserID",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime),
				new SqlParameter("@Sort",SqlDbType.Int),
				new SqlParameter("@IsDeleted",SqlDbType.Bit),
				new SqlParameter("@Description",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_RoleModel.ID;
				_param[2].Value=_RoleModel.RoleName;
				_param[3].Value=_RoleModel.CreateUserID;
				_param[4].Value=_RoleModel.CreateDate;
				_param[5].Value=_RoleModel.Sort;
				_param[6].Value=_RoleModel.IsDeleted;
				_param[7].Value=_RoleModel.Description;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表Role更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_RoleModel">_RoleModel</param>
		/// <returns>影响的行数</returns>
		public int Create_RoleUpdate(SqlTransaction sp,RoleEntity _RoleModel)
		{
            string sqlStr="CreateUpdateDelete_RoleEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@RoleName",SqlDbType.VarChar),
				new SqlParameter("@CreateUserID",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime),
				new SqlParameter("@Sort",SqlDbType.Int),
				new SqlParameter("@IsDeleted",SqlDbType.Bit),
				new SqlParameter("@Description",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_RoleModel.ID;
				_param[2].Value=_RoleModel.RoleName;
				_param[3].Value=_RoleModel.CreateUserID;
				_param[4].Value=_RoleModel.CreateDate;
				_param[5].Value=_RoleModel.Sort;
				_param[6].Value=_RoleModel.IsDeleted;
				_param[7].Value=_RoleModel.Description;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表Role中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_RoleDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_RoleEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表Role中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_RoleDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_RoleEntity";
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
		/// 得到  role 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>role 数据实体</returns>
		public RoleEntity Populate_RoleEntity_FromDr(DataRow row)
		{
			RoleEntity Obj = new RoleEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.RoleName =  row["RoleName"].ToString();
				Obj.CreateUserID = (( row["CreateUserID"])==DBNull.Value)?0:Convert.ToInt32( row["CreateUserID"]);
				Obj.CreateDate = (( row["CreateDate"])==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime( row["CreateDate"]);
				Obj.Sort = (( row["Sort"])==DBNull.Value)?0:Convert.ToInt32( row["Sort"]);
				Obj.IsDeleted = (bool) row["IsDeleted"];
				Obj.Description =  row["Description"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  role 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>role 数据实体</returns>
		public RoleEntity Populate_RoleEntity_FromDr(IDataReader dr)
		{
			RoleEntity Obj = new RoleEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.RoleName =  dr["RoleName"].ToString();
				Obj.CreateUserID = (( dr["CreateUserID"])==DBNull.Value)?0:Convert.ToInt32( dr["CreateUserID"]);
				Obj.CreateDate = (( dr["CreateDate"])==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime( dr["CreateDate"]);
				Obj.Sort = (( dr["Sort"])==DBNull.Value)?0:Convert.ToInt32( dr["Sort"]);
				Obj.IsDeleted = (bool) dr["IsDeleted"];
				Obj.Description =  dr["Description"].ToString();
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个Role对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Role对象</returns>
		public RoleEntity Get_RoleEntity (int iD)
		{
			RoleEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from Role where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_RoleEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表Role所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< RoleEntity> Get_RoleAll()
		{
			IList< RoleEntity> Obj=new List< RoleEntity>();
            string sqlStr = "select * from Role where IsDeleted=0";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_RoleEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistRole(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from Role where ID=@iD";
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
