// =================================================================== 
// 项目说明
//====================================================================
// 文件： DataDictionary.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
	/// <summary>
	///DataDictionary数据实体
	/// </summary>
	[Serializable]
	public class DataDictionaryEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _parentID;
		///<summary>
		///
		///</summary>
		private string _itemCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _itemName = String.Empty;
		///<summary>
		///
		///</summary>
		private bool _IsVisible;
        ///<summary>
        ///
        ///</summary>
        private int _Sort;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public DataDictionaryEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public DataDictionaryEntity
		(
			int iD,
			int parentID,
			string itemCode,
			string itemName,
			bool IsVisible,
            int Sort
		)
		{
			_iD         = iD;
			_parentID   = parentID;
			_itemCode   = itemCode;
			_itemName   = itemName;
			_IsVisible = IsVisible;
            _Sort = Sort;
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
		public int ParentID
		{
			get {return _parentID;}
			set {_parentID = value;}
		}

		///<summary>
		///
		///</summary>
		public string ItemCode
		{
			get {return _itemCode;}
			set {_itemCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string ItemName
		{
			get {return _itemName;}
			set {_itemName = value;}
		}

		///<summary>
		///
		///</summary>
		public bool IsVisible
		{
			get {return _IsVisible;}
			set {_IsVisible = value;}
		}
        ///<summary>
        ///
        ///</summary>
        public int Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }
		#endregion
		
	}
}
