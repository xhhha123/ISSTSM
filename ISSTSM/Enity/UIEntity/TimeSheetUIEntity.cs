using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISSTSM.Entity
{
     [Serializable]
    public class TimeSheetUIEntity
    {
                 #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private int _iD;

        ///<summary>
        ///
        ///</summary>
        private DateTime _date;
        ///<summary>
        ///
        ///</summary>
        private float _billableHour;

        private string _subProject = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _tasks = String.Empty;
         //自定义的属性，方便在UI层展示数据 
        ///<summary>
        ///
        ///</summary>
        private string _incidentName = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _userName= String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _dicTitleName = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _dicProjectName = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _dicGroupName = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _dicTypeName = String.Empty;

        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public TimeSheetUIEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public TimeSheetUIEntity
        (
            int iD,

            DateTime date,
            float billableHour,

            string subProject,
            string tasks,

            //自定义属性
            string incidentName,
            string userName,
            string dicTitleName,
            string dicProjectName,
            string dicGroupName,
            string dicTypeName
        )
        {
            _iD = iD;
            _subProject = subProject;
            _tasks = tasks;
            _incidentName = incidentName;
            _userName = userName;
            _dicTitleName = dicTitleName;
            _dicProjectName = dicProjectName;
            _dicGroupName = dicGroupName;
            _dicTypeName = dicTypeName;

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
         //自定义属性

        ///<summary>
        ///
        ///</summary>
        public string IncidentName
        {
            get { return _incidentName; }
            set { _incidentName = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }        ///<summary>
        ///
        ///</summary>
        public string DicTitleName
        {
            get { return _dicTitleName; }
            set { _dicTitleName = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string DicProjectName
        {
            get { return _dicProjectName; }
            set { _dicProjectName = value; }
        }        ///<summary>
        ///
        ///</summary>
        public string DicGroupName
        {
            get { return _dicGroupName; }
            set { _dicGroupName = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string DicTypeName
        {
            get { return _dicTypeName; }
            set { _dicTypeName = value; }
        }

        #endregion
    }
}
