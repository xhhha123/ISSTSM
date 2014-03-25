using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISSTSM.Enity;
namespace ISSTSM.Actions
{
    using ISSTSM.BusinessLogicLayer;
    using ISSTSM.Common;
    using ISSTSM.DALFactory;
    using ISSTSM.Entity;
    /// <summary>
    /// Summary description for IncHandlers
    /// </summary>
    public class IncHandlers : IHttpHandler
    {
        //前台传过来的数据
        string view;//定义有三种，一个是admin ,一个是staff
        string type;//定义对数据进行的操作
        string id;
        string userID;
        string pageIndex;
        string pageSize;
        string IncidentNumber;
        string AssignedTo;
        string ReportedBy;
        string DicPriority;
        string DicCountry;
        string DicProduct;
        string DicStatus;
        string CreateDate;
        string StatusFollowUp;
        string Summary;
        string Description;
        string editOrload;
        string dateBefore;
        string dateAfter;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            id = context.Request.Params["id"];
            userID = context.Request.Params["userID"];
            view = context.Request.Params["view"];
            type = context.Request.Params["t"];
            pageIndex = context.Request.Params["page"];
            pageSize = context.Request.Params["rows"];
            IncidentNumber = context.Request.Params["IncidentNumber"];
            AssignedTo = context.Request.Params["AssignedTo"];
            ReportedBy = context.Request.Params["ReportedBy"];
            DicPriority = context.Request.Params["Priority"];
            DicCountry = context.Request.Params["Country"];
            DicProduct = context.Request.Params["Product"];
            DicStatus = context.Request.Params["Status"];
            CreateDate = context.Request.Params["CreateDate"];
            StatusFollowUp = context.Request.Params["StatusFollowUp"];
            Summary = context.Request.Params["Summary"];
            Description = context.Request.Params["Description"];
            editOrload = context.Request.Params["editOrload"];
            dateBefore = context.Request.Params["dateBefore"];
            dateAfter = context.Request.Params["dateAfter"];

            pageSize = context.Request.Params["rows"];
            pageSize = context.Request.Params["rows"];
            switch (view)
            {
                case "admin":
                    Admin();
                    break;
                case "staff":
                    Staff();
                    break;
                default:
                    break;
            }
        }

        private void Admin()
        {
            switch (type)
            {
                case "loadAdmin":
                    LoadAdmin();
                    break;
                case "addAdmin":
                    AddAdmin();
                    break;
                case "editAdmin":
                    EditAdmin();
                    break;
                case "delAdmin":
                    DelAdmin();
                    break;
                case "loadAdmin,search":
                    Search();
                    break;
                default:
                    break;
            }
        }

