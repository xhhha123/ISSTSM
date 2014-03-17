// =================================================================== 
// 项目说明
//====================================================================
// 文件： Role.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
	/// <summary>
	///Role数据实体
	/// </summary>
	[Serializable]
	public class RoleEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _roleName = String.Empty;
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
		private int _sort;
		///<summary>
		///
		///</summary>
		private bool _isDeleted;
		///<summary>
		///
		///</summary>
		private string _description = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public RoleEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public RoleEntity
		(
			int iD,
			string name,
			int createUserID,
			DateTime createDate,
			int sort,
			bool isDeleted,
			string description
		)
		{
			_iD           = iD;
			_roleName         = name;
			_createUserID = createUserID;
			_createDate   = createDate;
			_sort         = sort;
			_isDeleted    = isDeleted;
			_description  = description;
			
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
		public string RoleName
		{
			get {return _roleName;}
			set {_roleName = value;}
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
		public int Sort
		{
			get {return _sort;}
			set {_sort = value;}
		}

		///<summary>
		///
		///</summary>
		public bool IsDeleted
		{
			get {return _isDeleted;}
			set {_isDeleted = value;}
		}

		///<summary>
		///
		///</summary>
		public string Description
		{
			get {return _description;}
			set {_description = value;}
		}
	
		#endregion
		
	}
}
