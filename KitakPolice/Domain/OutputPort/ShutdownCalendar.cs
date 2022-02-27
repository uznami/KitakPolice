using System;

namespace KitakPolice.Domain.OutputPort
{
    public interface IShutdownCalendar
    {
        ShutdownPlan? LookupPlan(DateTime date);
        void StorePlan(ShutdownPlan plan);
    }
}
