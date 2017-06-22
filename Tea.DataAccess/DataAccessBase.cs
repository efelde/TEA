using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Tea.DataAccess
{
    public abstract class DataAccessBase
    {
        protected string _ConnectionString = "";
        ///<summary>
        ///The Database connection string
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        protected string _ErrorMessage = "";
        ///<summary>
        ///the last error that occured connecting to a datasource
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                _ErrorMessage = value;
            }
        }
        /// <summary>
        /// Generic method for getting a SqlDataReader.
        /// </summary>
        /// <param name="cmd">The SqlCommand used to get the Datareader.</param>
        /// <returns>SqlDataReader or Null if error (read ErrorMessage Property).</returns>
        protected SqlDataReader GetReader(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(this._ConnectionString);
            cmd.Connection = conn;
            SqlDataReader dr = null;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                _ErrorMessage = ex.Message;
            }
            return dr;
        }

        /// <summary>
        /// Executes a SqlCommand to return and integer
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>0 if the connection fails </returns>
        protected int GetScalarInt(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            cmd.Connection = conn;
            int rtnValue = 0;

            try
            {
                conn.Open();
                rtnValue = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _ErrorMessage = ex.Message;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
            }

            return rtnValue;
        }

        /// <summary>
        /// Executes a SqlCommand that doesn't return data
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>-2 = error; successful retuns the number of rows affected; -1 if rollback occurs or it's a select command</returns>
        protected int ExecuteNonQuery(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(this._ConnectionString);
            cmd.Connection = conn;
            int rtnValue = -2;

            try
            {
                conn.Open();
                rtnValue = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _ErrorMessage = ex.Message;
                return rtnValue;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
            }
            return rtnValue;
        }

        /// <summary>
        /// Converts DATETIME to a nullable DB datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Datetime object OR null if var date = DateTime.MinValue</returns>
        protected object DbDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return null;
            }
            else
            {
                return date;
            }
        }

        /// <summary>
        /// Converts int that is 0 to a null value
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Int or Null if i is zero</returns>
        protected object ZeroIsNull(int i)
        {
            if (i == 0)
            {
                return null;
            }
            else
            {
                return i;
            }
        }

        /// <summary>
        /// Converts an empty GUID to a nullable DB uniqueidentifier 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        protected object EmptyIsNull(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                return null;
            }
            else
            {
                return guid;
            }
        }

        /// <summary>
        /// converts a nullable db datetime to DateTime object
        /// </summary>
        /// <param name="date"></param>
        /// <returns>the DateTime or the DateTime.MinValue if date can't be converted</returns>
        protected DateTime ParseDate(string date)
        {
            DateTime aDate;
            DateTime.TryParse(date, out aDate);
            return aDate;
        }

        /// <summary>
        /// converts a nullable db uniqueidentifier to GUID
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>New Guid or Guid.Empty if the var guid.length is 0</returns>
        protected Guid ParseGuid(string guid)
        {
            if (guid.Length == 0)
            {
                return Guid.Empty;
            }
            else
            {
                return new Guid(guid);
            }
        }

        /// <summary>
        /// Converts nullable db int to INT
        /// </summary>
        /// <param name="i"></param>
        /// <returns>the INT represented by i or zero if the parse fails</returns>
        protected int ParseInt(string i)
        {
            int pInt;
            int.TryParse(i, out pInt);
            return pInt;
        }

        /// <summary>
        /// Converts nullable db float to FLOAT
        /// </summary>
        /// <param name="f"></param>
        /// <returns>f as a FLOAT or 0 if the parse fails</returns>
        protected float ParseFloat(string f)
        {
            float pFloat;
            float.TryParse(f, out pFloat);
            return pFloat;
        }
    }
}
