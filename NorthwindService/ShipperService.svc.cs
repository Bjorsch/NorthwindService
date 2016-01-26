using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NorthwindService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShipperService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ShipperService.svc or ShipperService.svc.cs at the Solution Explorer and start debugging.
    public class ShipperService : IShipperService
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["theDB"].ToString();
        
        public Shipper GetShipperByID(int shipperId)
        {
            string query = "SELECT[ShipperID] ,[CompanyName] ,[Phone] FROM[NORTHWND].[dbo].[Shippers]" +
                                 "WHERE[ShipperID] =" + shipperId; //Vill bara hämta med rätt id
            var shipper = new Shipper();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    shipper.ShipperID = Convert.ToInt32(reader["ShipperID"].ToString());
                    shipper.CompanyName = reader["CompanyName"].ToString();
                    shipper.Phone = reader["Phone"].ToString();
                }
            }
            return shipper;
        }

        public int UpdateShipper(int shipperID, string companyName, string phone)
        {
            string query = "UPDATE [NORTHWND].[dbo].[Shippers] SET " +
                           " companyName = @CompanyName," +
                           " phone = @Phone" + 
                           " WHERE shipperID = @ShipperID";            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                SqlParameter paramShipperID = new SqlParameter("@ShipperID", shipperID);
                command.Parameters.Add(paramShipperID);

                SqlParameter paramCompanyName = new SqlParameter("@CompanyName", companyName);
                command.Parameters.Add(paramCompanyName);

                SqlParameter paramPhone = new SqlParameter("@Phone", phone);
                command.Parameters.Add(paramPhone);

                connection.Open();
                return command.ExecuteNonQuery();
            }             
        }
    }
}
