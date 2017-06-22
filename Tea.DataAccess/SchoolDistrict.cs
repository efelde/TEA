using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.DataAccess
{
    /// <summary>
    /// School district
    /// </summary>
    public class SchoolDistrict
    {
        private Int64 _LocationId;
        public Int64 LocationId
        {
            get
            {
                return _LocationId;
            }
            set
            {
                _LocationId = value;
            }
        }
        private string _DistrictNumber;
        public string DistrictNumber
        {
            get
            {
                return _DistrictNumber;
            }
            set
            {
                _DistrictNumber = value;
            }
        }
        private string _LocationName;
        public string LocationName
        {
            get
            {
                return _LocationName;
            }
            set
            {
                _LocationName = value;
            }
        }
        private string _Address;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        private string _City;
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        private string _State;
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }
        private string _Zip;
        public string Zip
        {
            get
            {
                return _Zip;
            }
            set
            {
                _Zip = value;
            }
        }
        private string _Phone;
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }
        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        private string _Website;
        public string Website
        {
            get
            {
                return _Website;
            }
            set
            {
                _Website = value;
            }
        }
        private string _JobPage;
        public string JobPage
        {
            get
            {
                return _JobPage;
            }
            set
            {
                _JobPage = value;
            }
        }
        private decimal _Latitude;
        public decimal Latitude
        {
            get
            {
                return _Latitude;
            }
            set
            {
                _Latitude = value;
            }
        }
        private decimal _Longitude;
        public decimal Longitude
        {
            get
            {
                return _Longitude;
            }
            set
            {
                _Longitude = value;
            }
        }
        private DateTime _LastUpdated;
        public DateTime LastUpdated
        {
            get
            {
                return _LastUpdated;
            }
            set
            {
                _LastUpdated = value;
            }
        }
    }
}
