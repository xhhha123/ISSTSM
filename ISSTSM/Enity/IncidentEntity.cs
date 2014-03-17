// =================================================================== 
// 项目说明
//====================================================================
// 文件： Incident.cs
// 项目名称：SunCity_MS 
// 创建时间：2014/1/9
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
/// <summary>
	///Incident数据实体
	/// </summary>
	[Serializable]
	public class IncidentEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _incidentNumber = String.Empty;
		///<summary>
		///
		///</summary>
		private int _assignedTo;
		///<summary>
		///
		///</summary>
		private int _reportedBy;
		///<summary>
		///
		///</summary>
		private int _dicPriority;
		///<summary>
		///
		///</summary>
		private int _dicCountry;
		///<summary>
		///
		///</summary>
		private int _dicProduct;
		///<summary>
		///
		///</summary>
		private int _dicStatus;
		///<summary>
		///
		///</summary>
		private DateTime _createDate;
		///<summary>
		///
		///</summary>
		private string _statusFollowUp = String.Empty;
		///<summary>
		///
		///</summary>
		private string _summary = String.Empty;
		///<summary>
		///
		///</summary>
		private string _description = String.Empty;
		///<summary>
		///0:未填写Timesheet 1 ：已经填写
		///</summary>
		private int _isFill;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public IncidentEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public IncidentEntity
		(
			int iD,
			string incidentNumber,
			int assignedTo,
			int reportedBy,
			int dicPriority,
			int dicCountry,
			int dicProduct,
			int dicStatus,
			DateTime createDate,
			string statusFollowUp,
			string summary,
			string description,
			int isFill
		)
		{
			_iD             = iD;
			_incidentNumber = incidentNumber;
			_assignedTo     = assignedTo;
			_reportedBy     = reportedBy;
			_dicPriority    = dicPriority;
			_dicCountry     = dicCountry;
			_dicProduct     = dicProduct;
			_dicStatus      = dicStatus;
			_createDate     = createDate;
			_statusFollowUp = statusFollowUp;
			_summary        = summary;
			_description    = description;
			_isFill         = isFill;
			
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
		public string IncidentNumber
		{
			get {return _incidentNumber;}
			set {_incidentNumber = value;}
		}

		///<summary>
		///
		///</summary>
		public int AssignedTo
		{
			get {return _assignedTo;}
			set {_assignedTo = value;}
		}

		///<summary>
		///
		///</summary>
		public int ReportedBy
		{
			get {return _reportedBy;}
			set {_reportedBy = value;}
		}

		///<summary>
		///
		///</summary>
		public int DicPriority
		{
			get {return _dicPriority;}
			set {_dicPriority = value;}
		}

		///<summary>
		///
		///</summary>
		public int DicCountry
		{
			get {return _dicCountry;}
			set {_dicCountry = value;}
		}

		///<summary>
		///
		///</summary>
		public int DicProduct
		{
			get {return _dicProduct;}
			set {_dicProduct = value;}
		}

		///<summary>
		///
		///</summary>
		public int DicStatus
		{
			get {return _dicStatus;}
			set {_dicStatus = value;}
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
		public string StatusFollowUp
		{
			get {return _statusFollowUp;}
			set {_statusFollowUp = value;}
		}

		///<summary>
		///
		///</summary>
		public string Summary
		{
			get {return _summary;}
			set {_summary = value;}
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
		///0:未填写Timesheet 1 ：已经填写
		///</summary>
		public int IsFill
		{
			get {return _isFill;}
			set {_isFill = value;}
		}
	
		#endregion
		
	}
    
}
