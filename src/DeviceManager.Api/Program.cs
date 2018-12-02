using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DeviceManager.Api
{
    /// <summary>
    /// Starting or hosting class of the applcation 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method for dotnet core hosting
        /// </summary>
        /// <param name="args">Command line parameters</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Fix migrations https://github.com/aspnet/EntityFrameworkCore/issues/9415#issuecomment-327589912
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns></returns>
        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>     
                                        WebHost.CreateDefaultBuilder(args)
                                            .UseKestrel()
                                            .UseContentRoot(Directory.GetCurrentDirectory())
                                            .UseIISIntegration()
                                            .UseStartup<Startup>()
                                            .UseApplicationInsights();
    }
}
