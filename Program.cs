using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DriverB3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ret = await NavegarParaB3Async();

            Console.WriteLine(ret[0]);
            Console.WriteLine(ret[1]);

        }

        private static async Task<string[]> NavegarParaB3Async()
        {
            var task =  Task.Factory.StartNew(() => {
                // I dont want to overcomplicate this so I decided not to create a new class
                // to display the return data but that is the way to go
                const int numeroDadosRetorno = 2;
                var returnArray = new string[numeroDadosRetorno];

                
                var options = new ChromeOptions();
                options.AddArgument("headless");
                using (var driver = new ChromeDriver(options))
                {
                    driver.Url = "http://www.b3.com.br/pt_br/";
                    var variacaoDiaria = driver.FindElementById("ibovPct").Text;
                    var pontosIbovespa = driver.FindElementById("ibovPts").Text;

                    returnArray[0] = variacaoDiaria;
                    returnArray[1] = pontosIbovespa;
                }
                return returnArray;
            });

            return await task;
        }

    }
}
