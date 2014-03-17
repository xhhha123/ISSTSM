// =================================================================== 
// 项目说明
//====================================================================
// 文件： UserInfo.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
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
    /// BLL Layer For dbo.UserInfo.
    /// </summary>
    public class UserInfo_BLLSub : UserInfoBLLBase
    {
		#region ----------变量定义----------
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public UserInfo_BLLSub()
		{
		}
		#endregion
		
		#region----------函数定义---------
        /// <summary>
        ///根据条件查询， 得到 userinfo 数据实体
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>userinfo 数据实体</returns>
        public static List<UserInfoEntity> Get_UserInfoByWhere(Dictionary<string, string> dic)
        {
            // Validate input
            if (dic.Count <= 0)
                return null;

            // Use the dal to get a record 
            return _dal.Get_UserInfoByWhere(dic);
        }
		#endregion

        /// <summary>
        ///根据条件查询， 得到 该用户能管理的所有userinfo 数据实体
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>userinfo 数据实体List</returns>
        public static List<UserInfoUIEntity> Get_UserInfoAllByUserID(int Id)
        {
            return _dal.Get_UserInfoAllByUserID(Id);
        }
	}
}
