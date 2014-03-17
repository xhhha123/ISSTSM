using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Actions
{
    using ISSTSM.BusinessLogicLayer;
    using ISSTSM.Common;
    using ISSTSM.DALFactory;
    using ISSTSM.Entity;
    using System.Collections;

    /// <summary>
    /// DictionaryHandel 的摘要说明
    /// </summary>
    public class DictionaryHandel : IHttpHandler
    {
        string type = "";
        string id = "";
        string pageIndex ;
        string pageSize;
        string ParentID;
        string ItemCode;
        string ItemName;
        string IsVisible;
        string Sort;
        string editOrload;
        public void ProcessRequest(HttpContext context)
        {
           context.Response.ContentType = "text/plain";
           type=context.Request.Params["t"];
           id = context.Request.Params["id"];
           pageIndex = context.Request.Params["page"];
           pageSize = context.Request.Params["rows"];
           ParentID = context.Request.Params["ParentID"];
           ItemCode = context.Request.Params["ItemCode"];
           ItemName = context.Request.Params["ItemName"];
           IsVisible = context.Request.Params["IsVisible"];
           Sort = context.Request.Params["Sort"];
           editOrload = context.Request.Params["editOrload"];
           switch (type)
           {
               case "load":
                   Load(pageIndex, pageSize);
                   break;
               case "edit":
                   edit(id, editOrload);
                   break;
               case "del":
                   del();
                   break;
               case "add":
                   add();
                   break;
               case "loadSub":
                   loadSub();
                   break;
               default:
                   break;
           }
        }
            

        #region 1.0 加载所有dictionary 父节点数据 private void Load()
        /// <summary>
        /// 加载所有dictionary数据
        /// </summary>
        private void Load(string pageIndex,string pageSize)
        {
            //1.0从数据库中提取父级dictionary
            //IList<DataDictionaryEntity> list = DataDictionary_BLLSub.Get_DataDictionaryAllByID(0);
            //HttpContext.Current.Response.Write(Common.DataHelper.ToJson(list));
            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<DataDictionaryEntity> list = new Common.TBToList<DataDictionaryEntity>();
            pageData.rows = list.ToList(Common.DataHelper.WherePage("DataDictionary", pageData, "ParentID", 0, "Sort"));     
            //pageData.permission = Permission_BLLSub.GetPermissionByUserID(1, 2);
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));

        } 
        #endregion

        #region 1.1 编辑 父节点数据  private void edit(string ID, string editOrload)
        /// <summary>
        /// 1.1 编辑 父节点数据  private void edit()
        /// </summary>
        private void edit(string ID, string editOrload)
        {
            int id = Convert.ToInt32(ID);
            if (editOrload == "load")
            {
                List<DataDictionaryEntity> list = new List<DataDictionaryEntity>();
                DataDictionaryEntity entity = DataDictionaryBLLBase.Get_DataDictionaryEntity(id);
                list.Add(entity);
                HttpContext.Current.Response.Write(Common.DataHelper.ToJson(list));
            }
            else
            {
                if (string.IsNullOrEmpty(ParentID) || string.IsNullOrEmpty(ItemCode) || string.IsNullOrEmpty(ItemName) || string.IsNullOrEmpty(IsVisible) || string.IsNullOrEmpty(Sort))
                {
                    HttpContext.Current.Response.Write("Can not be empty");
                    HttpContext.Current.Response.End();
                }                
                DataDictionaryEntity oldEntity = DataDictionaryBLLBase.Get_DataDictionaryEntity(Convert.ToInt32(ID));
                oldEntity.ParentID = Convert.ToInt32(ParentID);
                oldEntity.IsVisible =( Convert.ToInt32( IsVisible) == 1 )? true : false;
                oldEntity.ItemCode = ItemCode;
                oldEntity.ItemName = ItemName;
                oldEntity.Sort = Convert.ToInt32(Sort);
                DataDictionaryBLLBase.Create_DataDictionaryUpdate(oldEntity);
                ResetCache();
                HttpContext.Current.Response.Write("Success");
            }
        } 
        #endregion

        #region 1.2新增 父节点数据  private void add()
        /// <summary>
        /// 1.2新增 父节点数据  private void add()
        /// </summary>
        private void add()
        {
            if (string.IsNullOrEmpty(ParentID) || string.IsNullOrEmpty(ItemCode) || string.IsNullOrEmpty(ItemName) || string.IsNullOrEmpty(IsVisible) || string.IsNullOrEmpty(Sort))
            {
                HttpContext.Current.Response.Write("Can not be empty");
                HttpContext.Current.Response.End();
            }
            else
            {
                DataDictionaryEntity entity = new DataDictionaryEntity();
                entity.ParentID = Convert.ToInt32(ParentID);
                entity.IsVisible = (Convert.ToInt32(IsVisible) == 1) ? true : false;
                entity.ItemCode = ItemCode;
                entity.ItemName = ItemName;
                entity.Sort = Convert.ToInt32(Sort);
                int num = DataDictionaryBLLBase.Create_DataDictionaryInsert(entity);
                if(num>0)
                {
                    ResetCache();
                    HttpContext.Current.Response.Write("Success");
                    HttpContext.Current.Response.End();
                }
                HttpContext.Current.Response.Write("Error");
                HttpContext.Current.Response.End();
            }

        }
        #endregion

        #region  1.3 删除 父节点数据  private void del()
        /// <summary>
        /// 1.3 删除 父节点数据  private void del()
        /// </summary>
        private void del()
        {
            DataDictionaryEntity oldEntity = DataDictionaryBLLBase.Get_DataDictionaryEntity(Convert.ToInt32(id));
            oldEntity.IsVisible = false;
            DataDictionaryBLLBase.Create_DataDictionaryUpdate(oldEntity);
            ResetCache();
            HttpContext.Current.Response.Write("Success");
        }
        #endregion

        #region 2.0 根据传进来的ID 查询该父节点下面的子节点  private void loadSub()
        /// <summary>
        /// 2.0 根据传进来的ID 查询该父节点下面的子节点  private void loadSub()
        /// </summary>
        private void loadSub()
        {
            //1.0 根据传进来的ID在数据库中，查这条数据，得到parentId
            //2.0调用方法去查 子节点下面的parentID==父节点的ID
            //DataDictionaryEntity parent = DataDictionaryBLLBase.Get_DataDictionaryEntity(Convert.ToInt32(id));
            //PageData pageData = new PageData()
            //{
            //    PageIndex = Convert.ToInt32(pageIndex),
            //    PageSize = Convert.ToInt32(pageSize)
            //};
            //Common.TBToList<DataDictionaryEntity> list = new Common.TBToList<DataDictionaryEntity>();
            //pageData.rows = list.ToList(Common.DataHelper.WherePage("DataDictionary", pageData, "ParentID", Convert.ToInt32(id), "Sort"));
            Common.TBToList<DataDictionaryEntity> subList = new TBToList<DataDictionaryEntity>();
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(subList.ToList(Common.DataHelper.GetParentData("DataDictionary", "ParentID", ParentID, "Isvisible", "1", "Sort"))));
        }
        #endregion

        #region 3.0    ResetCache
        /// <summary>
        ///3.0 ResetCache
        /// </summary>
        /// 
        private void ResetCache()
        {
            //1先清空所有缓存，再重新赋值
            System.Web.Caching.Cache ca = HttpRuntime.Cache;
          IDictionaryEnumerator CacheEnum = ca.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                ca.Remove(CacheEnum.Key.ToString());
            } 
            IList<DataDictionaryEntity> parentList = DataDictionary_BLLSub.Get_DataDictionaryAllByID(0);
            IList<DataDictionaryEntity> allList = DataDictionary_BLLSub.Get_DataDictionaryAll(" IsVisible=1 order by ItemCode");
            DataCache.SetCache("DataDictionary", allList);
            for (int i = 0; i < allList.Count; i++)
            {
                string key = allList[i].ID.ToString();
                    DataCache.SetCache(key, allList[i]);
            }
            foreach (var dic in parentList)
            {
                   //将project下面的子选项加载到 Cache["Project"]对象中
                    IList<DataDictionaryEntity> subList = DataDictionary_BLLSub.Get_DataDictionaryAllByID(dic.ID);
                    DataCache.SetCache(dic.ItemName, subList);
            }
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}