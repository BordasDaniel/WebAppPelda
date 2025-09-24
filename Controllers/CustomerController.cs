using MySql.Data.MySqlClient;
using WebAppPelda.Models;

namespace WebAppPelda.Controllers
{
    public class CustomerController
    {
        static MySqlConnection SQLConnection;

        private static void BuildConnection()
        {
            string connectionString = "Server = localhost;Database=uzlet;Uid=root;Password=;";
            SQLConnection = new MySqlConnection(connectionString);
        }

        public List<Customer> GetCustomerFromDatabase()
        {
            BuildConnection();
            List<Customer> customers = new List<Customer>();
            try
            {
                SQLConnection.Open();
                string sql = "SELECT * from customer";
                MySqlCommand mySqlCommand = new(sql, SQLConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
               
                while (mySqlDataReader.Read())
                {
                    customers.Add(new Customer()
                    {
                        Id = mySqlDataReader.GetInt32("id"),
                        Name = mySqlDataReader.GetString("name"),
                        Phone = mySqlDataReader.GetString("phone"),
                        Score = mySqlDataReader.GetInt32("score")
                    });
                }
                SQLConnection.Close();
                
            } catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: {0}", ex);
            }
            return customers;

        }


        //public List<Customer> GetCustomersFromFile()
        //{
        //    //return new List<Customer>()
        //    //{
        //    //    new Customer { Id = 1, Name = "asdasd", Phone = "1231-31231", Score = 90 },
        //    //    new Customer { Id = 2, Name = "saiujfhsdkfdjk", Phone = "7456164648", Score = 0 },
        //    //    new Customer { Id = 3, Name = "defmk,l.é", Phone = "484866889468", Score = 231 }
        //    //};

        //    List<Customer> list = new List<Customer>();
        //    string[] lines = File.ReadAllLines("CustomerDatas.txt").Skip(1).ToArray();
        //    foreach (string line in lines)
        //    {
        //        string[] reszek = line.Split(';');
        //        list.Add(new Customer
        //        {
        //            Id = int.Parse(reszek[0]),
        //            Name = reszek[1],
        //            Phone = reszek[2],
        //            Score = int.Parse(reszek[3])
        //        });
        //    }
        //    return list;
        //}
    }
}
