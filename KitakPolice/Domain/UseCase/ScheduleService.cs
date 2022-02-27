using System;
using KitakPolice.Domain.OutputPort;

namespace KitakPolice.Domain.UseCase
{
    class ScheduleService : IScheduleService
    {
        private readonly IReminderService ReminderService;
        private readonly IShutdownScheduleService ShutdownScheduleService;
        private readonly IShutdownCalendar ShutdownCalendar;

        public ScheduleService(IReminderService reminderService, IShutdownScheduleService shutdownScheduleService, IShutdownCalendar shutdownCalendar)
        {
            ReminderService = reminderService;
            ShutdownScheduleService = shutdownScheduleService;
            ShutdownCalendar = shutdownCalendar;
        }

        public void ApplySchedule(ShutdownPlan plan)
        {
            if (plan.ReminderBefore is TimeSpan span)
            {
                SetReminder(plan.Time, span.Negate());
            }
            SetShutdown(plan.Kind, plan.Time);
            ShutdownCalendar.StorePlan(plan);
        }

        void SetReminder(DateTime triggerTime, TimeSpan span)
        {
            var reminderDate = triggerTime.Add(span);
            var minutes = -span.TotalSeconds / 60;
            var seconds = span.TotalSeconds % 60;
            var message = string.Format("あと {0}分{1}秒でシステムを終了します。アプリケーションの内容を保存してください。", minutes, seconds);
            ReminderService.SetReminder(reminderDate, message);
        }

        void SetShutdown(ExecutionKind type, DateTime triggerTime)
        {
            switch (type)
            {
                case ExecutionKind.Shutdown:
                    ShutdownScheduleService.ScheduleShutdown(triggerTime, 30);
                    break;
                case ExecutionKind.Hibernate:
                    ShutdownScheduleService.ScheduleHibernate(triggerTime);
                    break;
                case ExecutionKind.Logoff:
                    ShutdownScheduleService.ScheduleLogoff(triggerTime);
                    break;
            }
        }

    }
}
