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



        public void DoWork()
        {

        }

        public Shipper GetShipperByID(int Id)
        {


            string queryString = "SELECT[ShipperID] ,[CompanyName] ,[Phone] FROM[NORTHWND].[dbo].[Shippers]" +
                                 "WHERE[ShipperID] =" + Id;
            var shipper = new Shipper();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shipper.ShipperID = Convert.ToInt32(reader["ShipperID"].ToString());
                        shipper.CompanyName = reader["CompanyName"].ToString();
                        shipper.Phone = (reader["Phone"].ToString());
                    }
                }

                return shipper;
            }
        }



        public Shipper SetAShipper(int shipperID, string companyName, int phone)
        {
            throw new NotImplementedException();
        }
    }
}
