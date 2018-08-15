using System.IO;
using System.Configuration;
using BLL.Concrete;

namespace UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var txtFile = new FileInfo(ConfigurationManager.AppSettings["txtPath"]);
            var xmlFile = new FileInfo(ConfigurationManager.AppSettings["xmlPath"]);

            var service = new DataTransferService(new DataProvider(txtFile), new XMLStorage(xmlFile), new Parser());

            service.Transfer();

            System.Console.ReadKey();
        }
    }
}
