// =================================================================== 
// 项目说明
//====================================================================

// 文件： DataDictionary.cs
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
    /// 数据层 dbo.DataDictionary 接口。
    /// </summary>
    public interface IDataDictionaryDataAccessLayer:IDataDictionaryDataAccessLayerBase
    {
        IList<DataDictionaryEntity> Get_DataDictionaryAllByID(int ParentId);

        IList<DataDictionaryEntity> Get_DataDictionaryAll(string where);
    }
}

