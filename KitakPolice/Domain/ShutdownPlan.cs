using System;

namespace KitakPolice.Domain
{
    /// <summary>
    /// 執行種別
    /// </summary>
    [Serializable]
    public enum ExecutionKind
    {
        Shutdown,
        Hibernate,
        Logoff,
    }

    [Serializable]
    public struct ShutdownPlan
    {
        public DateTime Time { get; set; }
        public ExecutionKind Kind { get; set; }
        public TimeSpan? ReminderBefore { get; set; }
    }
}
