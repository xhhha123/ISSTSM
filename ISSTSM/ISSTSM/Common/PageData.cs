using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTSM.Common
{
    public class PageData
    {
        public int PageIndex;
        public int PageSize;
        public int total;//easyui组件datagrid所需要
        
        public object permission;//权限，用来显示不同操作的按钮
        public object rows;//easyui组件datagrid所需要
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(Convert.ToDouble(total)/ Convert.ToDouble(PageSize));
            }
        }
    }
}