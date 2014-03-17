using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Actions
{
    using ISSTSM.BusinessLogicLayer;
    using ISSTSM.Entity;
    /// <summary>
    /// GetModulePermission 的摘要说明
    /// </summary>
    public class GetModulePermission : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public string json;
        Common.DataHelper dt = new Common.DataHelper();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string t = context.Request.Params["t"];
            switch (t)
            {
                case "operate":
                    context.Response.Write(GetOperate());
                    break;
                default:
                    break;
            }
        }

        public string GetOperate()
        {
            List<PermissionEntity> perlist = new List<PermissionEntity>();
            string moduleid = HttpContext.Current.Request.Params["moduleid"];
            int ModuleID = int.Parse(moduleid);
            perlist = Permission_BLLSub.GetPermissionByUserID(dt.CurUser.ID, ModuleID) as List<PermissionEntity>; 
            return json = Common.DataHelper.ToJson(perlist);
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