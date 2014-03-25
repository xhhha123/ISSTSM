using ISSTSM.IDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ISSTSM.DataAccessLayer
{

    public class Extension
    {
        #region  1.0得到分页后的数据   static DataTable GetPageData(string tbName, int PageIndex, int PageSize, string orderby)
        /// <summary>
        /// 得到分页后的数据
        /// </summary>
        /// <param name="tbName"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static DataTable GetPageData(string tbName, int PageIndex, int PageSize, string orderby)
        {
            StringBuilder sqlStr = new StringBuilder(500);
            sqlStr.AppendLine("select  * from ");
            sqlStr.AppendLine("(select  row_number() over(order by  " + orderby + ") as rownum,* from " + tbName + ") ");
            sqlStr.AppendLine("as page_table ");
            sqlStr.AppendLine("where rownum between (" + PageIndex + " - 1) * " + PageSize + " + 1 and  " + PageIndex + " * " + PageSize);
            sqlStr.AppendLine("order by " + orderby);
            DataTable dt = new DataTable();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr.ToString()))
            {

                int fieldCount = dr.FieldCount;
                for (int i = 0; i < fieldCount; i++)
                {
                    dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
                }
                dt.BeginLoadData();
                object[] objValues = new object[fieldCount];
                while (dr.Read())
                {
                    dr.GetValues(objValues);
                    dt.LoadDataRow(objValues, true);
                }
                dt.EndLoadData();
            }        
            return dt;
        }
        
        #endregion

        #region  1.1 有父子节点的表，得到分页后的数据   static List<object> GetPageData(string tbName, int PageIndex, int PageSize, string orderby)
        /// <summary>
        /// 1.1得到分页后的数据
        /// </summary>
        /// <param name="tbName"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="PName"></param>
        /// <param name="val"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static DataTable GetPageData(string tbName, int PageIndex, int PageSize, string PName,int val, string orderby)
        {
            StringBuilder sqlStr = new StringBuilder(500);
            sqlStr.AppendLine("select  * from ");
            sqlStr.AppendLine("(select  row_number() over(order by  " + orderby + ") as rownum,* from " + tbName + "  where");
            sqlStr.AppendLine(PName + " =" + val + "  and IsVisible=1)");
            sqlStr.AppendLine("as page_table ");
            sqlStr.AppendLine("where rownum between (" + PageIndex + " - 1) * " + PageSize + " + 1 and  " + PageIndex + " * " + PageSize);
            sqlStr.AppendLine("order by " + orderby);
            DataTable dt = new DataTable();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr.ToString()))
            {

                int fieldCount = dr.FieldCount;
                for (int i = 0; i < fieldCount; i++)
                {
                    dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
                }
                dt.BeginLoadData();
                object[] objValues = new object[fieldCount];
                while (dr.Read())
                {
                    dr.GetValues(objValues);
                    dt.LoadDataRow(objValues, true);
                }
                dt.EndLoadData();
            }
            return dt;
        }

        #endregion

        #region  1.2 有父子节点的表，得到分页后的数据   static List<object> GetPageData(string tbName, int PageIndex, int PageSize, string orderby)
        /// <summary>
        /// 1.1得到分页后的数据
        /// </summary>
        /// <param name="tbName"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="PName"></param>
        /// <param name="val"></param>
        /// <param name="orderby"></param>
        ///  <param name="where">是否显示条件</param>
        /// <returns></returns>
        public static DataTable GetPageData(string tbName, int PageIndex, int PageSize, string PName, int val, string where,string orderby )
        {
            StringBuilder sqlStr = new StringBuilder(500);
            sqlStr.AppendLine("select  * from ");
            sqlStr.AppendLine("(select  row_number() over(order by  " + orderby + ") as rownum,* from " + tbName + "  where");
            sqlStr.AppendLine(PName + " =" + val + "  "+where+")");
            sqlStr.AppendLine("as page_table ");
            sqlStr.AppendLine("where rownum between (" + PageIndex + " - 1) * " + PageSize + " + 1 and  " + PageIndex + " * " + PageSize);
            sqlStr.AppendLine("order by " + orderby);
            DataTable dt = new DataTable();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr.ToString()))
            {

                int fieldCount = dr.FieldCount;
                for (int i = 0; i < fieldCount; i++)
                {
                    dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
                }
                dt.BeginLoadData();
                object[] objValues = new object[fieldCount];
                while (dr.Read())
                {
                    dr.GetValues(objValues);
                    dt.LoadDataRow(objValues, true);
                }
                dt.EndLoadData();
            }
            return dt;
        }

        #endregion
     
        #region 2.0 得到tbName所有的数据行数，返回Int   static int GetTotalNum(string tbName)
       /// <summary>
       /// 得到tbName所有的数据行数，返回Int
       /// </summary>
       /// <param name="tbName">要查询数据表</param>
       /// <returns></returns>
       public static int GetTotalNum(string tbName)
       {
           string sql = "select COUNT(*) from " + tbName;
           return (int)SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, sql);
       } 
       #endregion

       #region 2.1 有父子节点的表 得到tbName所有的数据行数，返回Int   static int GetTotalNum(string tbName)
       /// <summary>
       /// 得到tbName所有的数据行数，返回Int
       /// </summary>
       /// <param name="tbName">要查询数据表</param>
       /// <returns></returns>
       public static int GetTotalNum(string tbName,string PName,int val)
       {
           StringBuilder sql = new StringBuilder(500);
           sql.Append("select COUNT(*) from " +tbName);
           sql.AppendLine(" where "+ PName + "=" + val);
           return (int)SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, sql.ToString());
       }
       #endregion

       #region  3.0 根据ParentID得到所有数据  
       /// <summary>
       /// 得到父节点下面所有子节点的数据
       /// </summary>
       /// <param name="tbName">表名</param>
       /// <param name="ParentID">字段名</param>
       /// <param name="ParentVal">字段值</param>
       /// <param name="IsVisible">删除标示</param>
       /// <param name="IsVisibleVal">删除值</param>
       /// <param name="orderby">排序名</param>
       /// <returns></returns>
       public static DataTable GetSubData(string tbName, string ParentID, string ParentVal,string IsVisible,string IsVisibleVal, string orderby)
       {
           StringBuilder sqlStr = new StringBuilder(500);
           sqlStr.AppendLine("select  * from ");
           sqlStr.AppendLine(tbName);
           sqlStr.AppendLine("where "+ParentID+"="+ParentVal);
           if(!string.IsNullOrEmpty(IsVisible)||!string.IsNullOrEmpty(IsVisibleVal))
           {
               sqlStr.AppendLine(" and "+IsVisible+"="+IsVisibleVal);
           }
           sqlStr.AppendLine("order by " + orderby);
           DataTable dt = new DataTable();
           using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr.ToString()))
           {

               int fieldCount = dr.FieldCount;
               for (int i = 0; i < fieldCount; i++)
               {
                   dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
               }
               dt.BeginLoadData();
               object[] objValues = new object[fieldCount];
               while (dr.Read())
               {
                   dr.GetValues(objValues);
                   dt.LoadDataRow(objValues, true);
               }
               dt.EndLoadData();
           }
           return dt;
       }

       #endregion

       #region  4.0 根据Role.ID查询对应的Module  public static DataTable GetModuleData(string id)
       /// <summary>
       /// 根据Role.ID查询对应的Module
       /// </summary>
       /// <param name="RoleId">权限ID</param>
       /// <returns></returns>
       public static DataTable GetModuleData(int RoleId)
       {
           StringBuilder sqlStr = new StringBuilder(500);
           sqlStr.AppendLine("select * from Module where Module.ID in ");
           sqlStr.AppendLine("(select ModuleID from ModulePermission where ModulePermission.ID in  ");
           sqlStr.AppendLine(" (select ModulePermissionID from RoleModulePermission where RoleID="+RoleId+") ");
           sqlStr.AppendLine(" ) ");
           DataTable dt = new DataTable();
           using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr.ToString()))
           {

               int fieldCount = dr.FieldCount;
               for (int i = 0; i < fieldCount; i++)
               {
                   dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
               }
               dt.BeginLoadData();
               object[] objValues = new object[fieldCount];
               while (dr.Read())
               {
                   dr.GetValues(objValues);
                   dt.LoadDataRow(objValues, true);
               }
               dt.EndLoadData();
           }
           return dt;
       }

       #endregion

       #region  4.1  根据Role.ID以及Module.ID查询对应的AllPermission   static DataTable GetPerData(int RoleId,int ModuleId)
       /// <summary>
       /// 根据Role.ID以及Module.ID查询对应的AllPermission
       /// </summary>
       /// <param name="RoleId">权限ID</param>
       /// <param name="ModuleId">模块ID</param>
       /// <returns></returns>
       public static DataTable GetPermissData(int RoleId,int ModuleId)
       {
           StringBuilder sqlStr = new StringBuilder(500);
           sqlStr.AppendLine(" select * from Permission where Permission.ID in ");
           sqlStr.AppendLine(" (select PermissionID from ModulePermission   ");
           sqlStr.AppendLine(" inner join Module on Module.ID=ModulePermission.ModuleID ");
           sqlStr.AppendLine("where ModulePermission.ID in  ");
           sqlStr.AppendLine(" (select ModulePermissionID from RoleModulePermission where  Module.ID="+ModuleId+")  ");
           sqlStr.AppendLine(" )");
           DataTable dt = new DataTable();
           using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr.ToString()))
           {

               int fieldCount = dr.FieldCount;
               for (int i = 0; i < fieldCount; i++)
               {
                   dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
               }
               dt.BeginLoadData();
               object[] objValues = new object[fieldCount];
               while (dr.Read())
               {
                   dr.GetValues(objValues);
                   dt.LoadDataRow(objValues, true);
               }
               dt.EndLoadData();
           }
           return dt;
       }

       #endregion

       #region  4.2  根据Role.ID以及Module.ID查询对应的Permission   static DataTable GetCurPermissData(int RoleId, int ModuleId)
       /// <summary>
       /// 根据Role.ID以及Module.ID查询对应的当前对应的Permission 标识isdelete=false
       /// </summary>
       /// <param name="RoleId">权限ID</param>
       /// <param name="ModuleId">模块ID</param>
       /// <returns></returns>
       public static DataTable GetCurPermissData(int RoleId, int ModuleId)
       {
           StringBuilder sqlStr = new StringBuilder(500);
           sqlStr.AppendLine(" select * from Permission where Permission.ID in ");
           sqlStr.AppendLine(" (select PermissionID from ModulePermission   ");
           sqlStr.AppendLine(" inner join Module on Module.ID=ModulePermission.ModuleID ");
           sqlStr.AppendLine("where ModulePermission.IsDeleted=0 and ModulePermission.ID in  ");
           sqlStr.AppendLine(" (select ModulePermissionID from RoleModulePermission where   Module.ID=" + ModuleId + ")  ");
           sqlStr.AppendLine(" )");
           DataTable dt = new DataTable();
           using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr.ToString()))
           {

               int fieldCount = dr.FieldCount;
               for (int i = 0; i < fieldCount; i++)
               {
                   dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
               }
               dt.BeginLoadData();
               object[] objValues = new object[fieldCount];
               while (dr.Read())
               {
                   dr.GetValues(objValues);
                   dt.LoadDataRow(objValues, true);
               }
               dt.EndLoadData();
           }
           return dt;
       }
       #endregion

       #region 5.0 模糊查询 static DataTable SearchData(string tbName,Dictionary<string,string>fields)
       /// <summary>
       /// 5.0 模糊查询 static DataTable SearchData(string tbName,Dictionary<string,string>fields)
       /// </summary>
       /// <param name="tbName">表名称</param>
       /// <param name="fields">字段值以及字段名</param>
       /// <returns></returns>
       public static DataTable SearchData(string tbName, Dictionary<string, string> fields)
       {
           StringBuilder sql = new StringBuilder();
           string sqlStr = "";
           //拼接字符串
           sql.Append("select * from " + tbName + " where " + " ");
           //遍历fields里面的键值对 拼接成为 select * from tb where name=value
           if (fields.Keys.Count > 1)
           {
               foreach (string item in fields.Keys)
               {
                   sql.Append(item + " like " + "'%"+fields[item] +"%'"+ "  and"+" ");
               }
               sqlStr = sql.ToString().Substring(0, sql.Length - 4).ToString();
           }
           else
           {
               foreach (string item in fields.Keys)
               {
                   sql.Append(item + " like " + "'%" + fields[item] + "%'" + " ");
               }
               sqlStr = sql.ToString();
           }

           DataTable dt = new DataTable();
           using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
           {

               int fieldCount = dr.FieldCount;
               for (int i = 0; i < fieldCount; i++)
               {
                   dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
               }
               dt.BeginLoadData();
               object[] objValues = new object[fieldCount];
               while (dr.Read())
               {
                   dr.GetValues(objValues);
                   dt.LoadDataRow(objValues, true);
               }
               dt.EndLoadData();
           }
           return dt;
       } 
       #endregion

       #region 5.1 模糊查询-支持日期 static DataTable SearchData(string tbName,string date,Dictionary<string,string>fields)
       /// <summary>
       /// 5.1 模糊查询-支持日期 static DataTable SearchData(string tbName,string date, Dictionary<string,string>fields)
       /// </summary>
       /// <param name="tbName">表名称</param>
       /// <param name="date">日期字段</param>
       /// <param name="fields">字段值以及字段名</param>
       /// <returns></returns>
       public static DataTable SearchData(string tbName,string date, Dictionary<string, string> fields)
       {
           StringBuilder sql = new StringBuilder();
           string sqlStr = "";
           //拼接字符串
           sql.Append("select * from " + tbName + " where " + " ");
           //遍历fields里面的键值对 拼接成为 select * from tb where name like '%value% and date between 2011-1-1 and 2013-1-1 '
           if (fields.Keys.Count > 1)
           {
               foreach (string item in fields.Keys)
               {
                   if (item != "dateBefore" && item != "dateAfter")
                   {
                       sql.Append(item + " like " + "'%" + fields[item] + "%'" + "  and" + " ");
                   }
                   if (item == "dateBefore")
                   {
                       sql.Append(date + " between "+" '"+fields[item]+"' and ");
                   }
                   if (item == "dateAfter")
                   {
                       sql.Append(" '" + fields[item] + "' ");
                   }
               }
               sqlStr = sql.ToString();
           }
           else
           {
               foreach (string item in fields.Keys)
               {
                   sql.Append(item + " like " + "'%" + fields[item] + "%'" + " ");
               }
               sqlStr = sql.ToString();
           }

           DataTable dt = new DataTable();
           using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
           {

               int fieldCount = dr.FieldCount;
               for (int i = 0; i < fieldCount; i++)
               {
                   dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
               }
               dt.BeginLoadData();
               object[] objValues = new object[fieldCount];
               while (dr.Read())
               {
                   dr.GetValues(objValues);
                   dt.LoadDataRow(objValues, true);
               }
               dt.EndLoadData();
           }
           return dt;
       }
       #endregion

       #region 6.0 条件查询 static DataTable GetDataByWhere(string tbName,Dictionary<string, string> fields)
       /// <summary>
       /// 6.0 条件查询 static DataTable GetDataByWhere(string tbName,Dictionary<string, string> fields)
       /// </summary>
       /// <param name="tbName"></param>
       /// <param name="fields"></param>
       /// <returns></returns>
       public static DataTable GetDataByWhere(string tbName, Dictionary<string, string> fields)
       {
           StringBuilder sql = new StringBuilder();
           string sqlStr = "";
           //拼接字符串
           sql.Append("select * from " + tbName + " where " + " ");
           //遍历fields里面的键值对 拼接成为 select * from tb where name=value
           if (fields.Keys.Count > 1)
           {
               foreach (string item in fields.Keys)
               {
                   sql.Append(item + "=" + "'" + fields[item] + "'" + "  and" + " ");
               }
               sqlStr = sql.ToString().Substring(0, sql.Length - 4).ToString();
           }
           else
           {
               foreach (string item in fields.Keys)
               {
                   sql.Append(item + "=" + "'" + fields[item] + "'" + " ");
               }
               sqlStr = sql.ToString();
           }
           DataTable dt = new DataTable();
           using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, sqlStr))
           {

               int fieldCount = dr.FieldCount;
               for (int i = 0; i < fieldCount; i++)
               {
                   dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
               }
               dt.BeginLoadData();
               object[] objValues = new object[fieldCount];
               while (dr.Read())
               {
                   dr.GetValues(objValues);
                   dt.LoadDataRow(objValues, true);
               }
               dt.EndLoadData();
           }
           return dt;
       } 
       #endregion
    }
}
