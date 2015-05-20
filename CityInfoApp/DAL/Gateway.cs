using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityInfoApp.Model;

namespace CityInfoApp.DAL
{
    class Gateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionDb"].ConnectionString;

        public int Save(City aCity)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Table_City VALUES('" + aCity.CityName + "','" + aCity.About + "','" +
                           aCity.Country + "')";

            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public bool IsCityNameExist(string name)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            string query = "SELECT CityName FROM Table_City WHERE CityName='" + name + "'";

            bool isCityNameExists = false;
            SqlCommand command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                isCityNameExists = true;
                break;
            }
            reader.Close();
            Connection.Close();

            return isCityNameExists;
        }

        public List<City> LoadCityInfo()
        {
            List<City> newCityList = new List<City>();

            SqlConnection Connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Table_City";
            SqlCommand command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                City cityInfo = new City();
                cityInfo.CityName = reader[1].ToString();
                cityInfo.About = reader[2].ToString();
                cityInfo.Country = reader[3].ToString();

                newCityList.Add(cityInfo);
            }
            reader.Close();
            Connection.Close();
            return newCityList;


        } 
    }
}
