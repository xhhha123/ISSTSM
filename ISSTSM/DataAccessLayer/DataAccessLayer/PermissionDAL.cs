// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： Permission.cs
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
    /// 数据层实例化接口类 dbo.Permission.
    /// </summary>
    public partial class PermissionDataAccessLayer : IPermissionDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public PermissionDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_PermissionModel">Permission实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_PermissionInsert(PermissionEntity _PermissionModel)
		{
			string sqlStr="CreateUpdateDelete_PermissionEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@PermissionName",SqlDbType.VarChar),
			new SqlParameter("@Sort",SqlDbType.Int),
			new SqlParameter("@Icon",SqlDbType.VarChar),
			new SqlParameter("@IsVisible",SqlDbType.Bit),
			new SqlParameter("@Description",SqlDbType.VarChar),
            new SqlParameter("@IsButton",SqlDbType.Bit),
			new SqlParameter("@PermissionCode",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_PermissionModel.ID;
			_param[2].Value=_PermissionModel.PermissionName;
			_param[3].Value=_PermissionModel.Sort;
			_param[4].Value=_PermissionModel.Icon;
			_param[5].Value=_PermissionModel.IsVisible;
			_param[6].Value=_PermissionModel.Description;
            _param[7].Value = _PermissionModel.IsButton;
            _param[8].Value = _PermissionModel.PermissionCode;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_PermissionModel">Permission实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_PermissionInsert(SqlTransaction sp,PermissionEntity _PermissionModel)
		{
			string sqlStr="CreateUpdateDelete_PermissionEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@PermissionName",SqlDbType.VarChar),
			new SqlParameter("@Sort",SqlDbType.Int),
			new SqlParameter("@Icon",SqlDbType.VarChar),
			new SqlParameter("@IsVisible",SqlDbType.Bit),
			new SqlParameter("@Description",SqlDbType.VarChar),
            new SqlParameter("@IsButton",SqlDbType.Bit),
			new SqlParameter("@PermissionCode",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_PermissionModel.ID;
            _param[2].Value = _PermissionModel.PermissionName;
			_param[3].Value=_PermissionModel.Sort;
			_param[4].Value=_PermissionModel.Icon;
			_param[5].Value=_PermissionModel.IsVisible;
			_param[6].Value=_PermissionModel.Description;
            _param[7].Value = _PermissionModel.IsButton;
            _param[8].Value = _PermissionModel.PermissionCode;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表Permission更新一条记录。
		/// </summary>
		/// <param name="_PermissionModel">_PermissionModel</param>
		/// <returns>影响的行数</returns>
		public int Create_PermissionUpdate(PermissionEntity _PermissionModel)
		{
            string sqlStr="CreateUpdateDelete_PermissionEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@PermissionName",SqlDbType.VarChar),
				new SqlParameter("@Sort",SqlDbType.Int),
				new SqlParameter("@Icon",SqlDbType.VarChar),
				new SqlParameter("@IsVisible",SqlDbType.Bit),
				new SqlParameter("@Description",SqlDbType.VarChar),
                new SqlParameter("@IsButton",SqlDbType.Bit),
			    new SqlParameter("@PermissionCode",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_PermissionModel.ID;
                _param[2].Value = _PermissionModel.PermissionName;
				_param[3].Value=_PermissionModel.Sort;
				_param[4].Value=_PermissionModel.Icon;
				_param[5].Value=_PermissionModel.IsVisible;
				_param[6].Value=_PermissionModel.Description;
                _param[7].Value = _PermissionModel.IsButton;
                _param[8].Value = _PermissionModel.PermissionCode;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表Permission更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_PermissionModel">_PermissionModel</param>
		/// <returns>影响的行数</returns>
		public int Create_PermissionUpdate(SqlTransaction sp,PermissionEntity _PermissionModel)
		{
            string sqlStr="CreateUpdateDelete_PermissionEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@PermissionName",SqlDbType.VarChar),
				new SqlParameter("@Sort",SqlDbType.Int),
				new SqlParameter("@Icon",SqlDbType.VarChar),
				new SqlParameter("@IsVisible",SqlDbType.Bit),
				new SqlParameter("@Description",SqlDbType.VarChar),
                new SqlParameter("@IsButton",SqlDbType.Bit),
			    new SqlParameter("@PermissionCode",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_PermissionModel.ID;
				_param[2].Value=_PermissionModel.PermissionName;
				_param[3].Value=_PermissionModel.Sort;
				_param[4].Value=_PermissionModel.Icon;
				_param[5].Value=_PermissionModel.IsVisible;
				_param[6].Value=_PermissionModel.Description;
                _param[7].Value = _PermissionModel.IsButton;
                _param[8].Value = _PermissionModel.PermissionCode;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表Permission中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_PermissionDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_PermissionEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表Permission中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_PermissionDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_PermissionEntity";
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
		/// 得到  permission 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>permission 数据实体</returns>
		public PermissionEntity Populate_PermissionEntity_FromDr(DataRow row)
		{
			PermissionEntity Obj = new PermissionEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.PermissionName =  row["PermissionName"].ToString();
				Obj.Sort = (( row["Sort"])==DBNull.Value)?0:Convert.ToInt32( row["Sort"]);
				Obj.Icon =  row["Icon"].ToString();
				Obj.IsVisible = (bool) row["IsVisible"];
				Obj.Description =  row["Description"].ToString();
                Obj.IsButton = (bool)row["IsButton"];
                Obj.PermissionCode = row["PermissionCode"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  permission 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>permission 数据实体</returns>
		public PermissionEntity Populate_PermissionEntity_FromDr(IDataReader dr)
		{
			PermissionEntity Obj = new PermissionEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.PermissionName =  dr["PermissionName"].ToString();
				Obj.Sort = (( dr["Sort"])==DBNull.Value)?0:Convert.ToInt32( dr["Sort"]);
				Obj.Icon =  dr["Icon"].ToString();
				Obj.IsVisible = (bool) dr["IsVisible"];
				Obj.Description =  dr["Description"].ToString();
                Obj.IsButton = (bool)dr["IsButton"];
                Obj.PermissionCode = dr["PermissionCode"].ToString();

			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个Permission对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Permission对象</returns>
		public PermissionEntity Get_PermissionEntity (int iD)
		{
			PermissionEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from Permission where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_PermissionEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表Permission所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< PermissionEntity> Get_PermissionAll()
		{
			IList< PermissionEntity> Obj=new List< PermissionEntity>();
			string sqlStr="select * from Permission";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_PermissionEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistPermission(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from Permission where ID=@iD";
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
