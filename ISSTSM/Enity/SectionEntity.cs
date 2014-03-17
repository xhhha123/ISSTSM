// =================================================================== 
// 项目说明
//====================================================================
// 文件： Section.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
	/// <summary>
	///Section数据实体
	/// </summary>
	[Serializable]
	public class SectionEntity
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
		private string _sectionName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _sectionCode = String.Empty;
		///<summary>
		///
		///</summary>
		private int _sort;
		///<summary>
		///
		///</summary>
		private string _description = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public SectionEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public SectionEntity
		(
			int iD,
			int parentID,
			string name,
			string sectionCode,
			int sort,
			string description
		)
		{
			_iD          = iD;
			_parentID    = parentID;
			_sectionName        = name;
			_sectionCode = sectionCode;
			_sort        = sort;
			_description = description;
			
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
		public string SectionName
		{
			get {return _sectionName;}
			set {_sectionName = value;}
		}

		///<summary>
		///
		///</summary>
		public string SectionCode
		{
			get {return _sectionCode;}
			set {_sectionCode = value;}
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
		public string Description
		{
			get {return _description;}
			set {_description = value;}
		}
	
		#endregion
		
	}
}
