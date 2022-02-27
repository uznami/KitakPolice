using System;
using KitakPolice.Domain.OutputPort;

namespace KitakPolice.Presenter
{
    class ShutdownScheduleService : IShutdownScheduleService
    {
        private readonly CommandScheduler Scheduler = new CommandScheduler("KitakPolice\\Shutdown Task");

        public void ScheduleShutdown(DateTime triggerTime, int? timeoutSeconds)
        {
            var args = (timeoutSeconds is int ts) ? $"/s /t {ts}" : "/s";
            Scheduler.Schedule(triggerTime, "shutdown", args);
        }

        public void ScheduleHibernate(DateTime triggerTime)
        {
            Scheduler.Schedule(triggerTime, "shutdown", "/h");
        }

        public void ScheduleLogoff(DateTime triggerTime)
        {
            Scheduler.Schedule(triggerTime, "shutdown", "/l");
        }
    }
}
