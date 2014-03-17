using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Actions
{
    using Entity;
    using BusinessLogicLayer;

    /// <summary>
    /// Summary description for GetPermission
    /// </summary>
    public class GetPermission : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request.Params["action"];
            string result = string.Empty;
            switch (action.ToLower())
            { 
                case "search":
                    search();
                    break;
            }
            
        }

        private void search()
        {
            IList<PermissionEntity> list = PermissionBLLBase.Get_PermissionAll();
            string json=  Common.DataHelper.ToJson(list);
            HttpContext.Current.Response.Write(json);
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