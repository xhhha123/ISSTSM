using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ISSTSM.Common
{
    using ISSTSM.Entity;
    using System.Web.SessionState;
    using ISSTSM.BusinessLogicLayer;
    using ISSTSM.DataAccessLayer;
    using System.Data;

    /// <summary>
    /// 数据帮助类
    /// </summary>
    public class DataHelper:System.Web.UI.Page
    {
        public static JavaScriptSerializer jss = new JavaScriptSerializer();
        public static string ToJson(object obj)
        {
            return jss.Serialize(obj);
        }

        #region 1.0 根据session 获取当前用户  public UserInfoEntity CurUser
        /// <summary>
        /// 根据session 获取当前用户
        /// </summary>
        public UserInfoEntity CurUser
        {
            get
            {
                if (Session["curuser"] != null)
                {
                    return Session["curuser"] as UserInfoEntity;
                }
                return null;
            }
        } 
        #endregion

        #region  2.0 查询分页，返回json的字符串  string WherePage(string tbName, int PageIndex, int PageSize, string orderby)
        /// <summary>
        /// 2.0 查询分页，返回json的字符串
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="PageIndex">初始页</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="orderby">排序条件</param>
        /// <returns></returns>
        public static DataTable WherePage(string tbName, PageData pagedata, string orderby)
        {
            pagedata.total = Extension.GetTotalNum(tbName);
            return Extension.GetPageData(tbName, pagedata.PageIndex, pagedata.PageSize, orderby);
        } 
        #endregion

        #region  3.0 有父子节点的表 查询分页，返回json的字符串  string WherePage(string tbName, int PageIndex, int PageSize, string orderby)
        /// <summary>
        /// 3.0 有父子节点的表 查询分页，返回json的字符串
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="PageIndex">初始页</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="orderby">排序条件</param>
        /// <returns></returns>
        public static DataTable WherePage(string tbName, PageData pagedata, string PName, int val, string orderby)
        {
            pagedata.total = Extension.GetTotalNum(tbName,PName,val);
            return Extension.GetPageData(tbName, pagedata.PageIndex, pagedata.PageSize,PName,val ,orderby);
        }
        #endregion

        #region  4.0 有父子节点的表 查询分页，返回json的字符串  string WherePage(string tbName, int PageIndex, int PageSize, string orderby)
        /// <summary>
        /// 3.0 有父子节点的表 查询分页，返回json的字符串
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="PageIndex">初始页</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="orderby">排序条件</param>
        ///  <param name="where">是否显示 "and  what=what"</param>
        /// <returns></returns>
        public static DataTable WherePage(string tbName, PageData pagedata, string PName, int val, string where, string orderby)
        {
            pagedata.total = Extension.GetTotalNum(tbName, PName, val);
            return Extension.GetPageData(tbName, pagedata.PageIndex, pagedata.PageSize, PName, val,where, orderby);
        }
        #endregion

        #region 5.0 根据ParentID得到所有数据  public static DataTable GetParentData(string tbName, string ParentID, string ParentVal,string IsVisible,string IsVisibleVal, string orderby)
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
        public static DataTable GetParentData(string tbName, string ParentID, string ParentVal, string IsVisible, string IsVisibleVal, string orderby)
        {
            return Extension.GetSubData(tbName, ParentID, ParentVal, IsVisible, IsVisibleVal, orderby);
        } 
        #endregion
        #region 6.0 根据Role.ID查询对应的Module  public static DataTable GetModuleData(string id)
        /// <summary>
        /// 6.0 根据Role.ID查询对应的Module  public static DataTable GetModuleData(string id)
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public static DataTable GetModuleData(int RoleId)
        {
            return Extension.GetModuleData(RoleId);
        } 
        #endregion

        #region  6.1 根据Role.ID以及Module.ID查询对应的AllPermission   static DataTable GetPermissData(int RoleId, int ModuleId)
        /// <summary>
        /// 6.1 根据Role.ID以及Module.ID查询对应的AllPermission  public static DataTable GetPermissData(int RoleId, int ModuleId)
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public static DataTable GetPermissData(int RoleId, int ModuleId)
        {
            return Extension.GetPermissData(RoleId,ModuleId);
        }
        #endregion

        #region  6.1.2 根据Role.ID以及Module.ID查询对应的Permission   static DataTable GetCurPermissData(int RoleId, int ModuleId)
        /// <summary>
        /// 6.1 根据Role.ID以及Module.ID查询对应的Permission  static DataTable GetCurPermissData(int RoleId, int ModuleId)
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public static DataTable GetCurPermissData(int RoleId, int ModuleId)
        {
            return Extension.GetCurPermissData(RoleId, ModuleId);
        }
        #endregion
       
        /// <summary>
        /// 7.0 模糊查询 static DataTable SearchData(string tbName,Dictionary<string,string>fields)
        /// </summary>
        /// <returns></returns>
        public static DataTable SearchData(string tbName, PageData pagedata, Dictionary<string, string> fields)
        {
           // pagedata.total = Extension.GetTotalNum(tbName);
            return Extension.SearchData(tbName, fields);
        }
    }
}