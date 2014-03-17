using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Actions
{
    using Entity;
    using BusinessLogicLayer;
    using Common;
    using ISSTSM.Entity.EasyUIEntity;
    /// <summary>
    /// Summary description for ModuleHandlers
    /// </summary>
    public class ModuleHandlers : IHttpHandler
    {
        public int id;
        public string parentID;
        public string moduleName;
        public string moduleUrl;
        public string icon;
        public int sort;
        public bool isVisible;
        public bool isMenu;
        public bool isDeleted;

        public string _id;
        public string _sort;
        public string _isVisible;
        public string _isMenu;
        public string _isDeleted;

        public string pageIndex;
        public string pageSize;

        public ModuleBLLBase module = new ModuleBLLBase();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            #region
            //初始化前台可能传过来的参数
            string action = context.Request.Params["action"];
            pageIndex = HttpContext.Current.Request.Params["page"];
            pageSize = HttpContext.Current.Request.Params["rows"];

            _id = HttpContext.Current.Request.Params["ID"];
            parentID = HttpContext.Current.Request.Params["parentID"];
            moduleName = HttpContext.Current.Request.Params["ModuleName"];
            moduleUrl = HttpContext.Current.Request.Params["ModuleUrl"];
            icon = HttpContext.Current.Request.Params["Icon"];
            _sort = HttpContext.Current.Request.Params["Sort"];
            _isVisible = HttpContext.Current.Request.Params["IsVisible"];
            _isMenu = HttpContext.Current.Request.Params["IsMenu"];
            _isDeleted = HttpContext.Current.Request.Params["IsDeleted"];
            #endregion

            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "load":
                        load(pageIndex, pageSize);
                        break;
                    case "loadByParentID":
                        loadByParentID();
                        break;
                    case "save":
                        save();
                        break;
                    case "del":
                        deleteByID();
                        break;
                }


            }
        }

        #region
        /// <summary>
        /// default to load super node --parentID==1
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public void load(string pageIndex, string pageSize)
        {
            TBToList<ModuleEntity> list = new TBToList<ModuleEntity>();
            PageData pagedata = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            pagedata.rows = list.ToList(DataHelper.WherePage("Module", pagedata, "ParentID", 1, "sort"));
            HttpContext.Current.Response.Write(DataHelper.ToJson(pagedata));
        }
        #endregion

        #region
        /// <summary>
        /// load child node by parentID
        /// </summary>
        /// <param name="id"></param>
        public void loadByParentID()
        {
            if (!string.IsNullOrEmpty(parentID))
            {
                int id = Convert.ToInt32(parentID);
                TBToList<ModuleEntity> toList = new TBToList<ModuleEntity>();
                IList<ModuleEntity> list = toList.ToList(DataHelper.GetParentData("Module", "ParentID", parentID, "", "", "sort"));
                HttpContext.Current.Response.Write(DataHelper.ToJson(list));
            }
        }
        #endregion

        #region
        /// <summary>
        /// save or update the change
        /// </summary>
        public void save()
        {
            ModuleEntity entity = new ModuleEntity();
            entity.ModuleName = moduleName;
            entity.ModuleUrl = moduleUrl;
            entity.Icon = icon;
            entity.ParentID = parentID;
            if (!string.IsNullOrEmpty(_sort) && !string.IsNullOrEmpty(_isDeleted) && !string.IsNullOrEmpty(_isMenu) && !string.IsNullOrEmpty(_isVisible))
            {
                entity.Sort = Convert.ToInt32(_sort);
                entity.IsDeleted = Convert.ToBoolean(_isDeleted);
                entity.IsMenu = Convert.ToBoolean(_isMenu);
                entity.IsVisible = Convert.ToBoolean(_isVisible);
                if (!string.IsNullOrEmpty(_id))
                {
                    entity.ID = Convert.ToInt32(_id);
                    ModuleBLLBase.Create_ModuleUpdate(entity);
                }
                else
                {
                    ModuleBLLBase.Create_ModuleInsert(entity);
                }

            }

        }
        #endregion

        #region
        /// <summary>
        /// delete by id
        /// </summary>
        /// <param name="id"></param>
        public void deleteByID()
        {
            if (!string.IsNullOrEmpty(_id))
            {
                ModuleEntity entity = new ModuleEntity();
                int id = Convert.ToInt32(_id);
                entity.ID = id;
                entity.IsVisible = false;
                IList<ModuleEntity> list = Module_BLLSub.Get_ModuleAllByParentID(id);
                if (list.Count == 0)
                {
                    ModuleBLLBase.Create_ModuleUpdate(entity);
                }
                else
                {
                    HttpContext.Current.Response.Write("Please delete the sub module before!");
                }
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