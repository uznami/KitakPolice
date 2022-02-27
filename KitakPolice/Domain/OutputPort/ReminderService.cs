using System;

namespace KitakPolice.Domain.OutputPort
{
    interface IReminderService
    {
        void SetReminder(DateTime reminderDate, string message);
    }
}
