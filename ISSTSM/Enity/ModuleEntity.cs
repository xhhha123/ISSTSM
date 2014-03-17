using ISSTSM.Entity.EasyUIEntity;
// =================================================================== 
// 项目说明
//====================================================================
// 文件： Module.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
	/// <summary>
	///Module数据实体
	/// </summary>
	[Serializable]
	public class ModuleEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _moduleName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _ModuleUrl = String.Empty;
		///<summary>
		///
		///</summary>
		private string _icon = String.Empty;
		///<summary>
		///
		///</summary>
		private string _parentID = String.Empty;
		///<summary>
		///
		///</summary>
		private int _sort;
		///<summary>
		///
		///</summary>
		private bool _isVisible;
		///<summary>
		///
		///</summary>
		private bool _isMenu;
		///<summary>
		///
		///</summary>
		private bool _isDeleted;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public ModuleEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public ModuleEntity
		(
			int iD,
			string name,
			string ModuleUrl,
			string icon,
			string parentID,
			int sort,
			bool isVisible,
			bool isMenu,
			bool isDeleted
		)
		{
			_iD        = iD;
			_moduleName      = name;
			_ModuleUrl  = ModuleUrl;
			_icon      = icon;
			_parentID  = parentID;
			_sort      = sort;
			_isVisible = isVisible;
			_isMenu    = isMenu;
			_isDeleted = isDeleted;
			
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
		public string ModuleName
		{
			get {return _moduleName;}
			set {_moduleName = value;}
		}

		///<summary>
		///
		///</summary>
		public string ModuleUrl
		{
			get {return _ModuleUrl;}
			set {_ModuleUrl = value;}
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
		public string ParentID
		{
			get {return _parentID;}
			set {_parentID = value;}
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
		public bool IsVisible
		{
			get {return _isVisible;}
			set {_isVisible = value;}
		}

		///<summary>
		///
		///</summary>
		public bool IsMenu
		{
			get {return _isMenu;}
			set {_isMenu = value;}
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
        /// <summary>
        /// 将 权限 转成 easyUI tree节点对象
        /// </summary>
        /// <returns></returns>
       public TreeNode ToNode()
        {
            return new TreeNode()
            {
                id = this.ID,
                text = this.ModuleName,
                Checked = false,
                attributes = new  { href="/" + this.ModuleUrl }
            };
        }
	}
}
