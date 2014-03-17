// =================================================================== 
// 项目说明
//====================================================================

// 文件： ModulePermission.cs
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
    /// 数据层 dbo.ModulePermission 接口。
    /// </summary>
    public interface IModulePermissionDataAccessLayer : IModulePermissionDataAccessLayerBase
    {
        /// <summary>
        /// 根据moduleID获取某模块的权限
        /// </summary>
        /// <param name="modID"></param>
        /// <returns></returns>
        IList<PermissionEntity> Get_PerByModID(int modID);

        /// <summary>
        /// 根据模块ID，权限ID，删除对应的权限
        /// </summary>
        /// <param name="mId"></param>
        /// <param name="Pid"></param>
        /// <returns></returns>
        int Del_MPByMidPid(int Mid, int Pid);

        /// <summary>
        /// 得到 modulepermission 数据实体
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>modulepermission 数据实体</returns>
        ModulePermissionEntity Get_ModulePermissionEntity(int modID,int perID);

        /// <summary>
        /// 根据moduleID获取所有的ID
        /// </summary>
        /// <param name="modID"></param>
        /// <returns></returns>
        IList<ModulePermissionEntity> GetAllByModID(string where);
    }
}

