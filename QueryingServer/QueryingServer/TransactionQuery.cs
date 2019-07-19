using System;
using System.Data.SqlClient;
using System.Text;

namespace QueryingServer
{
    public class TransactionQuery
    {
        public TransactionQuery()
        {

        }

        public string QueryingAvg(String startDate, String endDate, String postalCode)
        {
            string ret = "";

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ordinary.database.windows.net";
                builder.UserID = "ordinary";
                builder.Password = "ProjectCache61";
                builder.InitialCatalog = "AdventureWorks2016";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(
                        "SELECT AVG(TotalDue) FROM Sales.SalesOrderHeader AS t1 " +
                        "LEFT JOIN Person.Address AS t2 ON t1.BillToAddressID = t2.AddressID " +
                        "WHERE t1.OrderDate >= '" + startDate + "' AND t1.OrderDate <= '" + endDate + "' " +
                        "AND t2.PostalCode = '" + postalCode + "' "
                        );
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader == null)
                                {
                                    return " ";
                                }
                                ret += reader.GetDecimal(0).ToString() + "\n";
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return ret;
        }
    }
}