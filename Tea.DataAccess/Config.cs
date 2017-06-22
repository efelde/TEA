using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Tea.DataAccess
{
    public class Config
    {
        #region Class Member Variables
        private static string _ConnectionString = "";
        private static bool _HasBeenInitialized = false;
        private static string _WebConfigString = "CommissionersDb";
        private static bool _UrlHasBeenInitialized = true;
        private static string _ReportsUrl = "";
        private static string _UrlString = "";
        #endregion

        #region Properties
        public static bool HasBeenInitialized
        {
            get
            {
                return _HasBeenInitialized;
            }
        }
        public static string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
        }
        public static string UrlString
        {
            get
            {
                return _UrlString;
            }
        }
        public static string WebConfigString
        {
            get
            {
                return _WebConfigString;
            }
            set
            {
                _WebConfigString = value;
            }
        }
        public static string ReportsUrl
        {
            get
            {
                return _ReportsUrl;
            }
            set
            {
                _ReportsUrl = value;
            }
        }
        #endregion

        #region Methods
        public Config()
        {
        }

        private static void Initialize(string WebConfigString)
        {
            AppSettingsReader webConfig = new AppSettingsReader();
            _ConnectionString = (string)webConfig.GetValue(WebConfigString, Type.GetType("System.String"));
            _HasBeenInitialized = true;
        }
        private static void InitializeUrl(string ReportsUrl)
        {
            AppSettingsReader reportsUrl = new AppSettingsReader();
            _UrlString = (string)reportsUrl.GetValue(ReportsUrl, Type.GetType("System.String"));
            _UrlHasBeenInitialized = true;
        }
        #endregion
    }
}
