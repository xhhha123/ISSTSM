// =================================================================== 
// 项目说明
//====================================================================

// 文件： Incident.cs
// 项目名称：SunCity_MS 
// 创建时间：2014/1/9
// 负责人：xhh
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ISSTSM.Entity;
namespace ISSTSM.IDataAccessLayer
{
    /// <summary>
    /// 数据层 dbo.Incident 接口。
    /// </summary>
    public interface IIncidentDataAccessLayer:IIncidentDataAccessLayerBase
    {
        /// <summary>
        /// 根据条件得到数据表Incident所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<IncidentEntity> Get_IncidentAllByWhere(string where);
    }
}

