﻿// =================================================================== 
// 项目说明
//====================================================================

// 文件： Module.cs
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
    /// 数据层 dbo.Module 接口。
    /// </summary>
    public interface IModuleDataAccessLayer:IModuleDataAccessLayerBase
    {
        List<ModuleEntity> Get_ModuleAllByUserID(int id);

        List<ModuleEntity> Get_ModuleAllByParentID(int parentID);

        List<ModuleEntity> Get_ModuleAllByRoleID(int RoleID);
    }
}

