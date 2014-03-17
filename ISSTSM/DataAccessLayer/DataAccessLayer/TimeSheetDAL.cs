// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： TimeSheet.cs
// 项目名称：SunCity_MS
// 创建时间：2014/1/9
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
    /// 数据层实例化接口类 dbo.TimeSheet.
    /// </summary>
    public partial class TimeSheetDataAccessLayer : ITimeSheetDataAccessLayer
    {
		#region 构造函数
		/// <summary>
		/// ??????
		/// </summary>
		public TimeSheetDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_TimeSheetModel">TimeSheet实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_TimeSheetInsert(TimeSheetEntity _TimeSheetModel)
		{
			string sqlStr="CreateUpdateDelete_TimeSheetEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@IncidentID",SqlDbType.Int),
			new SqlParameter("@Date",SqlDbType.DateTime),
			new SqlParameter("@BillableHour",SqlDbType.Float),
			new SqlParameter("@UserID",SqlDbType.Int),
			new SqlParameter("@DicTitle",SqlDbType.Int),
			new SqlParameter("@DicProject",SqlDbType.Int),
			new SqlParameter("@DicGroup",SqlDbType.Int),
			new SqlParameter("@DicType",SqlDbType.Int),
			new SqlParameter("@SubProject",SqlDbType.VarChar),
			new SqlParameter("@Tasks",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_TimeSheetModel.ID;
			_param[2].Value=_TimeSheetModel.IncidentID;
			_param[3].Value=_TimeSheetModel.Date;
			_param[4].Value=_TimeSheetModel.BillableHour;
			_param[5].Value=_TimeSheetModel.UserID;
			_param[6].Value=_TimeSheetModel.DicTitle;
			_param[7].Value=_TimeSheetModel.DicProject;
			_param[8].Value=_TimeSheetModel.DicGroup;
			_param[9].Value=_TimeSheetModel.DicType;
			_param[10].Value=_TimeSheetModel.SubProject;
			_param[11].Value=_TimeSheetModel.Tasks;
			res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_TimeSheetModel">TimeSheet实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Create_TimeSheetInsert(SqlTransaction sp,TimeSheetEntity _TimeSheetModel)
		{
			string sqlStr="CreateUpdateDelete_TimeSheetEntity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@IncidentID",SqlDbType.Int),
			new SqlParameter("@Date",SqlDbType.DateTime),
			new SqlParameter("@BillableHour",SqlDbType.Float),
			new SqlParameter("@UserID",SqlDbType.Int),
			new SqlParameter("@DicTitle",SqlDbType.Int),
			new SqlParameter("@DicProject",SqlDbType.Int),
			new SqlParameter("@DicGroup",SqlDbType.Int),
			new SqlParameter("@DicType",SqlDbType.Int),
			new SqlParameter("@SubProject",SqlDbType.VarChar),
			new SqlParameter("@Tasks",SqlDbType.VarChar)
			};
			_param[0].Value=0;
			_param[1].Value=_TimeSheetModel.ID;
			_param[2].Value=_TimeSheetModel.IncidentID;
			_param[3].Value=_TimeSheetModel.Date;
			_param[4].Value=_TimeSheetModel.BillableHour;
			_param[5].Value=_TimeSheetModel.UserID;
			_param[6].Value=_TimeSheetModel.DicTitle;
			_param[7].Value=_TimeSheetModel.DicProject;
			_param[8].Value=_TimeSheetModel.DicGroup;
			_param[9].Value=_TimeSheetModel.DicType;
			_param[10].Value=_TimeSheetModel.SubProject;
			_param[11].Value=_TimeSheetModel.Tasks;
			res = (int)SqlHelper.ExecuteScalar(sp,CommandType.StoredProcedure,sqlStr,_param);
			return res;
		}


		/// <summary>
		/// 向数据表TimeSheet更新一条记录。
		/// </summary>
		/// <param name="_TimeSheetModel">_TimeSheetModel</param>
		/// <returns>影响的行数</returns>
		public int Create_TimeSheetUpdate(TimeSheetEntity _TimeSheetModel)
		{
            string sqlStr="CreateUpdateDelete_TimeSheetEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@IncidentID",SqlDbType.Int),
				new SqlParameter("@Date",SqlDbType.DateTime),
				new SqlParameter("@BillableHour",SqlDbType.Float),
				new SqlParameter("@UserID",SqlDbType.Int),
				new SqlParameter("@DicTitle",SqlDbType.Int),
				new SqlParameter("@DicProject",SqlDbType.Int),
				new SqlParameter("@DicGroup",SqlDbType.Int),
				new SqlParameter("@DicType",SqlDbType.Int),
				new SqlParameter("@SubProject",SqlDbType.VarChar),
				new SqlParameter("@Tasks",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_TimeSheetModel.ID;
				_param[2].Value=_TimeSheetModel.IncidentID;
				_param[3].Value=_TimeSheetModel.Date;
				_param[4].Value=_TimeSheetModel.BillableHour;
				_param[5].Value=_TimeSheetModel.UserID;
				_param[6].Value=_TimeSheetModel.DicTitle;
				_param[7].Value=_TimeSheetModel.DicProject;
				_param[8].Value=_TimeSheetModel.DicGroup;
				_param[9].Value=_TimeSheetModel.DicType;
				_param[10].Value=_TimeSheetModel.SubProject;
				_param[11].Value=_TimeSheetModel.Tasks;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表TimeSheet更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_TimeSheetModel">_TimeSheetModel</param>
		/// <returns>影响的行数</returns>
		public int Create_TimeSheetUpdate(SqlTransaction sp,TimeSheetEntity _TimeSheetModel)
		{
            string sqlStr="CreateUpdateDelete_TimeSheetEntity";
			SqlParameter[] _param={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@IncidentID",SqlDbType.Int),
				new SqlParameter("@Date",SqlDbType.DateTime),
				new SqlParameter("@BillableHour",SqlDbType.Float),
				new SqlParameter("@UserID",SqlDbType.Int),
				new SqlParameter("@DicTitle",SqlDbType.Int),
				new SqlParameter("@DicProject",SqlDbType.Int),
				new SqlParameter("@DicGroup",SqlDbType.Int),
				new SqlParameter("@DicType",SqlDbType.Int),
				new SqlParameter("@SubProject",SqlDbType.VarChar),
				new SqlParameter("@Tasks",SqlDbType.VarChar)
				};
				_param[0].Value=1;
				_param[1].Value=_TimeSheetModel.ID;
				_param[2].Value=_TimeSheetModel.IncidentID;
				_param[3].Value=_TimeSheetModel.Date;
				_param[4].Value=_TimeSheetModel.BillableHour;
				_param[5].Value=_TimeSheetModel.UserID;
				_param[6].Value=_TimeSheetModel.DicTitle;
				_param[7].Value=_TimeSheetModel.DicProject;
				_param[8].Value=_TimeSheetModel.DicGroup;
				_param[9].Value=_TimeSheetModel.DicType;
				_param[10].Value=_TimeSheetModel.SubProject;
				_param[11].Value=_TimeSheetModel.Tasks;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表TimeSheet中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_TimeSheetDelete(int ID)
		{
			string sqlStr="CreateUpdateDelete_TimeSheetEntity";
			SqlParameter[] _param={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
			_param[0].Value=2;
			_param[1].Value=ID;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表TimeSheet中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Create_TimeSheetDelete(SqlTransaction sp,int ID)
		{
			string sqlStr="CreateUpdateDelete_TimeSheetEntity";
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
		/// 得到  timesheet 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>timesheet 数据实体</returns>
		public TimeSheetEntity Populate_TimeSheetEntity_FromDr(DataRow row)
		{
			TimeSheetEntity Obj = new TimeSheetEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.IncidentID = (( row["IncidentID"])==DBNull.Value)?0:Convert.ToInt32( row["IncidentID"]);
				Obj.Date = (( row["Date"])==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime( row["Date"]);
				Obj.BillableHour = (float) row["BillableHour"];
				Obj.UserID = (( row["UserID"])==DBNull.Value)?0:Convert.ToInt32( row["UserID"]);
				Obj.DicTitle = (( row["DicTitle"])==DBNull.Value)?0:Convert.ToInt32( row["DicTitle"]);
				Obj.DicProject = (( row["DicProject"])==DBNull.Value)?0:Convert.ToInt32( row["DicProject"]);
				Obj.DicGroup = (( row["DicGroup"])==DBNull.Value)?0:Convert.ToInt32( row["DicGroup"]);
				Obj.DicType = (( row["DicType"])==DBNull.Value)?0:Convert.ToInt32( row["DicType"]);
				Obj.SubProject =  row["SubProject"].ToString();
				Obj.Tasks =  row["Tasks"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  timesheet 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>timesheet 数据实体</returns>
		public TimeSheetEntity Populate_TimeSheetEntity_FromDr(IDataReader dr)
		{
			TimeSheetEntity Obj = new TimeSheetEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.IncidentID = (( dr["IncidentID"])==DBNull.Value)?0:Convert.ToInt32( dr["IncidentID"]);
				Obj.Date = (( dr["Date"])==DBNull.Value)?Convert.ToDateTime(1900-1-1):Convert.ToDateTime( dr["Date"]);
				Obj.BillableHour = (float) dr["BillableHour"];
				Obj.UserID = (( dr["UserID"])==DBNull.Value)?0:Convert.ToInt32( dr["UserID"]);
				Obj.DicTitle = (( dr["DicTitle"])==DBNull.Value)?0:Convert.ToInt32( dr["DicTitle"]);
				Obj.DicProject = (( dr["DicProject"])==DBNull.Value)?0:Convert.ToInt32( dr["DicProject"]);
				Obj.DicGroup = (( dr["DicGroup"])==DBNull.Value)?0:Convert.ToInt32( dr["DicGroup"]);
				Obj.DicType = (( dr["DicType"])==DBNull.Value)?0:Convert.ToInt32( dr["DicType"]);
				Obj.SubProject =  dr["SubProject"].ToString();
				Obj.Tasks =  dr["Tasks"].ToString();
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个TimeSheet对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>TimeSheet对象</returns>
		public TimeSheetEntity Get_TimeSheetEntity (int iD)
		{
			TimeSheetEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from TimeSheet where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_TimeSheetEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表TimeSheet所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< TimeSheetEntity> Get_TimeSheetAll()
		{
			IList< TimeSheetEntity> Obj=new List< TimeSheetEntity>();
			string sqlStr="select * from TimeSheet";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_TimeSheetEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExistTimeSheet(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from TimeSheet where ID=@iD";
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
