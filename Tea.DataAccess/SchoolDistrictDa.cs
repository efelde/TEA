using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace Tea.DataAccess
{
    public class SchoolDistrictDa : DataAccessBase
    {
        #region Constructors
        public SchoolDistrictDa(string cnString)
        {
            _ConnectionString = cnString;
        }

        public SchoolDistrictDa()
        {
            //Add connection string here
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Uses stored proc
        /// </summary>
        /// <param name="id"></param>
        /// <returns>District objectd</returns>
        public SchoolDistrict GetDistrictById (Int64 id)
        {
            using (SqlCommand cmd = new SqlCommand("District_Select_By_LocationId") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = id;

                return GetDistrict(cmd);
            }
        }
        /// <summary>
        /// Get district by DistrictNumber with stored proc
        /// </summary>
        /// <param name="districtNumber"></param>
        /// <returns>District object</returns>
        public SchoolDistrict GetDistrictByDistrictNumber(string districtNumber)
        {
            using (SqlCommand cmd = new SqlCommand("District_Select_By_DistrictNumber") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@DistrictNumber", SqlDbType.NVarChar).Value = districtNumber;

                return GetDistrict(cmd);
            }
        }
        /// <summary>
        /// Gets all districts with a stored proc
        /// </summary>
        /// <returns>Array of District objects</returns>
        public SchoolDistrict[] GetAllDistricts()
        {
            SqlCommand cmd = new SqlCommand("District_Select_All");
            cmd.CommandType = CommandType.StoredProcedure;

            return GetDistrictArray(cmd);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Data access method for single District
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>District object</returns>
        private SchoolDistrict GetDistrict(SqlCommand cmd)
        {
            SchoolDistrict district = null;
            SqlDataReader dr = GetReader(cmd);
            decimal loResult = 0, laResult = 0;
            if (dr.Read())
            {
                if (!(decimal.TryParse(dr["Latitude"].ToString(), out laResult)))
                {
                    laResult = 0;
                }
                if (!(decimal.TryParse(dr["Longitude"].ToString(), out loResult)))
                {
                    loResult = 0;
                }
                district = new SchoolDistrict();
                district.LocationId = Int64.Parse(dr["LocationId"].ToString());
                district.DistrictNumber = dr["DistrictNumber"].ToString();
                district.LocationName = dr["LocationName"].ToString();
                district.Address = dr["Address"].ToString();
                district.City = dr["City"].ToString();
                district.State = dr["State"].ToString();
                district.Zip = dr["Zip"].ToString();
                district.Phone = dr["Phone"].ToString();
                district.Email = dr["Email"].ToString();
                district.Website = dr["Website"].ToString();
                district.JobPage = dr["JobPage"].ToString();
                district.Latitude = laResult;
                district.Longitude = loResult;
                district.LastUpdated = DateTime.Parse(dr["LastUpdated"].ToString());
            }
            dr.Close();
            return district;
        }
        /// <summary>
        /// data access method for multiple District objects
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>An array of District objects</returns>
        private SchoolDistrict[] GetDistrictArray(SqlCommand cmd)
        {
            ArrayList districtArray = new ArrayList();
            SqlDataReader dr = null;
            try
            {
                dr = GetReader(cmd);
                while (dr.Read())
                {
                    decimal laResult, loResult = 0;
                    if (!(decimal.TryParse(dr["Latitude"].ToString(), out laResult)))
                    {
                        laResult = 0;
                    }
                    if (!(decimal.TryParse(dr["Longitude"].ToString(), out loResult)))
                    {
                        loResult = 0;
                    }


                    //if (decimal.TryParse(dr["Latitude"].ToString(), out laResult) && decimal.TryParse(dr["Longitude"].ToString(), out loResult))
                    //{
                        SchoolDistrict district = new SchoolDistrict();
                        district.LocationId = Int64.Parse(dr["LocationId"].ToString());
                        district.DistrictNumber = dr["DistrictNumber"].ToString();
                        district.LocationName = dr["LocationName"].ToString();
                        district.Address = dr["Address"].ToString();
                        district.City = dr["City"].ToString();
                        district.State = dr["State"].ToString();
                        district.Zip = dr["Zip"].ToString();
                        district.Phone = dr["Phone"].ToString();
                        district.Email = dr["Email"].ToString();
                        district.Website = dr["Website"].ToString();
                        district.JobPage = dr["JobPage"].ToString();
                        district.Latitude = laResult;
                        district.Longitude = loResult;
                        district.LastUpdated = DateTime.Parse(dr["LastUpdated"].ToString());

                        districtArray.Add(district);
                    //}
                }
            }
            catch (Exception ex)
            {
                string filePath = @"D:\Websites92\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message: " + ex.Message + "<br/>" + Environment.NewLine + "StackTrace: " + ex.StackTrace);
                    if (ex.InnerException != null)
                    {
                        writer.WriteLine(ex.InnerException.Message);
                    }
                    else
                    {
                        writer.WriteLine("No inner exception");
                    }
                }
            }
            finally
            {
                dr.Close();
            }
            if (districtArray.Count == 0)
            {
                return null;
            }
            else
            {
                return (SchoolDistrict[])districtArray.ToArray(typeof(SchoolDistrict));
            }
        }
        #endregion
    }
}
