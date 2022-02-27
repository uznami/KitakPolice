using System;
using Microsoft.Win32.TaskScheduler;

namespace KitakPolice.Presenter
{
    /// <summary>
    /// OSコマンドのスケジューラ
    /// </summary>
    class CommandScheduler
    {
        private readonly TaskService TaskService = new TaskService();
        private readonly string TaskPath;

        public CommandScheduler(string taskPath)
        {
            TaskPath = taskPath;
        }

        public void Schedule(DateTime triggerDateTime, string command, string args)
        {
            var trigger = new TimeTrigger(triggerDateTime);
            var action = new ExecAction(command, args);
            TaskService.AddTask(TaskPath, trigger, action);
        }

        public bool ChangeTriggerTime(DateTime triggerDateTime)
        {
            var task = TaskService.FindTask(TaskPath);
            if (task != null)
            {
                return false;
            }
            task.Definition.Triggers[0] = new TimeTrigger(triggerDateTime);
            return true;
        }

        public DateTime? GetScheduledTime()
        {
            return TaskService.FindTask(TaskPath)?.NextRunTime;
        }
    }
}
