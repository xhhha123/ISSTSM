// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： UserInfo.cs
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
    /// 数据层实例化接口类 dbo.UserInfo.
    /// </summary>
    public partial class UserInfoDataAccessLayer : IUserInfoDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public UserInfoDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_UserInfoModel">UserInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_UserInfoInsert(UserInfoEntity _UserInfoModel)
		{
			string sqlStr="CreateUpdateDelete_UserInfoEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@UserName",SqlDbType.VarChar),
			new SqlParameter("@RealName",SqlDbType.VarChar),
			new SqlParameter("@SectionID",SqlDbType.Int),
			new SqlParameter("@Telephone",SqlDbType.VarChar),
			new SqlParameter("@Pwd",SqlDbType.VarChar),
			new SqlParameter("@QQ",SqlDbType.VarChar),
			new SqlParameter("@Photopath",SqlDbType.VarChar),
			new SqlParameter("@Email",SqlDbType.VarChar),
			new SqlParameter("@DicSex",SqlDbType.Int),
			new SqlParameter("@DicAddress",SqlDbType.Int),
			new SqlParameter("@DicStatus",SqlDbType.Int)
			};
			_param[0].Value=0;
			_param[1].Value=_UserInfoModel.ID;
			_param[2].Value=_UserInfoModel.UserName;
			_param[3].Value=_UserInfoModel.RealName;
			_param[4].Value=_UserInfoModel.SectionID;
			_param[5].Value=_UserInfoModel.Telephone;
			_param[6].Value=_UserInfoModel.Pwd;
			_param[7].Value=_UserInfoModel.QQ;
			_param[8].Value=_UserInfoModel.Photopath;
			_param[9].Value=_UserInfoModel.Email;
			_param[10].Value=_UserInfoModel.DicSex;
			_param[11].Value=_UserInfoModel.DicAddress;
			_param[12].Value=_UserInfoModel.DicStatus;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_UserInfoModel">UserInfo实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_UserInfoInsert(SqlTransaction sp,UserInfoEntity _UserInfoModel)
		{
			string sqlStr="CreateUpdateDelete_UserInfoEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@UserName",SqlDbType.VarChar),
			new SqlParameter("@RealName",SqlDbType.VarChar),
			new SqlParameter("@SectionID",SqlDbType.Int),
			new SqlParameter("@Telephone",SqlDbType.VarChar),
			new SqlParameter("@Pwd",SqlDbType.VarChar),
			new SqlParameter("@QQ",SqlDbType.VarChar),
			new SqlParameter("@Photopath",SqlDbType.VarChar),
			new SqlParameter("@Email",SqlDbType.VarChar),
			new SqlParameter("@DicSex",SqlDbType.Int),
			new SqlParameter("@DicAddress",SqlDbType.Int),
			new SqlParameter("@DicStatus",SqlDbType.Int)
			};
			_param[0].Value=0;
			_param[1].Value=_UserInfoModel.ID;
			_param[2].Value=_UserInfoModel.UserName;
			_param[3].Value=_UserInfoModel.RealName;
			_param[4].Value=_UserInfoModel.SectionID;
			_param[5].Value=_UserInfoModel.Telephone;
			_param[6].Value=_UserInfoModel.Pwd;
			_param[7].Value=_UserInfoModel.QQ;
			_param[8].Value=_UserInfoModel.Photopath;
			_param[9].Value=_UserInfoModel.Email;
			_param[10].Value=_UserInfoModel.DicSex;
			_param[11].Value=_UserInfoModel.DicAddress;
			_param[12].Value=_UserInfoModel.DicStatus;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表UserInfo更新一条记录。
		/// </summary>
		/// <param name="_UserInfoModel">_UserInfoModel</param>
		/// <returns>影响的行数</returns>
		public int Create_UserInfoUpdate(UserInfoEntity _UserInfoModel)
		{
            string sqlStr="CreateUpdateDelete_UserInfoEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserName",SqlDbType.VarChar),
				new SqlParameter("@RealName",SqlDbType.VarChar),
				new SqlParameter("@SectionID",SqlDbType.Int),
				new SqlParameter("@Telephone",SqlDbType.VarChar),
				new SqlParameter("@Pwd",SqlDbType.VarChar),
				new SqlParameter("@QQ",SqlDbType.VarChar),
				new SqlParameter("@Photopath",SqlDbType.VarChar),
				new SqlParameter("@Email",SqlDbType.VarChar),
				new SqlParameter("@DicSex",SqlDbType.Int),
				new SqlParameter("@DicAddress",SqlDbType.Int),
				new SqlParameter("@DicStatus",SqlDbType.Int)
				};
				_param[0].Value=1;
				_param[1].Value=_UserInfoModel.ID;
				_param[2].Value=_UserInfoModel.UserName;
				_param[3].Value=_UserInfoModel.RealName;
				_param[4].Value=_UserInfoModel.SectionID;
				_param[5].Value=_UserInfoModel.Telephone;
				_param[6].Value=_UserInfoModel.Pwd;
				_param[7].Value=_UserInfoModel.QQ;
				_param[8].Value=_UserInfoModel.Photopath;
				_param[9].Value=_UserInfoModel.Email;
				_param[10].Value=_UserInfoModel.DicSex;
				_param[11].Value=_UserInfoModel.DicAddress;
				_param[12].Value=_UserInfoModel.DicStatus;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表UserInfo更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_UserInfoModel">_UserInfoModel</param>
		/// <returns>影响的行数</returns>
		public int Create_UserInfoUpdate(SqlTransaction sp,UserInfoEntity _UserInfoModel)
		{
            string sqlStr="CreateUpdateDelete_UserInfoEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserName",SqlDbType.VarChar),
				new SqlParameter("@RealName",SqlDbType.VarChar),
				new SqlParameter("@SectionID",SqlDbType.Int),
				new SqlParameter("@Telephone",SqlDbType.VarChar),
				new SqlParameter("@Pwd",SqlDbType.VarChar),
				new SqlParameter("@QQ",SqlDbType.VarChar),
				new SqlParameter("@Photopath",SqlDbType.VarChar),
				new SqlParameter("@Email",SqlDbType.VarChar),
				new SqlParameter("@DicSex",SqlDbType.Int),
				new SqlParameter("@DicAddress",SqlDbType.Int),
				new SqlParameter("@DicStatus",SqlDbType.Int)
				};
				_param[0].Value=1;
				_param[1].Value=_UserInfoModel.ID;
				_param[2].Value=_UserInfoModel.UserName;
				_param[3].Value=_UserInfoModel.RealName;
				_param[4].Value=_UserInfoModel.SectionID;
				_param[5].Value=_UserInfoModel.Telephone;
				_param[6].Value=_UserInfoModel.Pwd;
				_param[7].Value=_UserInfoModel.QQ;
				_param[8].Value=_UserInfoModel.Photopath;
				_param[9].Value=_UserInfoModel.Email;
				_param[10].Value=_UserInfoModel.DicSex;
				_param[11].Value=_UserInfoModel.DicAddress;
				_param[12].Value=_UserInfoModel.DicStatus;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表UserInfo中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_UserInfoDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_UserInfoEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表UserInfo中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_UserInfoDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_UserInfoEntity";
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
		/// 得到  userinfo 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>userinfo 数据实体</returns>
		public UserInfoEntity Populate_UserInfoEntity_FromDr(DataRow row)
		{
			UserInfoEntity Obj = new UserInfoEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.UserName =  row["UserName"].ToString();
				Obj.RealName =  row["RealName"].ToString();
				Obj.SectionID = (( row["SectionID"])==DBNull.Value)?0:Convert.ToInt32( row["SectionID"]);
				Obj.Telephone =  row["Telephone"].ToString();
				Obj.Pwd =  row["Pwd"].ToString();
				Obj.QQ =  row["QQ"].ToString();
				Obj.Photopath =  row["Photopath"].ToString();
				Obj.Email =  row["Email"].ToString();
				Obj.DicSex = (( row["DicSex"])==DBNull.Value)?0:Convert.ToInt32( row["DicSex"]);
				Obj.DicAddress = (( row["DicAddress"])==DBNull.Value)?0:Convert.ToInt32( row["DicAddress"]);
				Obj.DicStatus = (( row["DicStatus"])==DBNull.Value)?0:Convert.ToInt32( row["DicStatus"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  userinfo 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>userinfo 数据实体</returns>
		public UserInfoEntity Populate_UserInfoEntity_FromDr(IDataReader dr)
		{
			UserInfoEntity Obj = new UserInfoEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserName =  dr["UserName"].ToString();
				Obj.RealName =  dr["RealName"].ToString();
				Obj.SectionID = (( dr["SectionID"])==DBNull.Value)?0:Convert.ToInt32( dr["SectionID"]);
				Obj.Telephone =  dr["Telephone"].ToString();
				Obj.Pwd =  dr["Pwd"].ToString();
				Obj.QQ =  dr["QQ"].ToString();
				Obj.Photopath =  dr["Photopath"].ToString();
				Obj.Email =  dr["Email"].ToString();
				Obj.DicSex = (( dr["DicSex"])==DBNull.Value)?0:Convert.ToInt32( dr["DicSex"]);
				Obj.DicAddress = (( dr["DicAddress"])==DBNull.Value)?0:Convert.ToInt32( dr["DicAddress"]);
				Obj.DicStatus = (( dr["DicStatus"])==DBNull.Value)?0:Convert.ToInt32( dr["DicStatus"]);
			
			return Obj;
		}

        /// <summary>
        /// 得到  userinfo UI数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>userinfo UI数据实体</returns>
        public UserInfoUIEntity Populate_UserInfoUIEntity_FromDr(IDataReader dr)
        {
            UserInfoUIEntity Obj = new UserInfoUIEntity();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.UserName = dr["UserName"].ToString();
            Obj.RealName = dr["RealName"].ToString();
            Obj.SectionID = ((dr["SectionID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["SectionID"]);
            Obj.Telephone = dr["Telephone"].ToString();
            Obj.Pwd = dr["Pwd"].ToString();
            Obj.QQ = dr["QQ"].ToString();
            Obj.Photopath = dr["Photopath"].ToString();
            Obj.Email = dr["Email"].ToString();
            Obj.DicSex = ((dr["DicSex"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["DicSex"]);
            Obj.DicAddress = ((dr["DicAddress"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["DicAddress"]);
            Obj.DicStatus = ((dr["DicStatus"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["DicStatus"]);
            Obj.SectionName = dr["SectionName"].ToString();
            return Obj;
        }
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个UserInfo对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>UserInfo对象</returns>
		public UserInfoEntity Get_UserInfoEntity (int iD)
		{
			UserInfoEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from UserInfo where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_UserInfoEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表UserInfo所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< UserInfoEntity> Get_UserInfoAll()
		{
			IList< UserInfoEntity> Obj=new List< UserInfoEntity>();
			string sqlStr="select * from UserInfo";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_UserInfoEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistUserInfo(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from UserInfo where ID=@iD";
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
