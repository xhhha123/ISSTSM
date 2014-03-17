// =================================================================== 
// 项目说明
//====================================================================

// 文件： UserInfo.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
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
    /// 数据层 dbo.UserInfo 接口。
    /// </summary>
    public interface IUserInfoDataAccessLayer:IUserInfoDataAccessLayerBase
    {
        /// <summary>
        /// 根据str 得到 userinfo 数据实体
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>userinfo 数据实体</returns>
        List<UserInfoEntity> Get_UserInfoByWhere(Dictionary<string, string> dic);

        List<UserInfoUIEntity> Get_UserInfoAllByUserID(int Id);

    }
}

