using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Actions
{
    using ISSTSM.Entity;
    using ISSTSM.BusinessLogicLayer;

    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        HttpContext context = null;
        string username;
        string pwd;
        string isRemember;
        string type;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
             username = context.Request.Params["username"];
             pwd = context.Request.Params["pwd"];
             isRemember = context.Request.Params["ismember"];
            type=context.Request.Params["t"];
            this.context = context;
            switch (type)
            {
                case "login":
                    LoginIndex();
                    break;
                case "logout":
                    Logout();
                    break;
                default:
                    break;
            }
        }
        #region 1.0 登录方法private void LoginIndex()
        /// <summary>
        /// 1.0 登录方法private void Login()  
        /// </summary>
        private void LoginIndex()
        {
            //1.接受login.aspx传进来的用户名，密码，以及是否记住
            //2.验证用户名与密码是否正确，如果不正确，则返回相应信息，
            //2.1如果正确，设置cookie，过期时间30天，然后跳转到Index.aspx
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
            {
                Write(Kits.GetStrForJson(new JsonNode() { status = -1, stateStr = "username or pwd must fill" }));
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("UserName", username);
            dic.Add("Pwd", pwd);
            List<UserInfoEntity> entity = UserInfo_BLLSub.Get_UserInfoByWhere(dic);
            if (entity.Count <= 0)
            {
                Write(Kits.GetStrForJson(new JsonNode() { status = -1, stateStr = "username or pwd is error" }));
            }
            else
            {
                context.Session["curuser"] = entity[0];
                if (!string.IsNullOrEmpty(isRemember))
                {
                    HttpCookie cookie = new HttpCookie("remeber", entity[0].ID.ToString());//将userid写进cookie
                    cookie.Expires = DateTime.Now.AddDays(30);//保存30天
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("remeber", "");
                    cookie.Expires = DateTime.Now.AddDays(-1);//手动销毁cookie
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                Write(Kits.GetStrForJson(new JsonNode() { status = 100, stateStr = "success", URL = "Index.aspx" }));
            }
        }
        
        #endregion

        #region 2.0退出登录，清除所有信息 private void Logout
        /// <summary>
        /// 2.0退出登录，清除所有信息 private void Logout
        /// </summary>
        private void Logout()
        {
            throw new NotImplementedException();
        } 
        #endregion

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