﻿// =================================================================== 
// 项目说明
//====================================================================
// 文件： DataDictionary.cs
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
    /// BLL Layer For dbo.DataDictionary.
    /// </summary>
    public class DataDictionary_BLLSub : DataDictionaryBLLBase
    {
		#region ----------变量定义----------
		#endregion
		
		#region ----------构造函数----------
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public DataDictionary_BLLSub()
		{
		}
		#endregion
		
		#region----------函数定义---------
        public static IList<DataDictionaryEntity> Get_DataDictionaryAllByID(int ParentId)
        {
            return _dal.Get_DataDictionaryAllByID(ParentId);
        }

        public static  IList<DataDictionaryEntity> Get_DataDictionaryAll(string where)
        {
            return _dal.Get_DataDictionaryAll(where);
        }
		#endregion
	}
}
