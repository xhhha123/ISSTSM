// =================================================================== 
// 项目说明
//====================================================================
// 文件： Incident.cs
// 项目名称：SunCity_MS 
// 创建时间：2014/1/9
// 负责人：xhh
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
    /// 数据层实例化接口类  dbo.Incident.
    /// </summary>
    public partial class IncidentDataAccessLayer : IIncidentDataAccessLayer
    {
        public  IList<IncidentEntity> Get_IncidentAllByWhere(string where)
        {
            IList<IncidentEntity> Obj = new List<IncidentEntity>();
            string sqlStr = "select * from Incident ";
            if (!string.IsNullOrEmpty(where))
            {
                sqlStr += " where " + where;
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_IncidentEntity_FromDr(dr));
                }
            }
            return Obj;
        }
	}
}
