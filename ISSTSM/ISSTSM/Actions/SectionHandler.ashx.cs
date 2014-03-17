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
    /// SectionHandler 的摘要说明
    /// </summary>
    public class SectionHandler : IHttpHandler
    {
        string type = "";
        string id = "";
        string pageIndex;
        string pageSize;
        string ParentID;
        string SectionName;
        string SectionCode;
        string Description;
        string Sort;
        string editOrload;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentType = "text/plain";
            type = context.Request.Params["t"];
            id = context.Request.Params["id"];
            pageIndex = context.Request.Params["page"];
            pageSize = context.Request.Params["rows"];
            ParentID = context.Request.Params["ParentID"];
            SectionName = context.Request.Params["SectionName"];
            SectionCode = context.Request.Params["SectionCode"];
            Description = context.Request.Params["Description"];
            Sort = context.Request.Params["Sort"];
            editOrload = context.Request.Params["editOrload"];
            switch (type)
            {
                case "load":
                    Load();
                    break;
                case "loadSub":
                    LoadSub();
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
                default:
                    break;
            }
        }



        #region 1.0 加载Section的父级节点的数据   private void Load()
        /// <summary>
        /// 加载Section的父级节点的数据
        /// </summary>
        private void Load()
        {
            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<SectionEntity> list = new Common.TBToList<SectionEntity>();
            pageData.rows = list.ToList(Common.DataHelper.WherePage("Section", pageData, "ParentID", Convert.ToInt32(ParentID), "", "Sort"));
            //pageData.permission = Permission_BLLSub.GetPermissionByUserID(1, 2);
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));
        } 
        #endregion

        #region 1.1 加载Section的子节点数据  private void LoadSub()
        /// <summary>
        /// 加载Section的子节点数据  private void LoadSub()
        /// </summary>
        private void LoadSub()
        {
            Common.TBToList<SectionEntity> subList = new TBToList<SectionEntity>();
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(subList.ToList(Common.DataHelper.GetParentData("Section", "ParentID", ParentID, "", "", "Sort"))));
        } 
        #endregion

        #region 2.0 新增Section的数据 private void add()
        /// <summary>
        ///  2.0 新增Section的数据 private void add()
        /// </summary>
        private void add()
        {
            if (string.IsNullOrEmpty(ParentID) || string.IsNullOrEmpty(SectionName) || string.IsNullOrEmpty(SectionCode) || string.IsNullOrEmpty(Sort))
            {
                HttpContext.Current.Response.Write("Can not be empty");
                HttpContext.Current.Response.End();
            }
            else
            {
                SectionEntity entity = new SectionEntity();
                entity.ParentID = Convert.ToInt32(ParentID);
                entity.SectionCode = SectionCode;
                entity.SectionName = SectionName;
                entity.Description = Description;
                entity.Sort = Convert.ToInt32(Sort);
                int num = SectionBLLBase.Create_SectionInsert(entity);
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

        #region 3.0 编辑Section的数据  private void edit()
        /// <summary>
        /// 3.0 编辑Section的数据  private void edit()
        /// </summary>
        private void edit()
        {
            if (editOrload == "load")
            {
                List<SectionEntity> list = new List<SectionEntity>();
                SectionEntity entity = SectionBLLBase.Get_SectionEntity(Convert.ToInt32(id));
                list.Add(entity);
                HttpContext.Current.Response.Write(Common.DataHelper.ToJson(list));
            }
            else
            {
                if (string.IsNullOrEmpty(ParentID) || string.IsNullOrEmpty(SectionName) || string.IsNullOrEmpty(SectionCode) || string.IsNullOrEmpty(Sort))
                {
                    HttpContext.Current.Response.Write("Can not be empty");
                    HttpContext.Current.Response.End();
                }
                else
                {
                    SectionEntity entity = SectionBLLBase.Get_SectionEntity(Convert.ToInt32(id));
                    entity.ParentID = Convert.ToInt32(ParentID);
                    entity.SectionCode = SectionCode;
                    entity.SectionName = SectionName;
                    entity.Description = Description;
                    entity.Sort =Convert.ToInt32(Sort);
                    SectionBLLBase.Create_SectionUpdate(entity);
                    HttpContext.Current.Response.Write("Success");
                    HttpContext.Current.Response.End();
                }
            }
        }
        #endregion

        #region 4.0 删除Section的数据  private void del()
        /// <summary>
        /// 4.0 删除Section的数据
        /// </summary>
        private void del()
        {
            SectionBLLBase.Create_SectionDelete(Convert.ToInt32(id));
            HttpContext.Current.Response.Write("Success");
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