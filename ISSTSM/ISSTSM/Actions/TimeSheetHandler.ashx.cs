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
    using System.Diagnostics;

    /// <summary>
    /// TimeSheetCommonHandler 的摘要说明
    /// </summary>
    public class TimeSheetHandler : IHttpHandler
    {
       
        string view;//定义有三种，一个是admin ,一个是common,一个是avon
        string type;//定义对数据进行的操作
        string id;
        string pageIndex;
        string pageSize;

        string IncidentID;
        string date;
        string BillableHour;
        string UserID;
        string DicTitle;
        string DicProject;
        string DicGroup;
        string DicType;
        string SubProject;
        string Tasks;
        string UserName;
        string dateBefore;
        string dateAfter;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            view = context.Request.Params["view"];
            type = context.Request.Params["t"];
            pageIndex = context.Request.Params["page"];
            pageSize = context.Request.Params["rows"];

            IncidentID = context.Request.Params["ID"];
            date = context.Request.Params["date"];
            BillableHour = context.Request.Params["BillableHour"];
            UserID = context.Request.Params["userID"];
            DicTitle = context.Request.Params["Title"];
            DicProject = context.Request.Params["Project"];
            DicGroup = context.Request.Params["Group"];
            DicType = context.Request.Params["Type"];
            SubProject = context.Request.Params["SubProject"];
            Tasks = context.Request.Params["Tasks"];
            UserName = context.Request.Params["UserName"];
            dateBefore = context.Request.Params["dateBefore"];
            dateAfter = context.Request.Params["dateAfter"];

            switch (view)
            {
                case "admin":
                    Admin();
                    break;
                case "staff":
                    Staff();
                    break;
                case "avon":
                    Avon();
                    break;
                default:
                    break;
            }
        }

        #region 1.0 所有处理Admin页面发来的请求  private void Admin()
        /// <summary>
        /// 1.0 所有处理Admin页面发来的请求  private void Admin()
        /// </summary>
        private void Admin()
        {
            switch (type)
            {
                case "loadAdmin":
                    LoadAdmin();
                    break;
                case "loadAdmin,search":
                    AdminSearch();
                    break;
                default:
                    break;
            }
        }


        #endregion

        #region 1.1 Admin的Load请求 private void LoadAdmin()
        /// <summary>
        /// Admin的Load请求 private void LoadAdmin()
        /// </summary>
        private void LoadAdmin()
        {
            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<TimeSheetEntity> temp = new Common.TBToList<TimeSheetEntity>();
            IList<TimeSheetEntity> list = temp.ToList(Common.DataHelper.WherePage("TimeSheet", pageData, "date desc"));
            List<TimeSheetUIEntity> uiList = new List<TimeSheetUIEntity>();
            //Stopwatch stw = new Stopwatch();
            //stw.Start();
            DataDictionaryEntity dic = null;
            UserInfoEntity user = null;
            IncidentEntity inc = null;
            foreach (var item in list)
            {
                TimeSheetUIEntity entity = new TimeSheetUIEntity();
                entity.ID = item.ID;
                entity.Date = item.Date;
                entity.BillableHour = item.BillableHour;
                entity.SubProject = item.SubProject;
                entity.Tasks = item.Tasks;
                //UI显示转换
                inc = IncidentBLLBase.Get_IncidentEntity(item.IncidentID);
                entity.IncidentName = inc.IncidentNumber;
                user = UserInfoBLLBase.Get_UserInfoEntity(item.UserID);
                entity.UserName = user.UserName;
                //从数据库中拿数据330ms
                //dic = DataDictionaryBLLBase.Get_DataDictionaryEntity(item.DicTitle);
                //entity.DicTitleName = dic.ItemName;
                //dic = DataDictionaryBLLBase.Get_DataDictionaryEntity(item.DicProject);
                //entity.DicProjectName = dic.ItemName;
                //dic = DataDictionaryBLLBase.Get_DataDictionaryEntity(item.DicGroup);
                //entity.DicGroupName = dic.ItemName;
                //dic = DataDictionaryBLLBase.Get_DataDictionaryEntity(item.DicType);
                //entity.DicTypeName = dic.ItemName;
                //从缓存中拿数据 127ms

                dic = DataCache.GetCache(item.DicTitle.ToString()) as DataDictionaryEntity;
                entity.DicTitleName = dic.ItemName;
                dic = DataCache.GetCache(item.DicProject.ToString()) as DataDictionaryEntity;
                entity.DicProjectName = dic.ItemName;
                dic = DataCache.GetCache(item.DicGroup.ToString()) as DataDictionaryEntity;
                entity.DicGroupName = dic.ItemName;
                dic = DataCache.GetCache(item.DicType.ToString()) as DataDictionaryEntity;
                entity.DicTypeName = dic.ItemName;
                uiList.Add(entity);
            }
            //stw.Stop();
            //string time = stw.ElapsedMilliseconds.ToString();
            pageData.rows = uiList;
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));
        } 
        #endregion

        private void AdminSearch()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            //查询判断
            if (!string.IsNullOrEmpty(UserName))
            {
                Dictionary<string, string> userInfo = new Dictionary<string, string>();
                userInfo.Add("UserName", UserName);
                Common.TBToList<UserInfoEntity> usertemp = new Common.TBToList<UserInfoEntity>();
                IList<UserInfoEntity> userlist = usertemp.ToList(Common.DataHelper.GetDataByWhere("UserInfo", userInfo));
                if (userlist.Count > 0)
                {
                    fields.Add("UserID", userlist[0].ID.ToString());
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert("+"'查无此人'"+")</script>");
                    HttpContext.Current.Response.End();
                }
            }
            //日期不为空的话，就拼接查询字符串
            if (!string.IsNullOrEmpty(dateBefore) && !string.IsNullOrEmpty(dateAfter))
            {
                fields.Add("dateBefore", dateBefore);
                fields.Add("dateAfter", dateAfter);
            }

            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<TimeSheetEntity> temp = new Common.TBToList<TimeSheetEntity>();
            IList<TimeSheetEntity> list = temp.ToList(Common.DataHelper.SearchData("TimeSheet", pageData, "Date", fields));
            List<TimeSheetUIEntity> uiList = new List<TimeSheetUIEntity>();
            DataDictionaryEntity dic = null;
            UserInfoEntity user = null;
            IncidentEntity inc = null;
            foreach (var item in list)
            {
                TimeSheetUIEntity entity = new TimeSheetUIEntity();
                entity.ID = item.ID;
                entity.Date = item.Date;
                entity.BillableHour = item.BillableHour;
                entity.SubProject = item.SubProject;
                entity.Tasks = item.Tasks;
                //UI显示转换
                inc = IncidentBLLBase.Get_IncidentEntity(item.IncidentID);
                entity.IncidentName = inc.IncidentNumber;
                user = UserInfoBLLBase.Get_UserInfoEntity(item.UserID);
                entity.UserName = user.UserName;
                //从数据库中拿数据330ms
                //从缓存中拿数据 127ms
                dic = DataCache.GetCache(item.DicTitle.ToString()) as DataDictionaryEntity;
                entity.DicTitleName = dic.ItemName;
                dic = DataCache.GetCache(item.DicProject.ToString()) as DataDictionaryEntity;
                entity.DicProjectName = dic.ItemName;
                dic = DataCache.GetCache(item.DicGroup.ToString()) as DataDictionaryEntity;
                entity.DicGroupName = dic.ItemName;
                dic = DataCache.GetCache(item.DicType.ToString()) as DataDictionaryEntity;
                entity.DicTypeName = dic.ItemName;
                uiList.Add(entity);
            }
            //stw.Stop();
            //string time = stw.ElapsedMilliseconds.ToString();
            pageData.rows = uiList;
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));
        } 

        private void Staff()
        {
            switch (type)
            {
                case "AddStaffTS":
                    AddStaffTS();
                    break;
                case "loadStaffTS":
                    LoadStaffTS();
                    break;
                case "loadStaffTS,search":
                    StaffSearch();
                    break;
                default:
                    break;
            }
        }

        private void StaffSearch()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            ////查询判断
            //if (!string.IsNullOrEmpty(UserName))
            //{
            //    Dictionary<string, string> userInfo = new Dictionary<string, string>();
            //    userInfo.Add("UserName", UserName);
            //    Common.TBToList<UserInfoEntity> usertemp = new Common.TBToList<UserInfoEntity>();
            //    IList<UserInfoEntity> userlist = usertemp.ToList(Common.DataHelper.GetDataByWhere("UserInfo", userInfo));
            //    if (userlist.Count > 0)
            //    {
            //        fields.Add("UserID", userlist[0].ID.ToString());
            //    }
            //    else
            //    {
            //        HttpContext.Current.Response.Write("<script>alert(" + "'查无此人'" + ")</script>");
            //        HttpContext.Current.Response.End();
            //    }
            //}
            //日期不为空的话，就拼接查询字符串
            if (!string.IsNullOrEmpty(dateBefore) && !string.IsNullOrEmpty(dateAfter))
            {
                fields.Add("UserID", UserID);
                fields.Add("dateBefore", dateBefore);
                fields.Add("dateAfter", dateAfter);
            }

            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<TimeSheetEntity> temp = new Common.TBToList<TimeSheetEntity>();
            IList<TimeSheetEntity> list = temp.ToList(Common.DataHelper.SearchData("TimeSheet", pageData, "Date", fields));
            List<TimeSheetUIEntity> uiList = new List<TimeSheetUIEntity>();
            DataDictionaryEntity dic = null;
            UserInfoEntity user = null;
            IncidentEntity inc = null;
            foreach (var item in list)
            {
                TimeSheetUIEntity entity = new TimeSheetUIEntity();
                entity.ID = item.ID;
                entity.Date = item.Date;
                entity.BillableHour = item.BillableHour;
                entity.SubProject = item.SubProject;
                entity.Tasks = item.Tasks;
                //UI显示转换
                inc = IncidentBLLBase.Get_IncidentEntity(item.IncidentID);
                entity.IncidentName = inc.IncidentNumber;
                user = UserInfoBLLBase.Get_UserInfoEntity(item.UserID);
                entity.UserName = user.UserName;
                //从数据库中拿数据330ms
                //从缓存中拿数据 127ms
                dic = DataCache.GetCache(item.DicTitle.ToString()) as DataDictionaryEntity;
                entity.DicTitleName = dic.ItemName;
                dic = DataCache.GetCache(item.DicProject.ToString()) as DataDictionaryEntity;
                entity.DicProjectName = dic.ItemName;
                dic = DataCache.GetCache(item.DicGroup.ToString()) as DataDictionaryEntity;
                entity.DicGroupName = dic.ItemName;
                dic = DataCache.GetCache(item.DicType.ToString()) as DataDictionaryEntity;
                entity.DicTypeName = dic.ItemName;
                uiList.Add(entity);
            }
            //stw.Stop();
            //string time = stw.ElapsedMilliseconds.ToString();
            pageData.rows = uiList;
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));
        }

        private void LoadStaffTS()
        {
            PageData pageData = new PageData()
            {
                PageIndex = Convert.ToInt32(pageIndex),
                PageSize = Convert.ToInt32(pageSize)
            };
            Common.TBToList<TimeSheetEntity> temp = new Common.TBToList<TimeSheetEntity>();
            IList<TimeSheetEntity> list = temp.ToList(Common.DataHelper.WherePage("TimeSheet", pageData, "UserID", Convert.ToInt32(UserID),"", "date desc"));
            List<TimeSheetUIEntity> uiList = new List<TimeSheetUIEntity>();
            //Stopwatch stw = new Stopwatch();
            //stw.Start();
            DataDictionaryEntity dic = null;
            UserInfoEntity user = null;
            IncidentEntity inc = null;
            foreach (var item in list)
            {
                TimeSheetUIEntity entity = new TimeSheetUIEntity();
                entity.ID = item.ID;
                entity.Date = item.Date;
                entity.BillableHour = item.BillableHour;
                entity.SubProject = item.SubProject;
                entity.Tasks = item.Tasks;
                //UI显示转换
                inc = IncidentBLLBase.Get_IncidentEntity(item.IncidentID);
                entity.IncidentName = inc.IncidentNumber;
                user = UserInfoBLLBase.Get_UserInfoEntity(item.UserID);
                entity.UserName = user.UserName;
                //从缓存中拿数据 127ms
                dic = DataCache.GetCache(item.DicTitle.ToString()) as DataDictionaryEntity;
                entity.DicTitleName = dic.ItemName;
                dic = DataCache.GetCache(item.DicProject.ToString()) as DataDictionaryEntity;
                entity.DicProjectName = dic.ItemName;
                dic = DataCache.GetCache(item.DicGroup.ToString()) as DataDictionaryEntity;
                entity.DicGroupName = dic.ItemName;
                dic = DataCache.GetCache(item.DicType.ToString()) as DataDictionaryEntity;
                entity.DicTypeName = dic.ItemName;
                uiList.Add(entity);
            }
            //stw.Stop();
            //string time = stw.ElapsedMilliseconds.ToString();
            pageData.rows = uiList;
            HttpContext.Current.Response.Write(Common.DataHelper.ToJson(pageData));
        }

        private void AddStaffTS()
        {
            if (string.IsNullOrEmpty(date) ||
    string.IsNullOrEmpty(BillableHour) ||
    string.IsNullOrEmpty(DicTitle) ||
    string.IsNullOrEmpty(DicProject) ||
    string.IsNullOrEmpty(DicGroup) ||
    string.IsNullOrEmpty(DicType) ||
    string.IsNullOrEmpty(SubProject))
            {
                HttpContext.Current.Response.Write("Can not be empty");
                HttpContext.Current.Response.End();
            }
            TimeSheetEntity entity = new TimeSheetEntity();
            entity.IncidentID = Convert.ToInt32(IncidentID);
            entity.Date = DateTime.Parse(date);
            entity.BillableHour =float.Parse( BillableHour);
            entity.UserID = Convert.ToInt32(UserID);
            entity.DicTitle = Convert.ToInt32(DicTitle);
            entity.DicProject = Convert.ToInt32(DicProject);
            entity.DicGroup = Convert.ToInt32(DicGroup);
            entity.DicType = Convert.ToInt32(DicType);
            entity.SubProject = SubProject;
            entity.Tasks = Tasks;
            TimeSheetBLLBase.Create_TimeSheetInsert(entity);
            IncidentEntity inc = IncidentBLLBase.Get_IncidentEntity(Convert.ToInt32(IncidentID));
            inc.IsFill = 1;
            IncidentBLLBase.Create_IncidentUpdate(inc);
            HttpContext.Current.Response.Write("Success");
            HttpContext.Current.Response.End();
        }

        private void Avon()
        {
            throw new NotImplementedException();
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