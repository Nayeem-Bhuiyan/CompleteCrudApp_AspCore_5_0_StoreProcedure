using Microsoft.Data.SqlClient;
using StoreProceDureCrud.Areas.ProfileArea.Models;
using StoreProceDureCrud.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProceDureCrud.Service.ProfileService
{
    public class ProfileService
    {

        string connectionString = "Data Source=NAYEEM\\SQLEXPRESS;Initial Catalog=ProfileDB;Integrated Security=True";

        //To View all Profiles details    

        #region Crud Service
        public IEnumerable<ProfileViewModel> GetProfilesList()

        {
            List<ProfileViewModel> lstProfile = new List<ProfileViewModel>();
   

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_GetAllProfiles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    ProfileViewModel Profile = new ProfileViewModel();

                    Profile.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    Profile.Name = rdr["Name"].ToString();
                    Profile.GenderId = Convert.ToInt32(rdr["GenderId"]);
                    Profile.genderName = rdr["GenderName"].ToString();
                    Profile.CityId = Convert.ToInt32(rdr["CityId"]);
                    Profile.cityName =rdr["CityName"].ToString();
                    Profile.countryName = rdr["CountryName"].ToString();
                    Profile.contact = rdr["contact"].ToString();
                    Profile.email = rdr["email"].ToString();
                    Profile.ProfileImage = rdr["ProfileImage"].ToString();
                    Profile.websiteLink = rdr["websiteLink"].ToString();
                    Profile.dateOfBirth = Convert.ToDateTime(rdr["dateOfBirth"]);
                    Profile.Remarks = rdr["Remarks"].ToString();
                    Profile.Password = rdr["Password"].ToString();

                    List<Hobby> lstHobby = new List<Hobby>();
                    using (SqlConnection con2 = new SqlConnection(connectionString))
                    {
                        
                        SqlCommand cmd2 = new SqlCommand("Sp_GetMyFavouriteHobbies", con2);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@ProfileId", Convert.ToInt32(rdr["ProfileId"]));

                        con2.Open();
                        SqlDataReader rdr2 = cmd2.ExecuteReader();

                        while (rdr2.Read())
                        {
                            Hobby hb = new Hobby();
                            hb.HobbyId = Convert.ToInt32(rdr2["HobbyId"]);
                            hb.HobbyName = rdr2["HobbyName"].ToString();
                            lstHobby.Add(hb);
                        }



                    }

                   
                    Profile.Hobbies = lstHobby;
                    lstProfile.Add(Profile);
                }
               
                con.Close();
            }
            return lstProfile;
        }
        public IEnumerable<Profile> GetAllProfiles()
        
        {
            List<Profile> lstProfile = new List<Profile>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Crud_Profiles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
               
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Profile Profile = new Profile();

                    Profile.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    Profile.Name = rdr["Name"].ToString();
                    Profile.GenderId = Convert.ToInt32(rdr["GenderId"]);
                    Profile.CityId = Convert.ToInt32(rdr["CityId"]);
                    Profile.contact = rdr["contact"].ToString();
                    Profile.email = rdr["email"].ToString();
                    Profile.ProfileImage = rdr["ProfileImage"].ToString();
                    Profile.websiteLink = rdr["websiteLink"].ToString();
                    Profile.dateOfBirth =Convert.ToDateTime(rdr["dateOfBirth"]);
                    Profile.Remarks = rdr["Remarks"].ToString();
                    Profile.Password = rdr["Password"].ToString();

                    lstProfile.Add(Profile);
                }
                con.Close();
            }
            return lstProfile;
        }

        //To Add new Profile record    
        public void AddProfile(Profile Profile)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Crud_Profiles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Insert");
                cmd.Parameters.AddWithValue("@ProfileId", Profile.ProfileId);
                cmd.Parameters.AddWithValue("@Name", Profile.Name);
                cmd.Parameters.AddWithValue("@GenderId", Profile.GenderId);
                cmd.Parameters.AddWithValue("@CityId", Profile.CityId);
                cmd.Parameters.AddWithValue("@contact", Profile.contact);
                cmd.Parameters.AddWithValue("@email", Profile.email);
                cmd.Parameters.AddWithValue("@ProfileImage", Profile.ProfileImage);
                cmd.Parameters.AddWithValue("@websiteLink", Profile.websiteLink);
                cmd.Parameters.AddWithValue("@dateOfBirth", Profile.dateOfBirth);
                cmd.Parameters.AddWithValue("@Remarks", Profile.Remarks);
                cmd.Parameters.AddWithValue("@Password", Profile.Password);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar Profile  
        public void UpdateProfile(Profile Profile)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Crud_Profiles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Update");
                cmd.Parameters.AddWithValue("@ProfileId", Profile.ProfileId);
                cmd.Parameters.AddWithValue("@Name", Profile.Name);
                cmd.Parameters.AddWithValue("@GenderId", Profile.GenderId);
                cmd.Parameters.AddWithValue("@CityId", Profile.CityId);
                cmd.Parameters.AddWithValue("@contact", Profile.contact);
                cmd.Parameters.AddWithValue("@email", Profile.email);
                cmd.Parameters.AddWithValue("@ProfileImage", Profile.ProfileImage);
                cmd.Parameters.AddWithValue("@websiteLink", Profile.websiteLink);
                cmd.Parameters.AddWithValue("@dateOfBirth", Profile.dateOfBirth);
                cmd.Parameters.AddWithValue("@Remarks", Profile.Remarks);
                cmd.Parameters.AddWithValue("@Password", Profile.Password);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular Profile  
        public Profile GetProfileData(int? id)
        {
            Profile Profile = new Profile();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Crud_Profiles", con);
                cmd.Parameters.AddWithValue("@StatementType", "SelectById");
                cmd.Parameters.AddWithValue("@ProfileId", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Profile.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    Profile.Name = rdr["Name"].ToString();
                    Profile.GenderId = Convert.ToInt32(rdr["GenderId"]);
                    Profile.CityId = Convert.ToInt32(rdr["CityId"]);
                    Profile.contact = rdr["contact"].ToString();
                    Profile.email = rdr["email"].ToString();
                    Profile.ProfileImage = rdr["ProfileImage"].ToString();
                    Profile.websiteLink = rdr["websiteLink"].ToString();
                    Profile.dateOfBirth = Convert.ToDateTime(rdr["dateOfBirth"]);
                    Profile.Remarks = rdr["Remarks"].ToString();
                    Profile.Password = rdr["Password"].ToString();
                }
                con.Close();
            }
            return Profile;
        }

        //To Delete the record on a particular Profile  
        public void DeleteProfile(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_Crud_Profiles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Delete");
                cmd.Parameters.AddWithValue("@ProfileId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        #endregion

        #region DropDownnLoadService
        public IEnumerable<Country> GetAllCountries()
        {
            List<Country> lstCountry = new List<Country>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_LoadAllCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Country countryObj = new Country();

                    countryObj.CountryID = Convert.ToInt32(rdr["CountryID"]);
                    countryObj.CountryName = rdr["CountryName"].ToString();
           

                    lstCountry.Add(countryObj);
                }
                con.Close();
            }
            return lstCountry;
        }
        public IEnumerable<Gender> GetAllGender()
        {
            List<Gender> lstGender = new List<Gender>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_LoadAllGender", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Gender GenderObj = new Gender();
                    GenderObj.GenderId = Convert.ToInt32(rdr["GenderId"]);
                    GenderObj.GenderName = rdr["GenderName"].ToString();
                    lstGender.Add(GenderObj);
                }
                con.Close();
            }
            return lstGender;
        }
        public IEnumerable<Hobby> GetAllHobby()
        {
            List<Hobby> lstHobby = new List<Hobby>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_LoadAllHobby", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Hobby HobbyObj = new Hobby();
                    HobbyObj.HobbyId = Convert.ToInt32(rdr["HobbyId"]);
                    HobbyObj.HobbyName = rdr["HobbyName"].ToString();
                    lstHobby.Add(HobbyObj);
                }
                con.Close();
            }
            return lstHobby;
        }
        public IEnumerable<City> GetAllCityByCountry(int countryId)
        {
            List<City> lstCity = new List<City>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_LoadAllCityByCountryId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@countryId", countryId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    City CityObj = new City();
                    CityObj.CityId = Convert.ToInt32(rdr["CityId"]);
                    CityObj.CityName = rdr["CityName"].ToString();
                    CityObj.CountryID = Convert.ToInt32(rdr["CountryID"]); ;
                    lstCity.Add(CityObj);
                }
                con.Close();
            }
            return lstCity;
        }
        public IEnumerable<Hobby> GetAllHobbyByCountry(int profileId)
        {
            List<Hobby> lstHobby = new List<Hobby>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_LoadAllFavoriteHobbyByProfileId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@profileId", profileId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Hobby HobbyObj = new Hobby();
                    HobbyObj.HobbyId = Convert.ToInt32(rdr["HobbyId"]);
                    HobbyObj.HobbyName = rdr["HobbyName"].ToString();
                    lstHobby.Add(HobbyObj);
                }
                con.Close();
            }
            return lstHobby;
        }


        #endregion
    }
}
