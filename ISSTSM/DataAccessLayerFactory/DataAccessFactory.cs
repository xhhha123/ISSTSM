// ===================================================================
// 项目说明
//====================================================================
// SunCity@Copy Right 2006-2008
// 文件： DataAccessFactory.cs
// 项目名称：SunCity_MS
// 创建时间：2013/12/16
// 负责人：Chris
// ===================================================================
using System;
using System.Reflection;
using ISSTSM.IDataAccessLayer;

namespace ISSTSM.DALFactory
{
    /// <summary>
    /// 数据层工厂
    /// </summary>
    public class DataAccessFactory
    {
		private static readonly string path = System.Configuration.ConfigurationManager.AppSettings["ISSTSM"]; 
		
		private static object CreateObject(string path,string CacheKey)
		{			
			object objType = DataCache.GetCache(CacheKey);
			if (objType == null)
			{
				try
				{
					objType = Assembly.Load(path).CreateInstance(CacheKey);					
					DataCache.SetCache(CacheKey, objType);
				}
				catch{}

			}
			return objType;
		}
		/// <summary>
    	/// 通过反射机制，实例化DataDictionary接口对象。
    	/// </summary>
		///<returns>DataDictionary接口对象</returns>
		public static IDataDictionaryDataAccessLayer Create_DataDictionary()
		{		
			string CacheKey = path+".DataDictionaryDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IDataDictionaryDataAccessLayer)objType;		
		}
        /// <summary>
        /// 通过反射机制，实例化Incident接口对象。
        /// </summary>
        ///<returns>Incident接口对象</returns>
        public static IIncidentDataAccessLayer Create_Incident()
        {
            string CacheKey = path + ".IncidentDataAccessLayer";
            object objType = CreateObject(path, CacheKey);
            return (IIncidentDataAccessLayer)objType;
        }
		/// <summary>
    	/// 通过反射机制，实例化Module接口对象。
    	/// </summary>
		///<returns>Module接口对象</returns>
		public static IModuleDataAccessLayer Create_Module()
		{		
			string CacheKey = path+".ModuleDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IModuleDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化ModulePermission接口对象。
    	/// </summary>
		///<returns>ModulePermission接口对象</returns>
		public static IModulePermissionDataAccessLayer Create_ModulePermission()
		{		
			string CacheKey = path+".ModulePermissionDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IModulePermissionDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化Permission接口对象。
    	/// </summary>
		///<returns>Permission接口对象</returns>
		public static IPermissionDataAccessLayer Create_Permission()
		{		
			string CacheKey = path+".PermissionDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IPermissionDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化Role接口对象。
    	/// </summary>
		///<returns>Role接口对象</returns>
		public static IRoleDataAccessLayer Create_Role()
		{		
			string CacheKey = path+".RoleDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IRoleDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化RoleModulePermission接口对象。
    	/// </summary>
		///<returns>RoleModulePermission接口对象</returns>
		public static IRoleModulePermissionDataAccessLayer Create_RoleModulePermission()
		{		
			string CacheKey = path+".RoleModulePermissionDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IRoleModulePermissionDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化Section接口对象。
    	/// </summary>
		///<returns>Section接口对象</returns>
		public static ISectionDataAccessLayer Create_Section()
		{		
			string CacheKey = path+".SectionDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (ISectionDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化TimeSheet接口对象。
    	/// </summary>
		///<returns>TimeSheet接口对象</returns>
		public static ITimeSheetDataAccessLayer Create_TimeSheet()
		{		
			string CacheKey = path+".TimeSheetDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (ITimeSheetDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化UserInfo接口对象。
    	/// </summary>
		///<returns>UserInfo接口对象</returns>
		public static IUserInfoDataAccessLayer Create_UserInfo()
		{		
			string CacheKey = path+".UserInfoDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IUserInfoDataAccessLayer)objType;		
		}

		/// <summary>
    	/// 通过反射机制，实例化UserRole接口对象。
    	/// </summary>
		///<returns>UserRole接口对象</returns>
		public static IUserRoleDataAccessLayer Create_UserRole()
		{		
			string CacheKey = path+".UserRoleDataAccessLayer";	
			object objType=CreateObject(path,CacheKey);			
			return (IUserRoleDataAccessLayer)objType;		
		}

		
    }
}

