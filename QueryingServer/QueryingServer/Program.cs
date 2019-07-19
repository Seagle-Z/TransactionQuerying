using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionQuery transactionQuery = new TransactionQuery();

            Console.Write("start data: ");
            String inputStartDate = Console.ReadLine();
            Console.Write("  end date: ");
            String inputEndDate = Console.ReadLine();
            Console.Write("PostalCode: ");
            String inputZipCode = Console.ReadLine();

            Console.WriteLine(transactionQuery.QueryingAvg(inputStartDate, inputEndDate, inputZipCode));


        }


    }
}