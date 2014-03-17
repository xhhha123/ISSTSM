// =================================================================== 
// 项目说明
//====================================================================
// 文件： DataDictionary.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
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
    /// 数据层实例化接口类  dbo.DataDictionary.
    /// </summary>
    public partial class DataDictionaryDataAccessLayer : IDataDictionaryDataAccessLayer
    {
        /// <summary>
        /// 得到数据表DataDictionary所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<DataDictionaryEntity> Get_DataDictionaryAllByID(int ParentId)
        {
            IList<DataDictionaryEntity> Obj = new List<DataDictionaryEntity>();
            string sqlStr = "select * from DataDictionary where ParentID=" + "'" + ParentId + "'" + "and IsVisible=1 order by ItemCode ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_DataDictionaryEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        /// 根据条件 where得到数据表DataDictionary所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public IList<DataDictionaryEntity> Get_DataDictionaryAll(string where)
        {
            IList<DataDictionaryEntity> Obj = new List<DataDictionaryEntity>();
            string sqlStr = "select * from DataDictionary  ";
            if(!string.IsNullOrEmpty(where))
            {
                sqlStr += " where "+where;
            }
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_DataDictionaryEntity_FromDr(dr));
                }
            }
            return Obj;
        }
	}
}
