using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Common
{
    using ISSTSM.Entity;
    using ISSTSM.BusinessLogicLayer;
    using ISSTSM.DALFactory;

    /// <summary>
    /// 统一登录验证处理
    /// </summary>
    public class BasePage:System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoginValible();
            InitCache();         
        }
        #region 将dictionary的数据放到缓存cache中   InitCache
        /// <summary>
        /// 将dictionary的数据放到缓存cache中
        /// </summary>
        /// 
        private void InitCache()
        {
            IList<DataDictionaryEntity> parentList = DataDictionary_BLLSub.Get_DataDictionaryAllByID(0);
            IList<DataDictionaryEntity> allList = null;
            if (Cache["DataDictionary"] == null)
            {
                 allList = DataDictionary_BLLSub.Get_DataDictionaryAll(" IsVisible=1 order by ItemCode");
                 DataCache.SetCache("DataDictionary",allList);
                 for (int i = 0; i < allList.Count; i++)
                 {
                     string key = allList[i].ID.ToString();
                     if (Cache[key] == null)
                     {
                         DataCache.SetCache(key, allList[i]);
                     }
                 }
            }
            foreach (var dic in parentList)
            {
                if (Cache[dic.ItemName] == null)//例如Cache["Project"]
                {
                    //将project下面的子选项加载到 Cache["Project"]对象中
                    IList<DataDictionaryEntity> subList = DataDictionary_BLLSub.Get_DataDictionaryAllByID(dic.ID);
                    DataCache.SetCache(dic.ItemName, subList);
                }                              
            }
        } 
        #endregion

        #region 登录验证  private void LoginValible()
        /// <summary>
        /// 登录验证
        /// </summary>
        private void LoginValible()
        {
            if (Session["curuser"] == null)
            {
                if (this.Request.Cookies["remeber"] != null)
                {
                    int id = Convert.ToInt32(Request.Cookies["remeber"].Value);
                    UserInfoEntity entity = UserInfoBLLBase.Get_UserInfoEntity(id);
                    Session["curuser"] = entity;
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }
        
        #endregion


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

        /// <summary>
        /// 获取当前的moduleID
        /// </summary>
        /// <returns></returns>
        public string GetModuleId()
        {
            string moduleid = Request.Params["menutreeid"];
            return moduleid;
        }
    }
}