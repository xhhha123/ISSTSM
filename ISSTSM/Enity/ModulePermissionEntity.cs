// =================================================================== 
// 项目说明
//====================================================================
// 文件： ModulePermission.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
	/// <summary>
	///ModulePermission数据实体
	/// </summary>
	[Serializable]
	public class ModulePermissionEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _moduleID;
		///<summary>
		///
		///</summary>
		private int _permissionID;
		///<summary>
		///
		///</summary>
		private int _createUserID;
		///<summary>
		///
		///</summary>
		private DateTime _createDate;
		///<summary>
		///
		///</summary>
		private bool _isDeleted;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public ModulePermissionEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public ModulePermissionEntity
		(
			int iD,
			int moduleID,
			int permissionID,
			int createUserID,
			DateTime createDate,
			bool isDeleted
		)
		{
			_iD           = iD;
			_moduleID     = moduleID;
			_permissionID = permissionID;
			_createUserID = createUserID;
			_createDate   = createDate;
			_isDeleted    = isDeleted;
			
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
		public int ModuleID
		{
			get {return _moduleID;}
			set {_moduleID = value;}
		}

		///<summary>
		///
		///</summary>
		public int PermissionID
		{
			get {return _permissionID;}
			set {_permissionID = value;}
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

		///<summary>
		///
		///</summary>
		public bool IsDeleted
		{
			get {return _isDeleted;}
			set {_isDeleted = value;}
		}
	
		#endregion
		
	}
}