        private void Search()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            //查询判断
            if (!string.IsNullOrEmpty(IncidentNumber))
            {
                fields.Add("IncidentNumber",IncidentNumber);
            }
            //日期不为空的话，就拼接查询字符串
            if (!string.IsNullOrEmpty(dateBefore)&&!string.IsNullOrEmpty(dateAfter))
            {
                fields.Add("dateBefore", dateBefore);
                fields.Add("dateAfter", dateAfter);
            }
            string strPageIndex = HttpContext.Current.Request.Params["page"];
            string strPageSize = HttpContext.Current.Request.Params["rows"];
            //转换成json数据格式
            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<IncidentEntity> temp = new Common.TBToList<IncidentEntity>();
            IList<IncidentEntity> list = temp.ToList(Common.DataHelper.SearchData("Incident", pageData, "CreateDate",fields));
            List<IncidentUIEntity> uiList = new List<IncidentUIEntity>();
            //Stopwatch stw = new Stopwatch();
            //stw.Start();
            DataDictionaryEntity dic = null;
            UserInfoEntity user = null;
            foreach (var item in list)
            {
                IncidentUIEntity entity = new IncidentUIEntity();
                entity.ID = item.ID;
                entity.IncidentNumber = item.IncidentNumber;
                entity.CreateDate = item.CreateDate;
                entity.Summary = item.Summary;
                entity.StatusFollowUp = item.StatusFollowUp;
                entity.Description = item.Description;
                //UI显示转换
                user = UserInfoBLLBase.Get_UserInfoEntity(item.AssignedTo);
                entity.AssignedToName = user.UserName;
                user = UserInfoBLLBase.Get_UserInfoEntity(item.ReportedBy);
                entity.ReportedByName = user.UserName;
                //从缓存中拿数据 127ms
                dic = DataCache.GetCache(item.DicPriority.ToString()) as DataDictionaryEntity;
                entity.DicPriotityName = dic.ItemName;
                dic = DataCache.GetCache(item.DicCountry.ToString()) as DataDictionaryEntity;
                entity.DicCountryName = dic.ItemName;
                dic = DataCache.GetCache(item.DicProduct.ToString()) as DataDictionaryEntity;
                entity.DicProductName = dic.ItemName;
                dic = DataCache.GetCache(item.DicStatus.ToString()) as DataDictionaryEntity;
                entity.DicStatusName = dic.ItemName;
                uiList.Add(entity);
            }
            //stw.Stop();
            //string time = stw.ElapsedMilliseconds.ToString();
            pageData.rows = uiList;
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));

        }

        private void DelAdmin()
        {
            IncidentBLLBase.Create_IncidentDelete(Convert.ToInt32(id));
            HttpContext.Current.Response.Write("Success");
            HttpContext.Current.Response.End();
        }

        private void EditAdmin()
        {
            if (editOrload == "load")
            {
                IncidentEntity entity = IncidentBLLBase.Get_IncidentEntity(Convert.ToInt32(id));
                List<IncidentEntity> list = new List<IncidentEntity>();
                list.Add(entity);
                HttpContext.Current.Response.Write(Common.DataHelper.ToJson(list));
            }
            else
            {
                if (string.IsNullOrEmpty(IncidentNumber) ||
    string.IsNullOrEmpty(AssignedTo) ||
    string.IsNullOrEmpty(DicPriority) ||
    string.IsNullOrEmpty(DicCountry) ||
    string.IsNullOrEmpty(DicProduct) ||
    string.IsNullOrEmpty(DicStatus) ||
    string.IsNullOrEmpty(CreateDate))
                {
                    HttpContext.Current.Response.Write("Can not be empty");
                    HttpContext.Current.Response.End();
                }
                IncidentEntity entity = IncidentBLLBase.Get_IncidentEntity(Convert.ToInt32(id));
                entity.IncidentNumber = IncidentNumber;
                entity.AssignedTo = Convert.ToInt32(AssignedTo);
                entity.ReportedBy = Convert.ToInt32(ReportedBy);
                entity.DicPriority = Convert.ToInt32(DicPriority);
                entity.DicCountry = Convert.ToInt32(DicCountry);
                entity.DicProduct = Convert.ToInt32(DicProduct);
                entity.DicStatus = Convert.ToInt32(DicStatus);
                entity.CreateDate = DateTime.Parse(CreateDate);
                entity.StatusFollowUp = StatusFollowUp;
                entity.Summary = Summary;
                entity.Description = Description;
                IncidentBLLBase.Create_IncidentUpdate(entity);
                HttpContext.Current.Response.Write("Success");
                HttpContext.Current.Response.End();
            }
        }

        private void AddAdmin()
        {
            if (string.IsNullOrEmpty(IncidentNumber) ||
                string.IsNullOrEmpty(AssignedTo) ||
                string.IsNullOrEmpty(DicPriority) ||
                string.IsNullOrEmpty(DicCountry) ||
                string.IsNullOrEmpty(DicProduct) ||
                string.IsNullOrEmpty(DicStatus) ||
                string.IsNullOrEmpty(CreateDate))
            {
                HttpContext.Current.Response.Write("Can not be empty");
                HttpContext.Current.Response.End();
            }
                IList<IncidentEntity> list = Incident_BLLSub.Get_IncidentAllByWhere("IncidentNumber=" + "'"+IncidentNumber+"'");
                if(list.Count>0)
                {
                    HttpContext.Current.Response.Write("IncidentNumber is existed");
                    HttpContext.Current.Response.End();
                }
                IncidentEntity entity = new IncidentEntity();
                entity.IncidentNumber = IncidentNumber;
                entity.AssignedTo = Convert.ToInt32(AssignedTo);
                entity.ReportedBy = Convert.ToInt32(ReportedBy);
                entity.DicPriority = Convert.ToInt32(DicPriority);
                entity.DicCountry = Convert.ToInt32(DicCountry);
                entity.DicProduct = Convert.ToInt32(DicProduct);
                entity.DicStatus = Convert.ToInt32(DicStatus);
                entity.CreateDate = DateTime.Parse(CreateDate);
                entity.StatusFollowUp = StatusFollowUp;
                entity.Summary = Summary;
                entity.Description = Description;
                entity.IsFill = 0;
                IncidentBLLBase.Create_IncidentInsert(entity);
                HttpContext.Current.Response.Write("Success");
                HttpContext.Current.Response.End();
        }

        private void LoadAdmin()
        {
            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<IncidentEntity> temp = new Common.TBToList<IncidentEntity>();
            IList<IncidentEntity> list = temp.ToList(Common.DataHelper.WherePage("Incident", pageData, "CreateDate desc"));
            List<IncidentUIEntity> uiList = new List<IncidentUIEntity>();
            //Stopwatch stw = new Stopwatch();
            //stw.Start();
            DataDictionaryEntity dic = null;
            UserInfoEntity user = null;
            foreach (var item in list)
            {
                IncidentUIEntity entity = new IncidentUIEntity();
                entity.ID = item.ID;
                entity.IncidentNumber = item.IncidentNumber;
                entity.CreateDate = item.CreateDate;
                entity.Summary = item.Summary;
                entity.StatusFollowUp = item.StatusFollowUp;
                entity.Description = item.Description;
                //UI显示转换
                user = UserInfoBLLBase.Get_UserInfoEntity(item.AssignedTo);
                entity.AssignedToName = user.UserName;
                user = UserInfoBLLBase.Get_UserInfoEntity(item.ReportedBy);
                entity.ReportedByName = user.UserName;
                //从缓存中拿数据 127ms
                dic = DataCache.GetCache(item.DicPriority.ToString()) as DataDictionaryEntity;
                entity.DicPriotityName = dic.ItemName;
                dic = DataCache.GetCache(item.DicCountry.ToString()) as DataDictionaryEntity;
                entity.DicCountryName = dic.ItemName;
                dic = DataCache.GetCache(item.DicProduct.ToString()) as DataDictionaryEntity;
                entity.DicProductName = dic.ItemName;
                dic = DataCache.GetCache(item.DicStatus.ToString()) as DataDictionaryEntity;
                entity.DicStatusName = dic.ItemName;
                uiList.Add(entity);
            }
            //stw.Stop();
            //string time = stw.ElapsedMilliseconds.ToString();
            pageData.rows = uiList;
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));
        }

        /// <summary>
        /// 2.0 Staff加载自己的INC
        /// </summary>
        private void Staff()
        {
            switch (type)
            {
                case "loadStaff":
                    LoadStaff();
                    break;
                case "loadStaff,search":
                    StaffSearch();
                    break;
                default:
                    break;
            }
        }

        private void StaffSearch()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("AssignedTo", userID);
            if(!string.IsNullOrEmpty(IncidentNumber))
            {
                fields.Add("IncidentNumber", IncidentNumber);
            }
            //日期不为空的话，就拼接查询字符串
            if (!string.IsNullOrEmpty(dateBefore) && !string.IsNullOrEmpty(dateAfter))
            {           
                fields.Add("dateBefore", dateBefore);
                fields.Add("dateAfter", dateAfter);
            }
            string strPageIndex = HttpContext.Current.Request.Params["page"];
            string strPageSize = HttpContext.Current.Request.Params["rows"];
            //转换成json数据格式
            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<IncidentEntity> temp = new Common.TBToList<IncidentEntity>();
            IList<IncidentEntity> list = temp.ToList(Common.DataHelper.SearchData("Incident", pageData, "CreateDate", fields));
            List<IncidentUIEntity> uiList = new List<IncidentUIEntity>();
            //Stopwatch stw = new Stopwatch();
            //stw.Start();
            DataDictionaryEntity dic = null;
            UserInfoEntity user = null;
            foreach (var item in list)
            {
                IncidentUIEntity entity = new IncidentUIEntity();
                entity.ID = item.ID;
                entity.IncidentNumber = item.IncidentNumber;
                entity.CreateDate = item.CreateDate;
                entity.Summary = item.Summary;
                entity.StatusFollowUp = item.StatusFollowUp;
                entity.Description = item.Description;
                //UI显示转换
                user = UserInfoBLLBase.Get_UserInfoEntity(item.AssignedTo);
                entity.AssignedToName = user.UserName;
                user = UserInfoBLLBase.Get_UserInfoEntity(item.ReportedBy);
                entity.ReportedByName = user.UserName;
                //从缓存中拿数据 127ms
                dic = DataCache.GetCache(item.DicPriority.ToString()) as DataDictionaryEntity;
                entity.DicPriotityName = dic.ItemName;
                dic = DataCache.GetCache(item.DicCountry.ToString()) as DataDictionaryEntity;
                entity.DicCountryName = dic.ItemName;
                dic = DataCache.GetCache(item.DicProduct.ToString()) as DataDictionaryEntity;
                entity.DicProductName = dic.ItemName;
                dic = DataCache.GetCache(item.DicStatus.ToString()) as DataDictionaryEntity;
                entity.DicStatusName = dic.ItemName;
                uiList.Add(entity);
            }
            //stw.Stop();
            //string time = stw.ElapsedMilliseconds.ToString();
            pageData.rows = uiList;
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));
        }

        private void LoadStaff()
        {
            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<IncidentEntity> temp = new Common.TBToList<IncidentEntity>();
            IList<IncidentEntity> list = temp.ToList(Common.DataHelper.WherePage("Incident", pageData, "AssignedTo", Convert.ToInt32(userID)," and IsFill=0", "CreateDate desc"));
            List<IncidentUIEntity> uiList = new List<IncidentUIEntity>();
            //Stopwatch stw = new Stopwatch();
            //stw.Start();
            DataDictionaryEntity dic = null;
            UserInfoEntity user = null;
            foreach (var item in list)
            {
                IncidentUIEntity entity = new IncidentUIEntity();
                entity.ID = item.ID;
                entity.IncidentNumber = item.IncidentNumber;
                entity.CreateDate = item.CreateDate;
                entity.Summary = item.Summary;
                entity.StatusFollowUp = item.StatusFollowUp;
                entity.Description = item.Description;
                //UI显示转换
                user = UserInfoBLLBase.Get_UserInfoEntity(item.AssignedTo);
                entity.AssignedToName = user.UserName;
                user = UserInfoBLLBase.Get_UserInfoEntity(item.ReportedBy);
                entity.ReportedByName = user.UserName;
                //从缓存中拿数据 127ms
                dic = DataCache.GetCache(item.DicPriority.ToString()) as DataDictionaryEntity;
                entity.DicPriotityName = dic.ItemName;
                dic = DataCache.GetCache(item.DicCountry.ToString()) as DataDictionaryEntity;
                entity.DicCountryName = dic.ItemName;
                dic = DataCache.GetCache(item.DicProduct.ToString()) as DataDictionaryEntity;
                entity.DicProductName = dic.ItemName;
                dic = DataCache.GetCache(item.DicStatus.ToString()) as DataDictionaryEntity;
                entity.DicStatusName = dic.ItemName;
                uiList.Add(entity);
            }
            //stw.Stop();
            //string time = stw.ElapsedMilliseconds.ToString();
            pageData.rows = uiList;
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));
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