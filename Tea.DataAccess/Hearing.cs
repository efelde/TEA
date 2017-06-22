using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.DataAccess
{
    public class Hearing : DataAccessBase
    {
        private Int64 _ID;
        public Int64 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID =  value;
            }
        }
        private string _DocketNumber;
        public string DocketNumber
        {
            get
            {
                return _DocketNumber;
            }
            set
            {
                _DocketNumber = value;
            }
        }
        private string _Category;
        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }
        private string _OpenMonth;
        public string OpenMonth
        {
            get
            {
                return _OpenMonth;
            }
            set
            {
                _OpenMonth = value;
            }
        }
        private string _OpenYear;
        public string OpenYear
        {
            get
            {
                return _OpenYear;
            }
            set
            {
                _OpenYear = value;
            }
        }
        private string _Petitioner;
        public string Petitioner
        {
            get
            {
                return _Petitioner;
            }
            set
            {
                _Petitioner = value;
            }
        }
        private string _Respondent;
        public string Respondent
        {
            get
            {
                return _Respondent;
            }
            set
            {
                _Respondent = value;
            }
        }
        private string _HearingOfficer;
        public string HearingOfficer
        {
            get
            {
                return _HearingOfficer;
            }
            set
            {
                _HearingOfficer = value;
            }
        }
        private string _ClosingYear;
        public string ClosingYear
        {
            get
            {
                return _ClosingYear;
            }
            set
            {
                _ClosingYear = value;
            }
        }
        private string _FileLocation;
        public string FileLocation
        {
            get
            {
                return _FileLocation;
            }
            set
            {
                _FileLocation = value;
            }
        }
        private string _HearingType;
        public string HearingType
        {
            get
            {
                return _HearingType;
            }
            set
            {
                _HearingType = value;
            }
        }
        private DateTime _LastUpdate;
        public DateTime LastUpdate
        {
            get
            {
                return _LastUpdate;
            }
            set
            {
                _LastUpdate = value;
            }
        }

    }
}
