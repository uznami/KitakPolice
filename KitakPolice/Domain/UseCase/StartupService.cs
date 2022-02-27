using System;
using KitakPolice.Domain.InputPort;
using KitakPolice.Domain.OutputPort;

namespace KitakPolice.Domain.UseCase
{
    class StartupService : IStartupService
    {
        private readonly IShutdownCalendar ShutdownCalendar;
        private readonly IScheduleService ScheduleService;
        private readonly IDialogService DialogService;

        public StartupService(IShutdownCalendar shutdownCalendar, IScheduleService scheduleService, IDialogService dialogService)
        {
            ShutdownCalendar = shutdownCalendar;
            ScheduleService = scheduleService;
            DialogService = dialogService;
        }

        public void Start()
        {
            var plan = ShutdownCalendar.LookupPlan(DateTime.Today);
            if (plan is ShutdownPlan p)
            {
                ScheduleService.ApplySchedule(p);
                DialogService.Show($"本日は{p.Time}にシステムを終了します。", null);
            }
        }
    }
}
