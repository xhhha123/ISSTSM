// =================================================================== 
// 项目说明
//====================================================================
// 文件： ModulePermission.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
using System.Data;
using ISSTSM.Entity;
using ISSTSM.IDataAccessLayer;
using ISSTSM.DALFactory;

namespace ISSTSM.BusinessLogicLayer
{
    using Enity;
    using DataAccessLayer;
    using System.Collections.Generic;
    /// <summary>
    /// BLL Layer For dbo.ModulePermission.
    /// </summary>
    public class ModulePermission_BLLSub : ModulePermissionBLLBase
    {
        #region ----------变量定义----------
        #endregion

        #region ----------构造函数----------
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ModulePermission_BLLSub()
        {
        }
        #endregion

        #region----------函数定义---------
        /// <summary>
        /// 模块授权，通过modID获取该模块所具有权限
        /// </summary>
        /// <param name="modID"></param>
        /// <returns></returns>
        public IList<PermissionEntity> Get_ModPerByModID(int modID)
        {
            return new ModulePermissionDataAccessLayer().Get_PerByModID(modID); ;
        }
        #endregion

        public int Del_MPByMidPid(int Mid, int Pid)
        {
            return new ModulePermissionDataAccessLayer().Del_MPByMidPid(Mid, Pid);
        }

        public static ModulePermissionEntity Get_ModulePermissionEntity(int modID, int perID)
        {
            return _dal.Get_ModulePermissionEntity(modID, perID);
        }

        public static IList<ModulePermissionEntity> GetAllByModID(string where)
        {
            return _dal.GetAllByModID(where);
        }
    }
}
