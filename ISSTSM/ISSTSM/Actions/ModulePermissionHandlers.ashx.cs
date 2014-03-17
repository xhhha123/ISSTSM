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
    /// Summary description for ModulePermissionHandlers
    /// </summary>
    public class ModulePermissionHandlers : IHttpHandler
    {
        //表数据
        public int id;
        public int moduleID;
        public int permissionID;
        public int creatUserID;
        public bool isDeleted;
        //前台接收数据
        public string _id;
        public string _moduleID;
        public string _permissionID;
        public string _isDeleted;
        public string perIdDels;
        public string perIdAdds;
        public IList<PermissionEntity> listP;

        public ModuleBLLBase module = new ModuleBLLBase();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            #region
            //初始化前台可能传过来的参数
            string action = context.Request.Params["action"];
            _id = HttpContext.Current.Request.Params["ID"];
            _moduleID = HttpContext.Current.Request.Params["ModuleID"];
            _permissionID = HttpContext.Current.Request.Params["PermissionID"];

            //权限操作
            perIdAdds = HttpContext.Current.Request.Params["PerIdAdds"];
            perIdDels = HttpContext.Current.Request.Params["PerIdDels"];

            #endregion

            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "loadByModID":
                        loadByModID();
                        break;
                    case "save":
                        save();
                        break;
                }


            }
        }

        #region
        /// <summary>
        /// load child node by parentID
        /// </summary>
        /// <param name="id"></param>
        public void loadByModID()
        {
            if (!string.IsNullOrEmpty(_moduleID))
            {
                moduleID = Convert.ToInt32(_moduleID);
                listP = new ModulePermission_BLLSub().Get_ModPerByModID(moduleID);
                HttpContext.Current.Response.Write(DataHelper.ToJson(listP));
            }
        }
        #endregion

        #region
        /// <summary>
        /// save
        /// </summary>
        public void save()
        {
            if (!string.IsNullOrEmpty(_moduleID))
            {

                moduleID = Convert.ToInt32(_moduleID);
                //遍历添加
                if (!string.IsNullOrEmpty(perIdAdds))
                {
                    string[] pIds = perIdAdds.Split(',');
                    int id;
                    int length = pIds.Length;
                    for (int i = 0; i < length - 1; i++)
                    {
                        id = Convert.ToInt32(pIds[i]);
                        this.add(moduleID, id);
                    }
                }
                //遍历删除
                if (!string.IsNullOrEmpty(perIdDels))
                {
                    string[] pIds = perIdDels.Split(',');
                    int id;
                    int length = pIds.Length;
                    for (int i = 0; i < length - 1; i++)
                    {
                        id = Convert.ToInt32(pIds[i]);
                        this.del(moduleID, id);
                    }
                }
            }
        }
        #endregion

        #region
        /// <summary>
        /// add by ModuleID,PermissionID
        /// </summary>
        /// <param name="id"></param>
        public void add(int modID, int perID)
        {
            ModulePermissionEntity entity = new ModulePermissionEntity();
            entity.ModuleID = modID;
            entity.PermissionID = perID;
            DateTime creatTime = DateTime.Now;
            entity.CreateDate = creatTime;
            entity.IsDeleted = false;
            entity.CreateUserID = 1;
            ModulePermissionBLLBase.Create_ModulePermissionInsert(entity);
        }
        #endregion

        #region
        /// <summary>
        /// delete by ModuleID,PermissionID
        /// </summary>
        /// <param name="id"></param>
        public void del(int Mid, int Pid)
        {
            new ModulePermission_BLLSub().Del_MPByMidPid(Mid, Pid);
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