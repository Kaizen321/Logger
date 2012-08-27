using System;
using log4net.Config;
using log4net;
using System.Data;

namespace Logger.Client
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            //Needed for log4net to read from the app.config
            XmlConfigurator.Configure();
                        
            SQLiteDatabase db = new SQLiteDatabase(@"D:\Fun\Code\GitHub\Logger\Database\MyLogs.db;");
            //Clearing previous test data
            db.ClearTable("Log");

            AddFakeData();
            RetrieveAndDisplayData(db);
        }

        private static void AddFakeData()
        {            
            log.Info("Something, something, dark side.");
            log.Warn("It had a minor, hiccup. tee hee!");
            log.Error("Oh noes, you brokes teh interwebs!");
            log.Fatal("Crap! Someone really messed up this time. Some heads are going to roll!...or maybe just yours...");
        }
        
        private static void RetrieveAndDisplayData(SQLiteDatabase db)
        {
            var results = db.GetDataTable("SELECT * From Log");

            //TODO: Use generics instead. Please don't go out there kicking a cute puppy because of this code :(
            foreach (DataRow item in results.Rows)
            {
                Console.WriteLine("Level: {0} - Location: {1} - Date and Time: {2}",
                                item["Level"].ToString().ToUpper(), item["Location"], item["TimeStamp"]);
                Console.WriteLine("Message: \n{0} \n", item["Message"]);
            }
            Console.ReadLine();
        }
    }
}