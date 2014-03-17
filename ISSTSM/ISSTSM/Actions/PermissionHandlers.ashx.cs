using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Actions
{
    using Entity;
    using BusinessLogicLayer;
    using Common;
    /// <summary>
    /// Summary description for PermissionHandlers
    /// </summary>
    public class PermissionHandlers : IHttpHandler
    {
        public string id = "";
        public int sort = 0;
        public bool isVisible = true;
        public bool isButton = true;
        public string permissionName = "";
        public string permissionCode = "";
        public string icon = "";
        public string description = "";
        public string pageIndex;
        public string pageSize;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            string result = string.Empty;
            pageIndex=context.Request.Params["page"];
            pageSize=context.Request.Params["rows"];
            switch (action)
            {
                case "load":
                    load(pageIndex,pageSize);
                    break;
                case "loadAll":
                    loadAll();
                    break;
                case "save":
                    save(context);
                    break;
                case "delete":
                    delete(context);
                    break;
            }
        }

        private void load(string pageIndex,string pageSize)
        {
            TBToList<PermissionEntity> list = new TBToList<PermissionEntity>();
            PageData pagedata = new PageData()
            {
                PageIndex=Convert.ToInt32( pageIndex),
                PageSize=Convert.ToInt32( pageSize)
            };
            pagedata.rows = list.ToList(DataHelper.WherePage("Permission",pagedata,"sort"));
            HttpContext.Current.Response.Write(DataHelper.ToJson(pagedata));
        }
        /// <summary>
        /// 加载所有权限
        /// </summary>
        private void loadAll()
        { 
            IList<PermissionEntity> list;
            list=PermissionBLLBase.Get_PermissionAll(); 
            HttpContext.Current.Response.Write(DataHelper.ToJson(list));
        }
        //add or update
        private void save(HttpContext context)
        {
            id = context.Request.Params["ID"];
            //string _sort = context.Request.Params["Sort"];//default 0
            string isVisible = context.Request.Params["IsVisible"];
            string isButton = context.Request.Params["IsButton"];
            permissionName = context.Request.Params["PermissionName"];
            permissionCode = context.Request.Params["PermissionCode"];
            icon = context.Request.Params["Icon"];
            description = context.Request.Params["Description"];

            PermissionEntity entity = new PermissionEntity();
            entity.Description = description;
            entity.Sort = sort;
            entity.Icon = icon;
            entity.IsButton = bool.Parse(isButton);
            entity.IsVisible = bool.Parse(isVisible);
            entity.PermissionCode = permissionCode;
            entity.PermissionName = permissionName;

            if (string.IsNullOrEmpty(id))
            {
                //add
                if (string.IsNullOrEmpty(permissionCode) || string.IsNullOrEmpty(permissionName) || string.IsNullOrEmpty(icon) || string.IsNullOrEmpty(icon))
                {
                    Write(Kits.GetStrForJson(new JsonNode() { status = -1, stateStr = "some thing must fill" }));
                }
                else
                {
                    PermissionBLLBase.Create_PermissionInsert(entity);
                }
            }
            else
            {
                //update
                entity.ID = Convert.ToInt32(id);
                PermissionBLLBase.Create_PermissionUpdate(entity);
            }
        }

        private void delete(HttpContext context)
        {
            id = context.Request.Params["ID"];
            if (id != null)
            {
                PermissionBLLBase.Create_PermissionDelete(int.Parse(id));
            }
            else
            {
                Write(Kits.GetStrForJson(new JsonNode() { status = -1, stateStr = "error" }));
            }
        }

        /// <summary>
        /// 写入response.write方法
        /// </summary>
        /// <param name="msg"></param>
        void Write(string msg)
        {
            HttpContext.Current.Response.Write(msg);
            HttpContext.Current.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}