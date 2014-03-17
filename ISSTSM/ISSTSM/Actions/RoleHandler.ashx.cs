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
    /// <summary>
    /// RoleHandler 的摘要说明
    /// </summary>
    public class RoleHandler : IHttpHandler
    {
        string type = "";
        string id = "";
        string roleId = "";
        string pageIndex;
        string pageSize;
        string RoleName;
        string CreateUserID;
        string CreateDate;
        string Sort;
        string Description;
        string editOrload;
        string MolOrPer;
        string ModuleId;
        string perIdAdds;
        string perIdDels;

        string molIdAdds;
        string molIdDels;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            type = context.Request.Params["t"];
            id = context.Request.Params["id"];
            roleId = context.Request.Params["roleId"];
            pageIndex = context.Request.Params["page"];
            pageSize = context.Request.Params["rows"];
            RoleName = context.Request.Params["RoleName"];
            CreateUserID = context.Request.Params["CreateUserID"];
            CreateDate = context.Request.Params["CreateDate"];
            Sort = context.Request.Params["Sort"];
            Description = context.Request.Params["Description"];
            editOrload = context.Request.Params["editOrload"];
            MolOrPer = context.Request.Params["MolOrPer"];
            ModuleId = context.Request.Params["ModuleId"];
            //权限操作
            perIdAdds = context.Request.Params["PerIdAdds"];
            perIdDels = context.Request.Params["PerIdDels"];
            //模块操作
            molIdAdds = context.Request.Params["molIdAdds"];
            molIdDels = context.Request.Params["molIdDels"];
            switch (type)
            {
                case "load":
                    Load();
                    break;
                case "edit":
                    edit();
                    break;
                case "del":
                    del();
                    break;
                case "add":
                    add();
                    break;
                case "loadMolPer":
                    LoadMolPer();
                    break;
                case "OptMolPer":
                    OptMolPer();
                    break;
                case "OptRMP":
                    OptRMP();
                    break;
                default:
                    break;
            }
        }
        

        #region  1.0 加载Role里面的所有数据 private void Load()
        /// <summary>
        /// 1.0 加载Role里面的所有数据 private void Load()
        /// </summary>
        private void Load()
        {
            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<RoleEntity> list = new TBToList<RoleEntity>();
            pageData.rows = list.ToList(Common.DataHelper.WherePage("Role", pageData, "IsDeleted", 0,"", "Sort"));
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));
        } 
        #endregion

        #region 2.0 新增Role   private void add()
        /// <summary>
        /// 2.0 新增Role 
        /// </summary>
        private void add()
        {
            if (string.IsNullOrEmpty(RoleName) || string.IsNullOrEmpty(CreateUserID) || string.IsNullOrEmpty(Sort))
            {
                HttpContext.Current.Response.Write("Can not be empty");
                HttpContext.Current.Response.End();
            }
            else
            {
                RoleEntity entity = new RoleEntity();
                entity.CreateDate = Convert.ToDateTime(CreateDate);
                entity.CreateUserID = Convert.ToInt32(CreateUserID);
                entity.Description = Description;
                entity.IsDeleted = false;
                entity.RoleName = RoleName;
                if (!string.IsNullOrEmpty(Sort))
                {
                    entity.Sort = Convert.ToInt32(Sort);
                }
                int num = RoleBLLBase.Create_RoleInsert(entity);
                if (num > 0)
                {
                    HttpContext.Current.Response.Write("Success");
                    HttpContext.Current.Response.End();
                }
                HttpContext.Current.Response.Write("Error");
                HttpContext.Current.Response.End();
            }
        } 
        #endregion

        #region 3.0 编辑Role private void edit()
        /// <summary>
        /// 3.0 编辑Role private void edit()
        /// </summary>
        private void edit()
        {
            if (editOrload == "load")
            {
                List<RoleEntity> list = new List<RoleEntity>();
                RoleEntity entity = RoleBLLBase.Get_RoleEntity(Convert.ToInt32(id));
                list.Add(entity);
                HttpContext.Current.Response.Write(Common.DataHelper.ToJson(list));
            }
            else
            {
                if (string.IsNullOrEmpty(RoleName) || string.IsNullOrEmpty(CreateUserID) || string.IsNullOrEmpty(Sort))
                {
                    HttpContext.Current.Response.Write("Can not be empty");
                    HttpContext.Current.Response.End();
                }
                else
                {
                    RoleEntity editEntity = RoleBLLBase.Get_RoleEntity(Convert.ToInt32(id));
                    editEntity.CreateDate = Convert.ToDateTime(CreateDate);
                    editEntity.CreateUserID = Convert.ToInt32(CreateUserID);
                    editEntity.Description = Description;
                    editEntity.IsDeleted = false;
                    editEntity.RoleName = RoleName;
                    if (!string.IsNullOrEmpty(Sort))
                    {
                        editEntity.Sort = Convert.ToInt32(Sort);
                    }
                    RoleBLLBase.Create_RoleUpdate(editEntity);
                    HttpContext.Current.Response.Write("Success");
                }
            }
        } 
        #endregion

        #region  4.0 软删除 Role private void del()
        /// <summary>
        /// 4.0 软删除 Role
        /// </summary>
        private void del()
        {
            RoleEntity oldEntity = RoleBLLBase.Get_RoleEntity(Convert.ToInt32(id));
            oldEntity.IsDeleted = true;
            RoleBLLBase.Create_RoleUpdate(oldEntity);
            HttpContext.Current.Response.Write("Success");
        } 
        #endregion

        #region 5.0 加载 Moduel 或者Permission表的所有数据 private void LoadMolPer()
        /// <summary>
        /// 5.0 加载 Moduel 或者Permission表的所有数据 private void LoadMolPer()
        /// </summary>
        private void LoadMolPer()
        {
           
            if (MolOrPer == "Mol")
            {
                PageData pageData = new PageData()
                {
                    PageIndex = 1,
                    PageSize =10000
                };
                Common.TBToList<ModuleEntity> temp = new Common.TBToList<ModuleEntity>();
                //所有的模块
                IList<ModuleEntity> totalList = temp.ToList(Common.DataHelper.WherePage("Module", pageData, "IsVisible", 1, "and ParentID>1", "Sort"));
                //根据Role.ID下面的模块
                IList<ModuleEntity> actList = temp.ToList(Common.DataHelper.GetModuleData(Convert.ToInt32(id)));
                //遍历actList,与totalList进行比较，如果存在，则在totalList的IsDelete赋值为1，作为chechbox勾选的标示，返回前台
                pageData.rows = MarkModule(totalList, actList);
                //pageData.rows = totalList.ToList(Common.DataHelper.WherePage("Module", pageData, "Sort"));
                HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData.rows));
                HttpContext.Current.Response.End();
            }
            if (MolOrPer == "SubMol")
                {
                    Common.TBToList<ModuleEntity> temp = new Common.TBToList<ModuleEntity>();
                    IList<ModuleEntity> actList = temp.ToList(Common.DataHelper.GetModuleData(Convert.ToInt32(id)));
                    HttpContext.Current.Response.Write(Common.DataHelper.ToJson(actList));
                    HttpContext.Current.Response.End();
                }
            else
            {

                //根据Role.ID以及Module.ID获取下面的permission
                Common.TBToList<PermissionEntity> temp = new Common.TBToList<PermissionEntity>();
                //根据传进来的Role.ID以及Module.ID得到AllPermission，然后再在根据其中是否是删除，返回给CheckBox
                IList<PermissionEntity> totalList = temp.ToList(Common.DataHelper.GetPermissData(Convert.ToInt32(id), Convert.ToInt32(ModuleId)));
                //根据中间表 ModulePermission.IsDeleted=false 得到所有的权限
                IList<PermissionEntity> actList = temp.ToList(Common.DataHelper.GetCurPermissData(Convert.ToInt32(id), Convert.ToInt32(ModuleId)));
                HttpContext.Current.Response.Write(Common.DataHelper.ToJson(MarkPermission(totalList, actList)));
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region  5.1 Module的IsDelete赋值为1 IList<ModuleEntity> MarkModule(IList<ModuleEntity> totalList, IList<ModuleEntity> actList)
        /// <summary>
        /// 5.1 Module的IsDelete赋值为1，作为chechbox勾选的标示
        /// </summary>
        /// <param name="totalList"></param>
        /// <param name="actList"></param>
        /// <returns></returns>
        public IList<ModuleEntity> MarkModule(IList<ModuleEntity> totalList, IList<ModuleEntity> actList)
        {
            foreach (var mol in totalList)
            {
                foreach (var act in actList)
                {
                    if(mol.ID==act.ID)
                    {
                        mol.IsDeleted = true;//chechbox勾选的标示
                    }
                }
            }
            return totalList;
        } 
        #endregion

        #region  5.2 public IList<PermissionEntity> MarkPermission(IList<PermissionEntity> totalList, IList<PermissionEntity> actList)
        /// <summary>
        /// 5.1 PermissionEntity的IsButton赋值为false，作为chechbox勾选的标示
        /// </summary>
        /// <param name="totalList"></param>
        /// <param name="actList"></param>
        /// <returns></returns>
        public IList<PermissionEntity> MarkPermission(IList<PermissionEntity> totalList, IList<PermissionEntity> actList)
        {
            foreach (var mol in totalList)
            {
                foreach (var act in actList)
                {
                    if (mol.ID == act.ID)
                    {
                        mol.IsButton = false;//chechbox勾选的标示
                    }
                }
            }
            return totalList;
        }
        #endregion

        #region  6.0 对ModulePermissioin的表进行操作 private void OptMolPer()
        /// <summary>
        /// 6.0 对ModulePermissioin的表进行操作 private void OptMolPer()
        /// </summary>
        private void OptMolPer()
        {
            if (!string.IsNullOrEmpty(ModuleId))
            {
                ModulePermissionEntity entity = null;
                RoleModulePermissionEntity RMPentity = null;
                //遍历添加--将Isdelete改为false
                if (!string.IsNullOrEmpty(perIdAdds))
                {
                    string[] pIds = perIdAdds.Split(',');
                    int id;
                    int length = pIds.Length;
                    //下面是操作 RoleModulePermission
                    int RoleID = Convert.ToInt32(roleId);
                    IList<ModulePermissionEntity> list = ModulePermission_BLLSub.GetAllByModID(" where ModuleID= " + Convert.ToInt32(ModuleId));
                    for (int i = 0; i < length - 1; i++)
                    {
                        id = Convert.ToInt32(pIds[i]);
                         entity = ModulePermission_BLLSub.Get_ModulePermissionEntity(Convert.ToInt32(ModuleId), id);
                        entity.IsDeleted = false;
                        ModulePermissionBLLBase.Create_ModulePermissionUpdate(entity);
                        foreach (var mp in list)
                        {
                            if (mp.PermissionID == id)
                            {
                                RMPentity = new RoleModulePermissionEntity();
                                RMPentity.RoleID = RoleID;
                                RMPentity.ModulePermissionID = mp.ID;
                                RMPentity.CreateUserID = 1;
                                RMPentity.CreateDate = DateTime.Now;
                                RoleModulePermissionBLLBase.Create_RoleModulePermissionInsert(RMPentity);
                            }
                        }
                    }
                }
                //遍历软删除 --将Isdelete改为true，
                //同时还要操作RoleModulePermission，根据mp.PermissionID == id将其对应的删除
                if (!string.IsNullOrEmpty(perIdDels))
                {
                    string[] pIds = perIdDels.Split(',');
                    int id;
                    int length = pIds.Length;
                    //下面是操作 RoleModulePermission
                    int RoleID = Convert.ToInt32(roleId);
                    IList<ModulePermissionEntity> list = ModulePermission_BLLSub.GetAllByModID(" where ModuleID= " + Convert.ToInt32(ModuleId));
                    for (int i = 0; i < length - 1; i++)
                    {
                        id = Convert.ToInt32(pIds[i]);
                        entity = ModulePermission_BLLSub.Get_ModulePermissionEntity(Convert.ToInt32(ModuleId), id);
                        entity.IsDeleted = true;
                        ModulePermissionBLLBase.Create_ModulePermissionUpdate(entity);
                        foreach (var mp in list)
                        {
                            if (mp.PermissionID == id)
                            {
                                RoleModulePermission_BLLSub.Create_RoleModulePermissionDelete(RoleID, mp.ID);
                            }
                        }
                    }

                }
                HttpContext.Current.Response.Write("Success");
            }

        }
        #endregion

        #region  6.1 对RoleModulePermission等中间表进行 增加，删除的操作  void OptRMP()
        /// <summary>
        /// 6.1 对RoleModulePermission等中间表进行 增加，删除的操作  void OptRMP()
        /// </summary>
        private void OptRMP()
        {
            //1.传入的是Role.ID 以及 molIdAdds;   molIdDels;
            //2.先做批量增加，主要操作的是RoleModulePermission表，插入Role.ID,
            //2.1根据molID去查ModulePermission对应的ID，然后插入到RoleModulePermission里面
            if (!string.IsNullOrEmpty(id))
            {
                IList<ModulePermissionEntity> list = null;
                RoleModulePermissionEntity entity = null;
                int RoleID=Convert.ToInt32(id);
                if(!string.IsNullOrEmpty(molIdAdds))
                {
                    string[] mIds = molIdAdds.Split(',');
                    int mid;
                    int length = mIds.Length;
                    for (int i = 0; i < length - 1; i++)
                    {
                        mid = Convert.ToInt32(mIds[i]);
                        list = ModulePermission_BLLSub.GetAllByModID(" where ModuleID= "+mid);
                        foreach (var mp in list)
                        {
                            entity = new RoleModulePermissionEntity();
                            entity.RoleID = RoleID;
                            entity.ModulePermissionID = mp.ID;
                            entity.CreateUserID = 1;
                            entity.CreateDate = DateTime.Now;
                            RoleModulePermissionBLLBase.Create_RoleModulePermissionInsert(entity);
                        }
                    }
                }

                if(!string.IsNullOrEmpty(molIdDels))
                {
                    string[] mIds = molIdDels.Split(',');
                    int mid;
                    int length = mIds.Length;
                    for (int i = 0; i < length - 1; i++)
                    {
                        mid = Convert.ToInt32(mIds[i]);
                        list = ModulePermission_BLLSub.GetAllByModID(" where ModuleID= " + mid);
                        foreach (var mp in list)
                        {
                            RoleModulePermission_BLLSub.Create_RoleModulePermissionDelete(RoleID,mp.ID);
                        }
                    }
                }
                HttpContext.Current.Response.Write("Success");

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