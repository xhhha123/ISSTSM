using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISSTSM.Entity
{
    [Serializable]
    public class IncidentUIEntity
    {
        
		#region 变量定义
		
		private int _iD;
		private string _incidentNumber = String.Empty;
		private int _assignedTo;
		private int _reportedBy;
		private int _dicPriority;
		private int _dicCountry;
		private int _dicProduct;
		private int _dicStatus;
		private DateTime _createDate;
		private string _statusFollowUp = String.Empty;
		private string _summary = String.Empty;
		private string _description = String.Empty;

        private string _assignedToName = string.Empty; 
        private string _reportedByName = string.Empty;
        private string _dicPriotityName = string.Empty;
        private string _dicCountryName = string.Empty;
        private string _dicProductName = string.Empty;
        private string _dicStatusName = string.Empty;

		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public IncidentUIEntity()
		{
		}
		#endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string IncidentNumber
        {
            get { return _incidentNumber; }
            set { _incidentNumber = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int AssignedTo
        {
            get { return _assignedTo; }
            set { _assignedTo = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int ReportedBy
        {
            get { return _reportedBy; }
            set { _reportedBy = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicPriority
        {
            get { return _dicPriority; }
            set { _dicPriority = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicCountry
        {
            get { return _dicCountry; }
            set { _dicCountry = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicProduct
        {
            get { return _dicProduct; }
            set { _dicProduct = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicStatus
        {
            get { return _dicStatus; }
            set { _dicStatus = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string StatusFollowUp
        {
            get { return _statusFollowUp; }
            set { _statusFollowUp = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        ///<summary>
        ///
        ///</summary>
        public string AssignedToName
        {
            get { return _assignedToName; }
            set { _assignedToName = value; }
        }
        ///<summary>
        ///
        ///</summary>
        public string ReportedByName
        {
            get { return _reportedByName; }
            set { _reportedByName = value; }
        }
        ///<summary>
        ///
        ///</summary>
        public string DicPriotityName
        {
            get { return _dicPriotityName; }
            set { _dicPriotityName = value; }
        }
        ///<summary>
        ///
        ///</summary>
        public string DicCountryName
        {
            get { return _dicCountryName; }
            set { _dicCountryName = value; }
        }
        ///<summary>
        ///
        ///</summary>
        public string DicProductName
        {
            get { return _dicProductName; }
            set { _dicProductName = value; }
        }
        ///<summary>
        ///
        ///</summary>
        public string DicStatusName
        {
            get { return _dicStatusName; }
            set { _dicStatusName = value; }
        }
        #endregion
		
    }
}
