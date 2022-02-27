using System;

namespace KitakPolice.Domain.OutputPort
{
    public interface IShutdownScheduleService
    {
        void ScheduleShutdown(DateTime triggerTime, int? timeoutSeconds);
        void ScheduleHibernate(DateTime triggerTime);
        void ScheduleLogoff(DateTime triggerTime);
    }
}
