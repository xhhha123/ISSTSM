// =================================================================== 
// 项目说明
//====================================================================
// 文件： UserInfo.cs
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
    /// 数据层实例化接口类  dbo.UserInfo.
    /// </summary>
    public partial class UserInfoDataAccessLayer : IUserInfoDataAccessLayer
    {
        
        /// <summary>
        /// 根据str,返回一个List<UserInfoEntity>集合
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>List<UserInfoEntity></returns>
        public List<UserInfoEntity> Get_UserInfoByWhere(Dictionary<string, string> dic)
        {

            List<UserInfoEntity> _obj = new List<UserInfoEntity> ();
            string sql = "select * from UserInfo where ";
            StringBuilder sqlStr = new StringBuilder(500);
            sqlStr.Append(sql);

            List<SqlParameter> list = new List<SqlParameter>();
            string strtemp = "";//存储dic里面查询参数的临时变量，用来拼接不同的sql语句
            foreach (var item in dic)
            {
                strtemp += item.Key;
            }
            //遍历dic里面的key value，第一个是登录，第二种是模糊查询，然后拼接sql语句
            int num = 0;
            foreach (var item in dic)
            {
                if (strtemp.Contains("Pwd"))
                {
                    sqlStr.Append(item.Key + "=" + "@" + item.Key + " " + "and" + " ");
                    list.Add(new SqlParameter(item.Key, item.Value));
                }
                else //模糊查询
                {
                    sqlStr.Append(item.Key + "like" + "@"+"'%" + item.Key + "%'  " + "and" + " ");
                    list.Add(new SqlParameter(item.Key, item.Value));
                }
                num++;
            }

            SqlParameter[] _param = list.ToArray();
           string str = sqlStr.ToString();
           string finalsqlstr = str.Substring(0, str.Length - 4);//剪切字符串

           using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, finalsqlstr, _param))
            {
                while (dr.Read())
                {
                    _obj.Add(Populate_UserInfoEntity_FromDr(dr));
                }
            }
            return _obj;
        }


        public List<UserInfoUIEntity> Get_UserInfoAllByUserID(int sectionId)
        {
            List<UserInfoUIEntity> _obj = new List<UserInfoUIEntity>();
            string sqlStr = "select * from UserInfo inner join Section on UserInfo.SectionID=Section.ID";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
            {
                while (dr.Read())
                {
                    _obj.Add(Populate_UserInfoUIEntity_FromDr(dr));
                }
            }
            return _obj;
        }


	}
}
