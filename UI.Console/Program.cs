using System.IO;
using System.Configuration;
using BLL.Concrete;
namespace UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Stream stream = File.OpenRead(ConfigurationManager.AppSettings["txtPath"]))
            {
                var xmlFile = new FileInfo(ConfigurationManager.AppSettings["xmlPath"]);

                var service = new DataTransferService(new DataProvider(stream), new XMLStorage(xmlFile), new Parser());

                service.Transfer();
            }

            System.Console.ReadKey();
        }
    }
}
