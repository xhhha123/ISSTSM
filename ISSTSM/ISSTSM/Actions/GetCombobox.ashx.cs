using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Actions
{
    using ISSTSM.BusinessLogicLayer;
    using ISSTSM.Entity;
    using ISSTSM.Common;
    using ISSTSM.DALFactory;
    /// <summary>
    /// GetCombobox 的摘要说明
    /// 用来获取easyui combobox的值
    /// </summary>
    public class GetCombobox : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public string json;
        Common.DataHelper dt = new Common.DataHelper();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string t = context.Request.Params["t"];
            string p= context.Request.Params["p"];
            switch (t)
            {
                case "getSection":
                    context.Response.Write(GetSection());
                    break;
                case "getDictionary":
                    context.Response.Write(GetDictionary(p));
                    break;
                case "getRole":
                    context.Response.Write(GetRole());
                    break;
                case "AssignedTo":
                    context.Response.Write(GetUser());
                    break;
                default:
                    break;
            }
        }

        private string GetUser()
        {
            IList<UserInfoEntity> list = UserInfo_BLLSub.Get_UserInfoAll();
            List<Combobox> boxlist = new List<Combobox>();
            foreach (var item in list)
            {
                Combobox box = new Combobox();
                box.id = item.ID;
                box.text = item.UserName;
                boxlist.Add(box);
            }
            return Common.DataHelper.ToJson(boxlist);
        }


        public string GetSection()
        {
            List<SectionEntity> seclist = new List<SectionEntity>();
            List<Combobox> boxlist = new List<Combobox>();
            seclist = (List < SectionEntity > )Section_BLLSub.Get_SectionAll();
            foreach (SectionEntity sec in seclist)
            {
                Combobox box = new Combobox();
                box.id = sec.ID;
                box.text = sec.SectionName;
                boxlist.Add(box);
            }
            return json = Common.DataHelper.ToJson(boxlist);
        }

        public string GetRole()
        {
            List<RoleEntity> rolist = new List<RoleEntity>();
            List<Combobox> boxlist = new List<Combobox>();
            rolist = Role_BLLSub.Get_RoleAll() as List<RoleEntity>;
            foreach (RoleEntity role in rolist)
            {
                Combobox box = new Combobox();
                box.id = role.ID;
                box.text = role.RoleName;
                boxlist.Add(box);
            }
            return json = Common.DataHelper.ToJson(boxlist);
        }


        public string GetDictionary(string p)
        {
           List<Combobox> boxlist = new List<Combobox>();
           List<DataDictionaryEntity> diclist= DataCache.GetCache(p) as List<DataDictionaryEntity>;
           foreach (DataDictionaryEntity dic in diclist)
           {
               Combobox box = new Combobox();
               box.id = dic.ID;
               box.text = dic.ItemName;
               boxlist.Add(box);
           }
           return json = Common.DataHelper.ToJson(boxlist);
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