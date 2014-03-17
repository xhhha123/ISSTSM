// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： Module.cs
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
    /// 数据层实例化接口类 dbo.Module.
    /// </summary>
    public partial class ModuleDataAccessLayer : IModuleDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public ModuleDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_ModuleModel">Module实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_ModuleInsert(ModuleEntity _ModuleModel)
		{
			string sqlStr="CreateUpdateDelete_ModuleEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ModuleName",SqlDbType.VarChar),
			new SqlParameter("@ModuleUrl",SqlDbType.VarChar),
			new SqlParameter("@Icon",SqlDbType.VarChar),
			new SqlParameter("@ParentID",SqlDbType.VarChar),
			new SqlParameter("@Sort",SqlDbType.Int),
			new SqlParameter("@IsVisible",SqlDbType.Bit),
			new SqlParameter("@IsMenu",SqlDbType.Bit),
			new SqlParameter("@IsDeleted",SqlDbType.Bit)
			};
			_param[0].Value=0;
			_param[1].Value=_ModuleModel.ID;
			_param[2].Value=_ModuleModel.ModuleName;
			_param[3].Value=_ModuleModel.ModuleUrl;
			_param[4].Value=_ModuleModel.Icon;
			_param[5].Value=_ModuleModel.ParentID;
			_param[6].Value=_ModuleModel.Sort;
			_param[7].Value=_ModuleModel.IsVisible;
			_param[8].Value=_ModuleModel.IsMenu;
			_param[9].Value=_ModuleModel.IsDeleted;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ModuleModel">Module实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_ModuleInsert(SqlTransaction sp,ModuleEntity _ModuleModel)
		{
			string sqlStr="CreateUpdateDelete_ModuleEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@ModuleName",SqlDbType.VarChar),
			new SqlParameter("@ModuleUrl",SqlDbType.VarChar),
			new SqlParameter("@Icon",SqlDbType.VarChar),
			new SqlParameter("@ParentID",SqlDbType.VarChar),
			new SqlParameter("@Sort",SqlDbType.Int),
			new SqlParameter("@IsVisible",SqlDbType.Bit),
			new SqlParameter("@IsMenu",SqlDbType.Bit),
			new SqlParameter("@IsDeleted",SqlDbType.Bit)
			};
			_param[0].Value=0;
			_param[1].Value=_ModuleModel.ID;
			_param[2].Value=_ModuleModel.ModuleName;
			_param[3].Value=_ModuleModel.ModuleUrl;
			_param[4].Value=_ModuleModel.Icon;
			_param[5].Value=_ModuleModel.ParentID;
			_param[6].Value=_ModuleModel.Sort;
			_param[7].Value=_ModuleModel.IsVisible;
			_param[8].Value=_ModuleModel.IsMenu;
			_param[9].Value=_ModuleModel.IsDeleted;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表Module更新一条记录。
		/// </summary>
		/// <param name="_ModuleModel">_ModuleModel</param>
		/// <returns>影响的行数</returns>
		public int Create_ModuleUpdate(ModuleEntity _ModuleModel)
		{
            string sqlStr="CreateUpdateDelete_ModuleEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ModuleName",SqlDbType.VarChar),
				new SqlParameter("@ModuleUrl",SqlDbType.VarChar),
				new SqlParameter("@Icon",SqlDbType.VarChar),
				new SqlParameter("@ParentID",SqlDbType.VarChar),
				new SqlParameter("@Sort",SqlDbType.Int),
				new SqlParameter("@IsVisible",SqlDbType.Bit),
				new SqlParameter("@IsMenu",SqlDbType.Bit),
				new SqlParameter("@IsDeleted",SqlDbType.Bit)
				};
				_param[0].Value=1;
				_param[1].Value=_ModuleModel.ID;
				_param[2].Value=_ModuleModel.ModuleName;
				_param[3].Value=_ModuleModel.ModuleUrl;
				_param[4].Value=_ModuleModel.Icon;
				_param[5].Value=_ModuleModel.ParentID;
				_param[6].Value=_ModuleModel.Sort;
				_param[7].Value=_ModuleModel.IsVisible;
				_param[8].Value=_ModuleModel.IsMenu;
				_param[9].Value=_ModuleModel.IsDeleted;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表Module更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_ModuleModel">_ModuleModel</param>
		/// <returns>影响的行数</returns>
		public int Create_ModuleUpdate(SqlTransaction sp,ModuleEntity _ModuleModel)
		{
            string sqlStr="CreateUpdateDelete_ModuleEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ModuleName",SqlDbType.VarChar),
				new SqlParameter("@ModuleUrl",SqlDbType.VarChar),
				new SqlParameter("@Icon",SqlDbType.VarChar),
				new SqlParameter("@ParentID",SqlDbType.VarChar),
				new SqlParameter("@Sort",SqlDbType.Int),
				new SqlParameter("@IsVisible",SqlDbType.Bit),
				new SqlParameter("@IsMenu",SqlDbType.Bit),
				new SqlParameter("@IsDeleted",SqlDbType.Bit)
				};
				_param[0].Value=1;
				_param[1].Value=_ModuleModel.ID;
				_param[2].Value=_ModuleModel.ModuleName;
				_param[3].Value=_ModuleModel.ModuleUrl;
				_param[4].Value=_ModuleModel.Icon;
				_param[5].Value=_ModuleModel.ParentID;
				_param[6].Value=_ModuleModel.Sort;
				_param[7].Value=_ModuleModel.IsVisible;
				_param[8].Value=_ModuleModel.IsMenu;
				_param[9].Value=_ModuleModel.IsDeleted;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表Module中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_ModuleDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_ModuleEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表Module中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_ModuleDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_ModuleEntity";
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
		/// 得到  module 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>module 数据实体</returns>
		public ModuleEntity Populate_ModuleEntity_FromDr(DataRow row)
		{
			ModuleEntity Obj = new ModuleEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.ModuleName =  row["ModuleName"].ToString();
				Obj.ModuleUrl =  row["ModuleUrl"].ToString();
				Obj.Icon =  row["Icon"].ToString();
				Obj.ParentID =  row["ParentID"].ToString();
				Obj.Sort = (( row["Sort"])==DBNull.Value)?0:Convert.ToInt32( row["Sort"]);
				Obj.IsVisible = (bool) row["IsVisible"];
				Obj.IsMenu = (bool) row["IsMenu"];
				Obj.IsDeleted = (bool) row["IsDeleted"];
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  module 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>module 数据实体</returns>
		public ModuleEntity Populate_ModuleEntity_FromDr(IDataReader dr)
		{
			ModuleEntity Obj = new ModuleEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.ModuleName =  dr["ModuleName"].ToString();
				Obj.ModuleUrl =  dr["ModuleUrl"].ToString();
				Obj.Icon =  dr["Icon"].ToString();
				Obj.ParentID =  dr["ParentID"].ToString();
				Obj.Sort = (( dr["Sort"])==DBNull.Value)?0:Convert.ToInt32( dr["Sort"]);
                Obj.IsVisible = (bool)dr["IsVisible"];
                Obj.IsMenu = (bool)dr["IsMenu"];
				Obj.IsDeleted = (bool) dr["IsDeleted"];
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个Module对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Module对象</returns>
		public ModuleEntity Get_ModuleEntity (int iD)
		{
			ModuleEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from Module where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_ModuleEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表Module所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< ModuleEntity> Get_ModuleAll()
		{
			IList< ModuleEntity> Obj=new List< ModuleEntity>();
			string sqlStr="select * from Module";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_ModuleEntity_FromDr(dr));
				}
			}
			return Obj;
		}


        
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistModule(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from Module where ID=@iD";
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
