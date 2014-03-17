// =================================================================== 
// 项目说明
//====================================================================
// 文件： Permission.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
	/// <summary>
	///Permission数据实体
	/// </summary>
	[Serializable]
	public class PermissionEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
        private string _permissionName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _sort;
		///<summary>
		///
		///</summary>
		private string _icon = String.Empty;
		///<summary>
		///
		///</summary>
		private bool _isVisible;
		///<summary>
		///
		///</summary>
		private string _description = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private bool _isButton;
        ///<summary>
        ///
        ///</summary>
        private string _permissionCode = String.Empty;
        
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public PermissionEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public PermissionEntity
		(
			int iD,
            string permissionName,
			int sort,
			string icon,
			bool isVisible,
			string description,
            bool isButton,
            string permissionCode
		)
		{
			_iD           = iD;
            _permissionName = permissionName;
			_sort         = sort;
			_icon         = icon;
			_isVisible    = isVisible;
			_description  = description;
            _isButton     = isButton;
            _permissionCode = permissionCode;
			
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
        public string PermissionName
		{
			get {return _permissionName;}
            set { _permissionName = value; }
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
		public string Icon
		{
			get {return _icon;}
			set {_icon = value;}
		}

		///<summary>
		///
		///</summary>
		public bool IsVisible
		{
			get {return _isVisible;}
			set {_isVisible = value;}
		}

		///<summary>
		///
		///</summary>
		public string Description
		{
			get {return _description;}
			set {_description = value;}
		}
        ///<summary>
        ///
        ///</summary>
        public bool IsButton
        {
            get { return _isButton; }
            set { _isButton = value; }
        }
        ///<summary>
        ///
        ///</summary>
        public string PermissionCode
        {
            get { return _permissionCode;}
            set { _permissionCode = value; }
        }
		#endregion
		
	}
}
