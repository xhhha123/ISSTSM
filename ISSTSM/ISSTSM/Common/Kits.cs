using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM
{
    /// <summary>
    /// 帮助类，主要用于生成json格式以及url等
    /// </summary>
    public class Kits
    {
        public static string GetFileText(string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }

        public static string GetPhyPath(string virPath)
        {
            return HttpContext.Current.Server.MapPath(virPath);
        }

        public static string GetappSettings(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static bool IsNum(string number)
        {
            int i = 0;
            return int.TryParse(number, out i);
        }

        public static int StringToInt(string number)
        {
            int num = 0;
            if (int.TryParse(number, out num))
            {
                return num;
            }
            else
            {
                return -1;
            }
        }

        public static string GetStrForJson(JsonNode jnode)
        {
            string fmtStr = "\"status\":{0},\"stateStr\":\"{1}\",\"datas\":{2},\"PageCount\":{3},\"RowCount\":{4},\"url\":\"{5}\"";

            string resStr =
             "{" +
                string.Format(
                fmtStr
                , jnode.status
                , jnode.stateStr
                , jnode.datas == null ? "[{}]" : jnode.datas
                , jnode.PageCount
                , jnode.RowCount
                , jnode.URL == null ? "" : jnode.URL)
                + "}";

            return resStr;
        }

        public static string EntryMD5(string str)
        {
            if (str == "") return "";
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
        }

        public static string SerializeToJson(object mode)
        {
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            return js.Serialize(mode);
        }
    }

    public class JsonNode
    {
        /// <summary>
        /// -1:错误
        /// 200：正常
        /// 304:跳转
        /// </summary>
        public int status
        {
            get;
            set;
        }

        public string stateStr
        {
            get;
            set;
        }


        public string datas
        {
            get;
            set;
        }

        public int PageCount
        {
            get;
            set;
        }

        public int RowCount
        {
            get;
            set;
        }
        public string URL
        {
            get;
            set;
        }

    }
}