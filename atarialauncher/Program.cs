using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            var pathWithEnv = @"%USERPROFILE%\Contacts\main.exe";
            var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "CARGANDO...";
            Console.WriteLine("Atarialauncher v2");
            /// Console.WriteLine(filePath);
            /// Console.WriteLine(remotebox);

            try
            {
                if (File.Exists(filePath))
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(filePath);
                    string version = versionInfo.ProductVersion;
                    Console.WriteLine("Version instalada = " + version);


                      WebClient client = new WebClient();
                      client.Proxy = null;
                      string reply = client.DownloadString("https://atariafiles.000webhostapp.com/");
                    ///var remotever = FileVersionInfo.GetVersionInfo(remotebox);
                    ///string reply = remotever.ProductVersion;
                    Console.WriteLine("Version actual = " + reply);


                    var version1 = new Version(version);
                    var version2 = new Version(reply);

                    var result = version1.CompareTo(version2);
                    if (result > 0)
                    {
                        Console.WriteLine("Error de Proceso.");
                        Console.WriteLine("[Pulsa ENTER para ejecutar la version instalada]");
                        Process.Start(filePath);
                        Environment.Exit(1);
                    }

                    else if (result < 0)
                    {
                        Console.WriteLine("Actualizacion encontrada!");
                        Console.WriteLine("Descargando...");
                        File.Delete(filePath);
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://www.dropbox.com/s/fj4i1a254q8dhda/main.exe?dl=1", filePath);
                        Console.WriteLine("Iniciando...");
                        System.Threading.Thread.Sleep(3000);
                        Process.Start(filePath);
                    }
                    else
                    {
                        Console.WriteLine("Iniciando...");
                        System.Threading.Thread.Sleep(3000);
                        Process.Start(filePath);
                    }

                    return;

                }
                else
                {
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    {
                        Console.WriteLine("Aplicacion no instalada");
                        Console.WriteLine("Descargando...");
                        System.IO.File.Delete(filePath);
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://www.dropbox.com/s/fj4i1a254q8dhda/main.exe?dl=1", filePath);
                        Console.WriteLine("Iniciando...");
                        System.Threading.Thread.Sleep(3000);
                        Process.Start(filePath);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Por favor conectate a internet.");
                        Console.WriteLine("[Presiona ENTER para salir]");
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Atarialauncher v2");
                Console.WriteLine("La aplicacion ya se esta ejecutando!");
                Console.WriteLine("[Presiona ENTER para salir]");
                Console.ReadLine();
                Environment.Exit(1);
            }
            
        }



        
    }
}

