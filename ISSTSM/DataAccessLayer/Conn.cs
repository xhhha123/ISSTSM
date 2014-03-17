using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISSTSM.DataAccessLayer
{
    public class Conn
    {
        public static string SqlConn
        {
            get
            {
                return "server=.;database=ISSTSM;uid=sa;pwd=1999141;";
            }
        }
    }
}
