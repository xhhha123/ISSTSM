using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTTSM
{
    using ISSTSM.Entity;

    public partial class Index :ISSTSM.Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected UserInfoEntity CurUser
        {
            get
            {
                if (Session["curuser"] != null)
                {
                    return Session["curuser"] as UserInfoEntity;
                }
                return null;
            }
        }
    }
}