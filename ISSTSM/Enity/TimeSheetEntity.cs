// =================================================================== 
// 项目说明
//====================================================================
// 文件： TimeSheet.cs
// 项目名称：SunCity_MS 
// 创建时间：2013/12/16
// 负责人：xhh
// ===================================================================
using System;
namespace ISSTSM.Entity
{
    /// <summary>
    ///TimeSheet数据实体
    /// </summary>
    [Serializable]
    public class TimeSheetEntity
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private int _iD;
        ///<summary>
        ///
        ///</summary>
        private int _incidentID;
        ///<summary>
        ///
        ///</summary>
        private DateTime _date;
        ///<summary>
        ///
        ///</summary>
        private float _billableHour;
        ///<summary>
        ///UserInfo对应的ID
        ///</summary>
        private int _userID;
        ///<summary>
        ///
        ///</summary>
        private int _dicTitle;
        ///<summary>
        ///
        ///</summary>
        private int _dicProject;
        ///<summary>
        ///
        ///</summary>
        private int _dicGroup;
        ///<summary>
        ///
        ///</summary>
        private int _dicType;
        ///<summary>
        ///
        ///</summary>
        private string _subProject = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _tasks = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public TimeSheetEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public TimeSheetEntity
        (
            int iD,
            int incidentID,
            DateTime date,
            float billableHour,
            int userID,
            int dicTitle,
            int dicProject,
            int dicGroup,
            int dicType,
            string subProject,
            string tasks
        )
        {
            _iD = iD;
            _incidentID = incidentID;
            _date = date;
            _billableHour = billableHour;
            _userID = userID;
            _dicTitle = dicTitle;
            _dicProject = dicProject;
            _dicGroup = dicGroup;
            _dicType = dicType;
            _subProject = subProject;
            _tasks = tasks;

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
        public int IncidentID
        {
            get { return _incidentID; }
            set { _incidentID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public float BillableHour
        {
            get { return _billableHour; }
            set { _billableHour = value; }
        }

        ///<summary>
        ///UserInfo对应的ID
        ///</summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicTitle
        {
            get { return _dicTitle; }
            set { _dicTitle = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicProject
        {
            get { return _dicProject; }
            set { _dicProject = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicGroup
        {
            get { return _dicGroup; }
            set { _dicGroup = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicType
        {
            get { return _dicType; }
            set { _dicType = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string SubProject
        {
            get { return _subProject; }
            set { _subProject = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        #endregion

    }
}

