using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISSTSM.Entity
{
    [Serializable]
    public class UserInfoUIEntity
    {
              #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private int _iD;
        ///<summary>
        ///
        ///</summary>
        private string _userName = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _realName = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private int _sectionID;
        ///<summary>
        ///
        ///</summary>
        private string _telephone = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _pwd = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _qQ = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _photopath = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _email = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private int _dicSex;
        ///<summary>
        ///
        ///</summary>
        private int _dicAddress;
        ///<summary>
        ///
        ///</summary>
        private int _dicStatus;
        ///<summary>
        ///
        ///</summary>
        private string _sectionName = String.Empty;
 
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public UserInfoUIEntity()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public UserInfoUIEntity
        (
            int iD,
            string userName,
            string realName,
            int sectionID,
            string telephone,
            string pwd,
            string qQ,
            string photopath,
            string email,
            int dicSex,
            int dicAddress,
            int dicStatus,
            string sectionName
        )
        {
            _iD = iD;
            _userName = userName;
            _realName = realName;
            _sectionID = sectionID;
            _telephone = telephone;
            _pwd = pwd;
            _qQ = qQ;
            _photopath = photopath;
            _email = email;
            _dicSex = dicSex;
            _dicAddress = dicAddress;
            _dicStatus = dicStatus;
            _sectionName = sectionName;

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
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int SectionID
        {
            get { return _sectionID; }
            set { _sectionID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string QQ
        {
            get { return _qQ; }
            set { _qQ = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Photopath
        {
            get { return _photopath; }
            set { _photopath = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicSex
        {
            get { return _dicSex; }
            set { _dicSex = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicAddress
        {
            get { return _dicAddress; }
            set { _dicAddress = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int DicStatus
        {
            get { return _dicStatus; }
            set { _dicStatus = value; }
        }
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }
        #endregion

    }
}
