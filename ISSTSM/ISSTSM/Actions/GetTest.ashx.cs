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
    /// GetTest 的摘要说明
    /// </summary>
    public class GetTest : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            Common.DataHelper dt = new Common.DataHelper();
            //1.去数据库查询用户可以查看的哪些模块
            //2.将返回出来的数据转转换成treenode集合
            //3.将treenode转换成json字符串
            context.Response.ContentType = "text/plain";
            List<ModuleEntity> moduleList = Module_BLLSub.Get_ModuleAllByUserID(dt.CurUser.ID);
            //AddFullUrl(moduleList);
            List<TreeNode> treeList = Per2Node(moduleList, 1);
            string tree = Common.DataHelper.ToJson(treeList);
            context.Response.Write(tree);
        }

        #region 1.0 将 模块集合 转成 树节点集合 +public List<TreeNode> Per2Node(List<ModuleEntity> listPer, int parentId)
        /// <summary>
        ///  1.0 将 模块集合 转成 树节点集合
        /// </summary>
        /// <param name="listPer"></param>
        /// <returns></returns>
        public List<TreeNode> Per2Node(List<ModuleEntity> listPer, int parentId)
        {
            //创建一个 节点集合
            List<TreeNode> listNodes = new List<TreeNode>();
            //循环 权限集合
            foreach (var per in listPer)
            {
                //找出 父id 为 parentId 的 权限
                if (Convert.ToInt32( per.ParentID) == parentId)
                {
                    //将权限转成 树节点
                    var node = per.ToNode();
                    //将 节点 加入 节点集合
                    listNodes.Add(node);
                    //递归 查找子节点
                    node.children = Per2Node(listPer, node.id);
                }
            }
            //返回 节点集合
            return listNodes;
        }
        #endregion

        #region 2.0给treenode 的url填写全地址  + public static List<ModuleEntity> AddFullUrl(List<ModuleEntity> moduleList)
        /// <summary>
        /// 2.0给treenode 的url填写全地址
        /// </summary>
        /// <param name="moduleList"></param>
        /// <returns></returns>
        public static List<ModuleEntity> AddFullUrl(List<ModuleEntity> moduleList)
        {
            string url = HttpContext.Current.Request.Url.Authority; //http://localhost:20742/         
            foreach (var item in moduleList)
            {
                string temp = item.ModuleUrl;
                item.ModuleUrl = "";
                item.ModuleUrl = url + temp;
            }
            return moduleList;
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