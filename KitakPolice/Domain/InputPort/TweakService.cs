using System;

namespace KitakPolice.Domain.InputPort
{
    public struct DailyShutdownPlan
    {
        public ExecutionKind ExecutionKind { get; set; }
        public DateTime ExecutionTime { get; set; }
        public bool EnebleReminder { get; set; }
        public uint ReminderBeforeMinutes { get; set; }
    }

    public interface ITweakService
    {
        DailyShutdownPlan GetCurrentShutdownPlan();
        void TweakShutdownPlan(DailyShutdownPlan dailyPlan);
    }
}
