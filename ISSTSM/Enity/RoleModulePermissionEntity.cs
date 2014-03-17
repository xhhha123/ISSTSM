// =================================================================== 
// 项目说明
//====================================================================
// 文件： RoleModulePermission.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
	/// <summary>
	///RoleModulePermission数据实体
	/// </summary>
	[Serializable]
	public class RoleModulePermissionEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _roleID;
		///<summary>
		///
		///</summary>
		private int _modulePermissionID;
		///<summary>
		///
		///</summary>
		private int _createUserID;
		///<summary>
		///
		///</summary>
		private DateTime _createDate;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public RoleModulePermissionEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public RoleModulePermissionEntity
		(
			int iD,
			int roleID,
			int modulePermissionID,
			int createUserID,
			DateTime createDate
		)
		{
			_iD                 = iD;
			_roleID             = roleID;
			_modulePermissionID = modulePermissionID;
			_createUserID       = createUserID;
			_createDate         = createDate;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public int ID
		{
			get {return _iD;}
			set {_iD = value;}
		}

		///<summary>
		///
		///</summary>
		public int RoleID
		{
			get {return _roleID;}
			set {_roleID = value;}
		}

		///<summary>
		///
		///</summary>
		public int ModulePermissionID
		{
			get {return _modulePermissionID;}
			set {_modulePermissionID = value;}
		}

		///<summary>
		///
		///</summary>
		public int CreateUserID
		{
			get {return _createUserID;}
			set {_createUserID = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime CreateDate
		{
			get {return _createDate;}
			set {_createDate = value;}
		}
	
		#endregion
		
	}
}
