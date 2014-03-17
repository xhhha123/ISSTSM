// =================================================================== 
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： Incident.cs
// 项目名称：SunCity_MS
// 创建时间：2014/1/17
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
    /// 数据层实例化接口类 dbo.Incident.
    /// </summary>
    public partial class IncidentDataAccessLayer : IIncidentDataAccessLayer
    {
        #region 构造函数
        /// <summary>
        /// ??????
        /// </summary>
        public IncidentDataAccessLayer()
        {
        }
        #endregion

        #region -----------实例化接口函数-----------

        #region 添加更新删除
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="_IncidentModel">Incident实体</param>
        /// <returns>新插入记录的编号</returns>
        public int Create_IncidentInsert(IncidentEntity _IncidentModel)
        {
            string sqlStr = "CreateUpdateDelete_IncidentEntity";
            int res;
            SqlParameter[] _param ={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@IncidentNumber",SqlDbType.VarChar),
			new SqlParameter("@AssignedTo",SqlDbType.Int),
			new SqlParameter("@ReportedBy",SqlDbType.Int),
			new SqlParameter("@DicPriority",SqlDbType.Int),
			new SqlParameter("@DicCountry",SqlDbType.Int),
			new SqlParameter("@DicProduct",SqlDbType.Int),
			new SqlParameter("@DicStatus",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime),
			new SqlParameter("@StatusFollowUp",SqlDbType.VarChar),
			new SqlParameter("@Summary",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@IsFill",SqlDbType.Int)
			};
            _param[0].Value = 0;
            _param[1].Value = _IncidentModel.ID;
            _param[2].Value = _IncidentModel.IncidentNumber;
            _param[3].Value = _IncidentModel.AssignedTo;
            _param[4].Value = _IncidentModel.ReportedBy;
            _param[5].Value = _IncidentModel.DicPriority;
            _param[6].Value = _IncidentModel.DicCountry;
            _param[7].Value = _IncidentModel.DicProduct;
            _param[8].Value = _IncidentModel.DicStatus;
            _param[9].Value = _IncidentModel.CreateDate;
            _param[10].Value = _IncidentModel.StatusFollowUp;
            _param[11].Value = _IncidentModel.Summary;
            _param[12].Value = _IncidentModel.Description;
            _param[13].Value = _IncidentModel.IsFill;
            res = (int)SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlStr, _param);
            return res;
        }
        /// <summary>
        /// 向数据库中插入一条新记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="_IncidentModel">Incident实体</param>
        /// <returns>新插入记录的编号</returns>
        public int Create_IncidentInsert(SqlTransaction sp, IncidentEntity _IncidentModel)
        {
            string sqlStr = "CreateUpdateDelete_IncidentEntity";
            int res;
            SqlParameter[] _param ={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			new SqlParameter("@IncidentNumber",SqlDbType.VarChar),
			new SqlParameter("@AssignedTo",SqlDbType.Int),
			new SqlParameter("@ReportedBy",SqlDbType.Int),
			new SqlParameter("@DicPriority",SqlDbType.Int),
			new SqlParameter("@DicCountry",SqlDbType.Int),
			new SqlParameter("@DicProduct",SqlDbType.Int),
			new SqlParameter("@DicStatus",SqlDbType.Int),
			new SqlParameter("@CreateDate",SqlDbType.DateTime),
			new SqlParameter("@StatusFollowUp",SqlDbType.VarChar),
			new SqlParameter("@Summary",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@IsFill",SqlDbType.Int)
			};
            _param[0].Value = 0;
            _param[1].Value = _IncidentModel.ID;
            _param[2].Value = _IncidentModel.IncidentNumber;
            _param[3].Value = _IncidentModel.AssignedTo;
            _param[4].Value = _IncidentModel.ReportedBy;
            _param[5].Value = _IncidentModel.DicPriority;
            _param[6].Value = _IncidentModel.DicCountry;
            _param[7].Value = _IncidentModel.DicProduct;
            _param[8].Value = _IncidentModel.DicStatus;
            _param[9].Value = _IncidentModel.CreateDate;
            _param[10].Value = _IncidentModel.StatusFollowUp;
            _param[11].Value = _IncidentModel.Summary;
            _param[12].Value = _IncidentModel.Description;
            _param[13].Value = _IncidentModel.IsFill;
            res = (int)SqlHelper.ExecuteScalar(sp, CommandType.StoredProcedure, sqlStr, _param);
            return res;
        }


        /// <summary>
        /// 向数据表Incident更新一条记录。
        /// </summary>
        /// <param name="_IncidentModel">_IncidentModel</param>
        /// <returns>影响的行数</returns>
        public int Create_IncidentUpdate(IncidentEntity _IncidentModel)
        {
            string sqlStr = "CreateUpdateDelete_IncidentEntity";
            SqlParameter[] _param ={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@IncidentNumber",SqlDbType.VarChar),
				new SqlParameter("@AssignedTo",SqlDbType.Int),
				new SqlParameter("@ReportedBy",SqlDbType.Int),
				new SqlParameter("@DicPriority",SqlDbType.Int),
				new SqlParameter("@DicCountry",SqlDbType.Int),
				new SqlParameter("@DicProduct",SqlDbType.Int),
				new SqlParameter("@DicStatus",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime),
				new SqlParameter("@StatusFollowUp",SqlDbType.VarChar),
				new SqlParameter("@Summary",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@IsFill",SqlDbType.Int)
				};
            _param[0].Value = 1;
            _param[1].Value = _IncidentModel.ID;
            _param[2].Value = _IncidentModel.IncidentNumber;
            _param[3].Value = _IncidentModel.AssignedTo;
            _param[4].Value = _IncidentModel.ReportedBy;
            _param[5].Value = _IncidentModel.DicPriority;
            _param[6].Value = _IncidentModel.DicCountry;
            _param[7].Value = _IncidentModel.DicProduct;
            _param[8].Value = _IncidentModel.DicStatus;
            _param[9].Value = _IncidentModel.CreateDate;
            _param[10].Value = _IncidentModel.StatusFollowUp;
            _param[11].Value = _IncidentModel.Summary;
            _param[12].Value = _IncidentModel.Description;
            _param[13].Value = _IncidentModel.IsFill;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlStr, _param);
        }
        /// <summary>
        /// 向数据表Incident更新一条记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="_IncidentModel">_IncidentModel</param>
        /// <returns>影响的行数</returns>
        public int Create_IncidentUpdate(SqlTransaction sp, IncidentEntity _IncidentModel)
        {
            string sqlStr = "CreateUpdateDelete_IncidentEntity";
            SqlParameter[] _param ={
				new SqlParameter("@DataAction",SqlDbType.Int),
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@IncidentNumber",SqlDbType.VarChar),
				new SqlParameter("@AssignedTo",SqlDbType.Int),
				new SqlParameter("@ReportedBy",SqlDbType.Int),
				new SqlParameter("@DicPriority",SqlDbType.Int),
				new SqlParameter("@DicCountry",SqlDbType.Int),
				new SqlParameter("@DicProduct",SqlDbType.Int),
				new SqlParameter("@DicStatus",SqlDbType.Int),
				new SqlParameter("@CreateDate",SqlDbType.DateTime),
				new SqlParameter("@StatusFollowUp",SqlDbType.VarChar),
				new SqlParameter("@Summary",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@IsFill",SqlDbType.Int)
				};
            _param[0].Value = 1;
            _param[1].Value = _IncidentModel.ID;
            _param[2].Value = _IncidentModel.IncidentNumber;
            _param[3].Value = _IncidentModel.AssignedTo;
            _param[4].Value = _IncidentModel.ReportedBy;
            _param[5].Value = _IncidentModel.DicPriority;
            _param[6].Value = _IncidentModel.DicCountry;
            _param[7].Value = _IncidentModel.DicProduct;
            _param[8].Value = _IncidentModel.DicStatus;
            _param[9].Value = _IncidentModel.CreateDate;
            _param[10].Value = _IncidentModel.StatusFollowUp;
            _param[11].Value = _IncidentModel.Summary;
            _param[12].Value = _IncidentModel.Description;
            _param[13].Value = _IncidentModel.IsFill;
            return SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlStr, _param);
        }

        /// <summary>
        /// 删除数据表Incident中的一条记录
        /// </summary>
        /// <param name="ID">iD</param>
        /// <returns>影响的行数</returns>
        public int Create_IncidentDelete(int ID)
        {
            string sqlStr = "CreateUpdateDelete_IncidentEntity";
            SqlParameter[] _param ={
			new SqlParameter("@DataAction",SqlDbType.VarChar),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
            _param[0].Value = 2;
            _param[1].Value = ID;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlStr, _param);
        }

        /// <summary>
        /// 删除数据表Incident中的一条记录,带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="ID">iD</param>
        /// <returns>影响的行数</returns>
        public int Create_IncidentDelete(SqlTransaction sp, int ID)
        {
            string sqlStr = "CreateUpdateDelete_IncidentEntity";
            SqlParameter[] _param ={
			new SqlParameter("@DataAction",SqlDbType.Int),
			new SqlParameter("@ID",SqlDbType.Int),
			
			};
            _param[0].Value = 2;
            _param[1].Value = ID;
            return SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlStr, _param);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  incident 数据实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>incident 数据实体</returns>
        public IncidentEntity Populate_IncidentEntity_FromDr(DataRow row)
        {
            IncidentEntity Obj = new IncidentEntity();
            if (row != null)
            {
                Obj.ID = ((row["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["ID"]);
                Obj.IncidentNumber = row["IncidentNumber"].ToString();
                Obj.AssignedTo = ((row["AssignedTo"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["AssignedTo"]);
                Obj.ReportedBy = ((row["ReportedBy"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["ReportedBy"]);
                Obj.DicPriority = ((row["DicPriority"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["DicPriority"]);
                Obj.DicCountry = ((row["DicCountry"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["DicCountry"]);
                Obj.DicProduct = ((row["DicProduct"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["DicProduct"]);
                Obj.DicStatus = ((row["DicStatus"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["DicStatus"]);
                Obj.CreateDate = ((row["CreateDate"]) == DBNull.Value) ? Convert.ToDateTime(1900 - 1 - 1) : Convert.ToDateTime(row["CreateDate"]);
                Obj.StatusFollowUp = row["StatusFollowUp"].ToString();
                Obj.Summary = row["Summary"].ToString();
                Obj.Description = row["Description"].ToString();
                Obj.IsFill = ((row["IsFill"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["IsFill"]);
            }
            else
            {
                return null;
            }
            return Obj;
        }

        /// <summary>
        /// 得到  incident 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>incident 数据实体</returns>
        public IncidentEntity Populate_IncidentEntity_FromDr(IDataReader dr)
        {
            IncidentEntity Obj = new IncidentEntity();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.IncidentNumber = dr["IncidentNumber"].ToString();
            Obj.AssignedTo = ((dr["AssignedTo"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["AssignedTo"]);
            Obj.ReportedBy = ((dr["ReportedBy"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ReportedBy"]);
            Obj.DicPriority = ((dr["DicPriority"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["DicPriority"]);
            Obj.DicCountry = ((dr["DicCountry"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["DicCountry"]);
            Obj.DicProduct = ((dr["DicProduct"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["DicProduct"]);
            Obj.DicStatus = ((dr["DicStatus"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["DicStatus"]);
            Obj.CreateDate = ((dr["CreateDate"]) == DBNull.Value) ? Convert.ToDateTime(1900 - 1 - 1) : Convert.ToDateTime(dr["CreateDate"]);
            Obj.StatusFollowUp = dr["StatusFollowUp"].ToString();
            Obj.Summary = dr["Summary"].ToString();
            Obj.Description = dr["Description"].ToString();
            Obj.IsFill = ((dr["IsFill"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["IsFill"]);

            return Obj;
        }
        #endregion

        /// <summary>
        /// 根据ID,返回一个Incident对象
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>Incident对象</returns>
        public IncidentEntity Get_IncidentEntity(int iD)
        {
            IncidentEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@ID",SqlDbType.Int)
			};
            _param[0].Value = iD;
            string sqlStr = "select * from Incident where ID=@ID";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_IncidentEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        /// <summary>
        /// 得到数据表Incident所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<IncidentEntity> Get_IncidentAll()
        {
            IList<IncidentEntity> Obj = new List<IncidentEntity>();
            string sqlStr = "select * from Incident";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_IncidentEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        /// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
        public bool IsExistIncident(int iD)
        {
            SqlParameter[] _param ={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value = iD;
            string sqlStr = "select Count(*) from Incident where ID=@iD";
            int a = Convert.ToInt32(SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, sqlStr, _param));
            if (a > 0)
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

