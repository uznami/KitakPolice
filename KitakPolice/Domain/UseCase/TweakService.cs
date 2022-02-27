using System;
using KitakPolice.Domain.InputPort;
using KitakPolice.Domain.OutputPort;

namespace KitakPolice.Domain.UseCase
{
    class TweakService : ITweakService
    {
        private readonly IShutdownCalendar ShutdownCalendar;
        private readonly IScheduleService ScheduleService;

        // デフォルトのシャットダウン設定 (10分前アラームで20:00にシャットダウン)
        private readonly DailyShutdownPlan DefaultShutdownPlan = new DailyShutdownPlan
        {
            ExecutionKind = ExecutionKind.Shutdown,
            ExecutionTime = DateTime.Today.Add(new TimeSpan(20, 0, 0)),
            EnebleReminder = true,
            ReminderBeforeMinutes = 10,
        };

        public TweakService(IShutdownCalendar shutdownCalendar, IScheduleService scheduleService)
        {
            ShutdownCalendar = shutdownCalendar;
            ScheduleService = scheduleService;
        }

        public DailyShutdownPlan GetCurrentShutdownPlan()
        {
            var plan = ShutdownCalendar.LookupPlan(DateTime.Today);
            if (plan is ShutdownPlan p)
            {
                var dailyPlan = new DailyShutdownPlan
                {
                    ExecutionKind = p.Kind,
                    ExecutionTime = p.Time,
                    EnebleReminder = p.ReminderBefore.HasValue,
                    ReminderBeforeMinutes = (uint)(p.ReminderBefore?.TotalMinutes ?? DefaultShutdownPlan.ReminderBeforeMinutes),
                };
                return dailyPlan;
            }
            return DefaultShutdownPlan;
        }

        public void TweakShutdownPlan(DailyShutdownPlan dailyPlan)
        {
            var plan = new ShutdownPlan
            {
                Kind = dailyPlan.ExecutionKind,
                Time = dailyPlan.ExecutionTime,
                ReminderBefore = null,
            };
            if (dailyPlan.EnebleReminder)
            {
                plan.ReminderBefore = TimeSpan.FromMinutes(dailyPlan.ReminderBeforeMinutes);
            }
            ScheduleService.ApplySchedule(plan);
        }
    }
}
