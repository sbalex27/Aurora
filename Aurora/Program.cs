using Core.LexicalAnalyzer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aurora
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var services = new ServiceCollection().ConfigureServices();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                Application.Run(serviceProvider.GetRequiredService<Index>());
            }
        }

        static ServiceCollection ConfigureServices(this ServiceCollection services)
        {
            services.AddScoped<Index>();
            services.AddSingleton<ILexicalAnalyzer, RegexAnalyzer>();
            return services;
        }
    }
}
