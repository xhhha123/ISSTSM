using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Actions
{
    using ISSTSM.BusinessLogicLayer;
    using ISSTSM.Entity;
    using ISSTSM.Entity.EasyUIEntity;
    /// <summary>
    /// GetUserInfo 的摘要说明
    /// </summary>
    public class GetUserInfo : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        public string json;
        public string name;
        public string sectionId;

        Common.DataHelper dt = new Common.DataHelper();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string t = context.Request.Params["t"];
            string id=context.Request.Params["id"];
            name=context.Request.Params["name"];
            sectionId = context.Request.Params["sectionId"];

            switch (t)
            {
                case "getall":
                    context.Response.Write(GetAllUser());
                    break;
                case "EditUser":      
                    context.Response.Write(EditUser(id));
                    break;
                case "EditUserOK":
                    context.Response.Write(EditUserOK(id));
                    break;
                case "AddUser":
                    context.Response.Write(AddUserOK());
                    break;
                case "DeleteUser":
                    context.Response.Write(DeleteUser(id));
                    break;
                case "GetRole":
                    context.Response.Write(GetRole(id));
                    break;
                case "ResetPwd":
                    context.Response.Write(ResetPwd(id));
                    break;
                case "getall,search":             
                    context.Response.Write(Search());
                    break;
                default:
                    break;
            }
            
        }

        //重置密码
        public string ResetPwd(string id)
        {
            int ID = Convert.ToInt32(id);
            UserInfoEntity entity = UserInfoBLLBase.Get_UserInfoEntity(ID);
            var TEST = HttpContext.Current.Request.Params["newPassword"];
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["newPassword"]))
            {
                entity.Pwd = HttpContext.Current.Request.Params["newPassword"];
                UserInfoBLLBase.Create_UserInfoUpdate(entity);
                return "success";
            }
            else {
                return "fail";
            }
        }
        //编辑时获取用户角色信息
        public string GetRole(string id)
        {
            int userID = Convert.ToInt32(id);
            List<UserRoleEntity> list = new List<UserRoleEntity>();
            list = UserRole_BLLSub.GetAllByUserID(userID);
            return json = Common.DataHelper.ToJson(list);
        }

        //编辑时获取被编辑用户的信息
        public string EditUser(string id)
        {
            int ID = Convert.ToInt32(id);
            UserInfoEntity user = UserInfo_BLLSub.Get_UserInfoEntity(ID);
            List<UserInfoEntity> userlist = new List<UserInfoEntity>();
            userlist.Add(user);
            return json = Common.DataHelper.ToJson(userlist);
        }

        //编辑提交
        public string EditUserOK(string id)
        {

            int ID = Convert.ToInt32(id);
            UserInfoEntity user = UserInfo_BLLSub.Get_UserInfoEntity(ID);
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["UserName"]))
            {
                user.UserName = HttpContext.Current.Request.Params["UserName"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["UserName"]))
            {
                user.RealName = HttpContext.Current.Request.Params["UserName"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["Email"]))
            {
                user.Email = HttpContext.Current.Request.Params["Email"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["Telephone"]))
            {
                user.Telephone = HttpContext.Current.Request.Params["Telephone"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["SectionID"]))
            {
                user.SectionID = int.Parse(HttpContext.Current.Request.Params["SectionID"]);
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["SectionID"]))
            {
                user.SectionID = int.Parse(HttpContext.Current.Request.Params["SectionID"]);
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["DicSex"]))
            {
                user.DicSex = int.Parse(HttpContext.Current.Request.Params["DicSex"]);
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["DicStatus"]))
            {
                user.DicStatus = int.Parse(HttpContext.Current.Request.Params["DicStatus"]);
            }
            UserInfo_BLLSub.Create_UserInfoUpdate(user);
            //编辑用户角色,删除旧的，添加新的
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["Role"]))
            {
                List<UserRoleEntity> urlist = new List<UserRoleEntity>();
                urlist = UserRole_BLLSub.GetAllByUserID(ID);
                foreach (UserRoleEntity ur in urlist)
                {
                    UserRole_BLLSub.Create_UserRoleDelete(ur.ID);
                }
                var rolearr = HttpContext.Current.Request.Params["Role"];
                string[] role = rolearr.Split(',');
                for (int i = 0; i < role.Length; i++)
                {
                    if (!string.IsNullOrEmpty(role[i]))
                    {
                        UserRoleEntity userrole = new UserRoleEntity();
                        userrole.UserID = ID;
                        userrole.RoleID = int.Parse(role[i]);
                        userrole.CreateDate = DateTime.Now;
                        UserRoleBLLBase.Create_UserRoleInsert(userrole);
                    }
                }
            }
            return "succeed";    
        }

        //获取所有用户
        public string GetAllUser()
        {
            string strPageIndex=HttpContext.Current.Request.Params["page"];
            string strPageSize = HttpContext.Current.Request.Params["rows"];
            //转换成json数据格式
            Common.PageData pageData = new Common.PageData()
            {
                PageIndex = int.Parse(strPageIndex),
                PageSize = int.Parse(strPageSize)
            };
            List<UserInfoUIEntity> finallist = new List<UserInfoUIEntity>();
            Common.TBToList<UserInfoEntity> temp = new Common.TBToList<UserInfoEntity>();
            IList<UserInfoEntity> list = temp.ToList(Common.DataHelper.WherePage("UserInfo", pageData, "ID"));
            foreach (var item in list)
            {
                SectionEntity sec = SectionBLLBase.Get_SectionEntity(item.SectionID);
                UserInfoUIEntity uientity = new UserInfoUIEntity();
                uientity.ID = item.ID;
                uientity.DicAddress = item.DicAddress;
                uientity.DicSex = item.DicSex;
                uientity.DicStatus = item.DicStatus;
                uientity.Email = item.Email;
                uientity.Photopath = item.Photopath;
                uientity.Pwd = item.Pwd;
                uientity.QQ = item.QQ;
                uientity.RealName = item.RealName;
                uientity.UserName = item.UserName;
                uientity.Telephone = item.Telephone;
                uientity.SectionName = sec.SectionName;
                finallist.Add(uientity);
            }
            //pageData.rows = list.ToList(Common.DataHelper.WherePage("UserInfo", pageData, "ID"));
            pageData.rows = finallist;
            return json = Common.DataHelper.ToJson(pageData);
        }


        public string AddUserOK()
        {
            UserInfoEntity entity = new UserInfoEntity();
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["UserName"]))
            {
                entity.UserName = HttpContext.Current.Request.Params["UserName"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["RealName"]))
            {
                entity.RealName = HttpContext.Current.Request.Params["RealName"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["Password"]))
            {
                entity.Pwd = HttpContext.Current.Request.Params["Password"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["Section"]))
            {
                entity.SectionID = int.Parse(HttpContext.Current.Request.Params["Section"]);
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["DicAddress"]))
            {
                entity.DicAddress = int.Parse(HttpContext.Current.Request.Params["DicAddress"]);
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["DicSex"]))
            {
                entity.DicSex = int.Parse(HttpContext.Current.Request.Params["DicSex"]);
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["DicStatus"]))
            {
                entity.DicStatus = int.Parse(HttpContext.Current.Request.Params["DicStatus"]);
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["Email"]))
            {
                entity.Email = HttpContext.Current.Request.Params["Email"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["Photopath"]))
            {
                entity.Photopath = HttpContext.Current.Request.Params["Photopath"];
            }
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["Telephone"]))
            {
                entity.Telephone = HttpContext.Current.Request.Params["Telephone"];
            }
            var rolearr= HttpContext.Current.Request.Params["Role"];
            int userID = UserInfoBLLBase.Create_UserInfoInsert(entity);
            string[] role=rolearr.Split(',');
            for (int i = 0; i < role.Length; i++)
            {
                if (!string.IsNullOrEmpty(role[i]))
                {
                    UserRoleEntity userrole = new UserRoleEntity();
                    userrole.UserID = userID;
                    userrole.RoleID = Convert.ToInt32(role[i]);
                    userrole.CreateUserID = 1;
                    userrole.CreateDate = DateTime.Now;
                    int num = UserRoleBLLBase.Create_UserRoleInsert(userrole);
                   
                }
            }    
            return "succeed";
        }

        public string DeleteUser(string id)
        {
            int ID = int.Parse(id);
            UserInfoBLLBase.Create_UserInfoDelete(ID);
            return "Success";
        }

        /// <summary>
        /// 根据条件进行查询
        /// </summary>
        private string Search()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            if(!string.IsNullOrEmpty(name))
            {
                fields.Add("UserName", name);
            }            
            //部门ID不为空的话，就拼接sectionId
            if(!string.IsNullOrEmpty(sectionId))
            {
                fields.Add("SectionID", sectionId);
            }
            
            string strPageIndex = HttpContext.Current.Request.Params["page"];
            string strPageSize = HttpContext.Current.Request.Params["rows"];
            //转换成json数据格式
            Common.PageData pageData = new Common.PageData()
            {
                PageIndex = int.Parse(strPageIndex),
                PageSize = 100//查询定义，可以修改
            };
            List<UserInfoUIEntity> finallist = new List<UserInfoUIEntity>();
            Common.TBToList<UserInfoEntity> temp = new Common.TBToList<UserInfoEntity>();
            IList<UserInfoEntity> list = temp.ToList(Common.DataHelper.SearchData("UserInfo", pageData,fields));
            foreach (var item in list)
            {
                SectionEntity sec = SectionBLLBase.Get_SectionEntity(item.SectionID);
                UserInfoUIEntity uientity = new UserInfoUIEntity();
                uientity.ID = item.ID;
                uientity.DicAddress = item.DicAddress;
                uientity.DicSex = item.DicSex;
                uientity.DicStatus = item.DicStatus;
                uientity.Email = item.Email;
                uientity.Photopath = item.Photopath;
                uientity.Pwd = item.Pwd;
                uientity.QQ = item.QQ;
                uientity.RealName = item.RealName;
                uientity.UserName = item.UserName;
                uientity.Telephone = item.Telephone;
                uientity.SectionName = sec.SectionName;
                finallist.Add(uientity);
            }
            pageData.rows = finallist;
            return Common.DataHelper.ToJson(pageData);
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