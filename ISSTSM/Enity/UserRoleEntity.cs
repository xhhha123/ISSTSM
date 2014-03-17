// =================================================================== 
// 项目说明
//====================================================================
// 文件： UserRole.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
	/// <summary>
	///UserRole数据实体
	/// </summary>
	[Serializable]
	public class UserRoleEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _userID;
		///<summary>
		///
		///</summary>
		private int _roleID;
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
		public UserRoleEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public UserRoleEntity
		(
			int iD,
			int userID,
			int roleID,
			int createUserID,
			DateTime createDate
		)
		{
			_iD           = iD;
			_userID       = userID;
			_roleID       = roleID;
			_createUserID = createUserID;
			_createDate   = createDate;
			
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
		public int UserID
		{
			get {return _userID;}
			set {_userID = value;}
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
