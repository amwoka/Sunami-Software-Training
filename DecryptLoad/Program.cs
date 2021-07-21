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
            Entry newEntry = new Entry();
          //path to the file to be decrypted
            var path = @"C:\Users\user\Documents\Training_File\customers-encrypted.tsv";
          //  var words = new List<String> { };
          // Propmt user to initiate file reading and get response
               Console.WriteLine("Do you wish to open a file? N/Y");
            var response1 = Console.ReadLine();
           
            switch(response1.ToUpper())
            {

                
                case "Y":
                    //Initiate file reading
                    var readData = File.ReadAllText(path);
                    //Convert from base64 encryption to an array of bytes
                    var bytesValue = Convert.FromBase64String(readData);
                    var plainText = System.Text.Encoding.UTF8.GetString(bytesValue);
                    //  var decrypted = BitConverter.ToString(bytesValue).Split("\t");
                    //After decryption, get each word separated by a tab
                    var decrypted = plainText.Split("\t");
                    //foreach (var i in decrypted)
                    //{
                    //    Console.WriteLine(i);
                    //}
                    //Iterate to find all the values from TSV file
                    var stringLength = decrypted.Length;
                    var index = 0;
                    while (index < stringLength)
                    {
                        var val = newEntry.decodeEntries(decrypted, index);

                        Console.WriteLine("{0}{1}{2}{3}",val.Id,val.First_name,val.Last_name,val.Phone);
                        index += 4;
                        if (stringLength - index < index) break;
                    }
                 //   Program.readExcel();
                    break;
                case "N":
                    break;
                default:
                    break;
            }
                
        }

      

      


        /*
         //Read from an excel file
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
        */
    }
     class Entry
     {
        public Entry()
        { }
        public Entry(String id, String first_name, String last_name, String phone)
        {
            Id = id;
            First_name = first_name;
            Last_name = last_name;
            Phone = phone;

        }

        public string Id { get;}
        public string First_name { get; }
        public string Last_name { get; }
        public string Phone { get; }

        public Entry decodeEntries(String[] entryArray,int stringIndex)
        {
     
           
                var assignEachEntry = new Entry(entryArray[stringIndex], entryArray[stringIndex + 1], entryArray[stringIndex + 2], entryArray[stringIndex + 3]);
            
                return assignEachEntry;
        }

     }

}
