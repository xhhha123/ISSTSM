// =================================================================== 
// 项目说明
//====================================================================
// 文件： Incident.cs
// 项目名称：SunCity_MS 
// 创建时间：2014/1/9
// 负责人：xhh
// ===================================================================
using System;
using System.Data;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;
using ISSTSM.DALFactory;
using System.Collections.Generic;

namespace ISSTSM.BusinessLogicLayer
{
    /// <summary>
    /// BLL Layer For dbo.Incident.
    /// </summary>
    public class Incident_BLLSub : IncidentBLLBase
    {
		#region ----------变量定义----------
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public Incident_BLLSub()
		{
		}
		#endregion
		
		#region----------函数定义---------
        public static IList<IncidentEntity> Get_IncidentAllByWhere(string where)
        {
            return _dal.Get_IncidentAllByWhere(where);
        }
		#endregion
	}
}
