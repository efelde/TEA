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
    public class HearingDa : DataAccessBase
    {
        #region Constructors
        public HearingDa(string cnString)
        {
            _ConnectionString = cnString;
        }

        public HearingDa()
        {
            //Add a connection string here
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// returns a Hearing obj by the docket_number
        /// </summary>
        /// <param name="docketNo"></param>
        /// <returns>Hearing obj</returns>
        public Hearing GetHearingByDocketNumber(string docketNo)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_By_Docket_Number") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@docket_no", SqlDbType.NVarChar).Value = docketNo;

                return GetHearing(cmd);
            }
        }

        public Hearing[] GetHearingsBetweenYears(int sYear, int eYear)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_Between_Years") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@open_year", SqlDbType.Int).Value = sYear;
                cmd.Parameters.Add("@closing_year", SqlDbType.Int).Value = eYear;

                return GetHearingArray(cmd);
            }
        }
        /// <summary>
        /// Gets an array of all the hearing officers listed in the database
        /// </summary>
        /// <returns>Array of strings</returns>
        public string[] GetAllHearingOfficers()
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_Hearing_Officers") { CommandType = CommandType.StoredProcedure })
            {
                return GetHearingOfficers(cmd);
            }
        }
        public Hearing[] GetAllHearings()
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All") { CommandType = CommandType.StoredProcedure })
            {
                return GetHearingArray(cmd);
            }
        }
        /// <summary>
        /// returns an array of hearings by officer and years
        /// </summary>
        /// <param name="hearingOfficer"></param>
        /// <param name="sYear"></param>
        /// <param name="eYear"></param>
        /// <returns>Hearing[]</returns>
        public Hearing[] GetHearingsByHearingOfficer(string hearingOfficer, int sYear, int eYear)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_By_Hearing_Officer") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@open_year", SqlDbType.Int).Value = sYear;
                cmd.Parameters.Add("@closing_year", SqlDbType.Int).Value = eYear;
                cmd.Parameters.Add("@hearing_officer", SqlDbType.NVarChar).Value = hearingOfficer;

                return GetHearingArray(cmd);
            }
        }
        /// <summary>
        /// First pass at the search term search, but it doesn't search the actual document
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="hearingOfficer"></param>
        /// <param name="sYear"></param>
        /// <param name="eYear"></param>
        /// <returns></returns>
        public Hearing[] GetHearingsBySearchTeam(string searchTerm, string hearingOfficer, int sYear, int eYear)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_By_Search_Term_Hearing_Officer") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@open_year", SqlDbType.Int).Value = sYear;
                cmd.Parameters.Add("@closing_year", SqlDbType.Int).Value = eYear;
                cmd.Parameters.Add("@hearing_officer", SqlDbType.NVarChar).Value = hearingOfficer;
                cmd.Parameters.Add("@search_term", SqlDbType.NVarChar).Value = searchTerm;

                return GetHearingArray(cmd);
            }
        }
        /// <summary>
        /// Returns an array of Hearings with the petitioner's name "like" the param
        /// </summary>
        /// <param name="petitioner"></param>
        /// <param name="sYear"></param>
        /// <param name="eYear"></param>
        /// <returns>An array of type Hearing</returns>
        public Hearing[] GetHearingsByPetitioner(string petitioner, int sYear, int eYear)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_By_Petitioner") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@open_year", SqlDbType.Int).Value = sYear;
                cmd.Parameters.Add("@closing_year", SqlDbType.Int).Value = eYear;
                cmd.Parameters.Add("@petitioner", SqlDbType.NVarChar).Value = petitioner;

                return GetHearingArray(cmd);
            }
        }
        /// <summary>
        /// returns an array of hearings with the respondent's name "like" the param
        /// </summary>
        /// <param name="respondent"></param>
        /// <param name="sYear"></param>
        /// <param name="eYear"></param>
        /// <returns></returns>
        public Hearing[] GetHearingsByRespondent(string respondent, int sYear, int eYear)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_By_Respondent") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@open_year", SqlDbType.Int).Value = sYear;
                cmd.Parameters.Add("@closing_year", SqlDbType.Int).Value = eYear;
                cmd.Parameters.Add("@respondent", SqlDbType.NVarChar).Value = respondent;

                return GetHearingArray(cmd);
            }
        }
        /// <summary>
        /// returns an array of hearings with the petitioner's and respondenet's
        /// name the same as the params
        /// </summary>
        /// <param name="petitioner"></param>
        /// <param name="respondent"></param>
        /// <param name="sYear"></param>
        /// <param name="eYear"></param>
        /// <returns>an array of type hearing</returns>
        public Hearing[] GetHearingsByPetitionerRespondent(string petitioner, string respondent, int sYear, int eYear)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_By_Petitioner_Respondent") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@open_year", SqlDbType.Int).Value = sYear;
                cmd.Parameters.Add("@closing_year", SqlDbType.Int).Value = eYear;
                cmd.Parameters.Add("@petitioner", SqlDbType.NVarChar).Value = petitioner;
                cmd.Parameters.Add("@respondent", SqlDbType.NVarChar).Value = respondent;

                return GetHearingArray(cmd);
            }
        }
        /// <summary>
        /// returns an array of hearings with the petitioner's and respondenet's
        /// name the same as the params and the match of the hearing officer's name
        /// </summary>
        /// <param name="hearingOfficer"></param>
        /// <param name="respondent"></param>
        /// <param name="petitioner"></param>
        /// <param name="sYear"></param>
        /// <param name="eYear"></param>
        /// <returns>an array of type hearing</returns>
        public Hearing[] GetHearingsByPetitionerRespondentHearingOfficer(string hearingOfficer, string respondent, string petitioner, int sYear, int eYear)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_By_Petitioner_Respondent_Hearing_Officer") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@open_year", SqlDbType.Int).Value = sYear;
                cmd.Parameters.Add("@closing_year", SqlDbType.Int).Value = eYear;
                cmd.Parameters.Add("@petitioner", SqlDbType.NVarChar).Value = petitioner;
                cmd.Parameters.Add("@respondent", SqlDbType.NVarChar).Value = respondent;
                cmd.Parameters.Add("@hearing_officer", SqlDbType.NVarChar).Value = hearingOfficer;

                return GetHearingArray(cmd);
            }
        }
        public Hearing[] GetHearingsByPetitionerHearingOfficer(string hearingOfficer, string petitioner, int sYear, int eYear)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_By_Petitioner_Hearing_Officer") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@open_year", SqlDbType.Int).Value = sYear;
                cmd.Parameters.Add("@closing_year", SqlDbType.Int).Value = eYear;
                cmd.Parameters.Add("@petitioner", SqlDbType.NVarChar).Value = petitioner;
                cmd.Parameters.Add("@hearing_officer", SqlDbType.NVarChar).Value = hearingOfficer;

                return GetHearingArray(cmd);
            }
        }
        public Hearing[] GetHearingsByRespondentHearingOfficer(string hearingOfficer, string respondent, int sYear, int eYear)
        {
            using (SqlCommand cmd = new SqlCommand("Hearing_Select_All_By_Respondent_Hearing_Officer") { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@open_year", SqlDbType.Int).Value = sYear;
                cmd.Parameters.Add("@closing_year", SqlDbType.Int).Value = eYear;
                cmd.Parameters.Add("@petitioner", SqlDbType.NVarChar).Value = respondent;
                cmd.Parameters.Add("@hearing_officer", SqlDbType.NVarChar).Value = hearingOfficer;

                return GetHearingArray(cmd);
            }
        }
        #endregion
        #region Private Methods

        private Hearing GetHearing(SqlCommand cmd)
        {
            Hearing hearing = null;
            SqlDataReader dr = GetReader(cmd);
            if (dr.Read())
            {
                hearing = new Hearing();
                hearing.ID = int.Parse(dr["ID"].ToString());
                hearing.DocketNumber = dr["docket_no"].ToString();
                hearing.Category = dr["category"].ToString();
                hearing.OpenMonth = dr["open_month"].ToString();
                hearing.OpenYear = dr["open_year"].ToString();
                hearing.Petitioner = dr["petitioner"].ToString();
                hearing.Respondent = dr["respondent"].ToString();
                hearing.HearingOfficer = dr["hearing_officer"].ToString();
                hearing.ClosingYear = dr["closing_year"].ToString();
                hearing.FileLocation = dr["file_location"].ToString();
                hearing.HearingType = dr["hearing_type"].ToString();
                hearing.LastUpdate = DateTime.Parse(dr["last_updated"].ToString());
            }
            dr.Close();

            return hearing;
        }

        private Hearing[] GetHearingArray(SqlCommand cmd)
        {
            ArrayList hearingArray = new ArrayList();

            SqlDataReader dr = null;

            try
            {
                dr = GetReader(cmd);
                while (dr.Read())
                {
                    Hearing hearing = new Hearing();
                    hearing.ID = int.Parse(dr["ID"].ToString());
                    hearing.DocketNumber = dr["docket_no"].ToString();
                    hearing.Category = dr["category"].ToString();
                    hearing.OpenMonth = dr["open_month"].ToString();
                    hearing.OpenYear = dr["open_year"].ToString();
                    hearing.Petitioner = dr["petitioner"].ToString();
                    hearing.Respondent = dr["respondent"].ToString();
                    hearing.HearingOfficer = dr["hearing_officer"].ToString();
                    hearing.ClosingYear = dr["closing_year"].ToString();
                    hearing.FileLocation = dr["file_location"].ToString();
                    hearing.HearingType = dr["hearing_type"].ToString();
                    hearing.LastUpdate = DateTime.Parse(dr["last_updated"].ToString());

                    hearingArray.Add(hearing);
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
            if (hearingArray.Count == 0)
            {
                return null;
            }
            else
            {
                return (Hearing[])hearingArray.ToArray(typeof(Hearing));
            }
        }

        private string[] GetHearingOfficers(SqlCommand cmd)
        {
            ArrayList hOfficerList = new ArrayList();

            SqlDataReader dr = null;

            try
            {
                dr = GetReader(cmd);
                while (dr.Read())
                {
                    string officer = "";
                    officer = dr["hearing_officer"].ToString();
                    hOfficerList.Add(officer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
            }
            if (hOfficerList.Count == 0)
            {
                return null;
            }
            else
            {
                return (string[])hOfficerList.ToArray(typeof(string));
            }
        }
        #endregion
    }
}
