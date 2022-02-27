using System;
using KitakPolice.Domain.OutputPort;

namespace KitakPolice.Presenter
{
    public class ReminderService : IReminderService
    {
        private readonly CommandScheduler Scheduler = new CommandScheduler("KitakPolice\\Reminder Task");
        private readonly FullScreenDialogService DialogService = new FullScreenDialogService();
        public void SetReminder(DateTime reminderDate, string message)
        {
            var (command, args) = DialogService.CreateCommand(message, 30);
            Scheduler.Schedule(reminderDate, command, args);
        }
    }
}
