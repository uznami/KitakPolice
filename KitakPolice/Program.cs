using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

using KitakPolice.Domain.UseCase;
using KitakPolice.Controller;
using KitakPolice.Presenter;
using KitakPolice.Domain.InputPort;
using KitakPolice.Domain.OutputPort;

namespace KitakPolice
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            var provider = CreateServiceProvider();

            if (args.Length == 0)
            {
                var tweakService = provider.GetService<ITweakService>();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TweakTimeForm(tweakService));
                return;
            }
            if ((args.Length == 1) && (args[0] == "daily-setup"))
            {
                var startupService = provider.GetService<IStartupService>();
                startupService.Start();
                return;
            }
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddTransient<IReminderService, ReminderService>();
            services.AddTransient<IShutdownCalendar, CsvShutdownCalendar>();
            services.AddTransient<IShutdownScheduleService, ShutdownScheduleService>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<IDialogService, FullScreenDialogService>();
            services.AddTransient<ITweakService, TweakService>();
            services.AddTransient<IStartupService, StartupService>();
            return services.BuildServiceProvider();
        }
    }
}
