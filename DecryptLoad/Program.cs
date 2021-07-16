using System;
using System.IO;
using Microsoft.Win32;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.OleDb;

namespace DecryptLoad
{
    class Program
    {
        static void Main(string[] args)
        {
      
            //OpenFileDialog ofd = new OpenFileDialog();
          //  var path = @"C:\Users\user\Documents\AprilAirt.xlsx";
            var words = new List<String> { };
           // var eachWord = "";
            //  var readData = "";
            Console.WriteLine("Do you wish to open a file? N/Y");
            var response1 = Console.ReadLine();
            switch(response1.ToUpper())
            {

                
                case "Y":

                    //var readData = File.ReadAllText(path);
                    //    var eachWord = readData.Split("\t");
                    //    foreach (var word in eachWord)
                    //    {
                    //        Console.WriteLine(word + "\n");
                    //    }
                    Program.readExcel();
                    break;
                case "N":
                    break;
                default:
                    break;
            }
                
        }
       static void readExcel()
        {
            string con =
    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Documents\Kilifi_Project.xlsx;" +
  @"Extended Properties='Excel 8.0;HDR=Yes;'";
            using (var connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row1Col0 = dr[0];
                        Console.WriteLine(row1Col0);
                    }
                }
            }
        }
    }
}
