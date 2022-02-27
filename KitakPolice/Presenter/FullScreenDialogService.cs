using System;
using System.Diagnostics;
using KitakPolice.Domain.OutputPort;

namespace KitakPolice.Presenter
{
    public class FullScreenDialogService : IDialogService
    {
        public (string, string) CreateCommand(string message, int? timeoutSeconds)
        {
            var folderPath = AppDomain.CurrentDomain.BaseDirectory;
            var exePath = System.IO.Path.Combine(folderPath, "FullscreenDialog.exe");
            var escapedMessage = $"\"{message.Replace("\"", "\\\"")}\"";
            if (timeoutSeconds == null)
            {
                return (exePath, string.Format("{0} {1}", escapedMessage, timeoutSeconds));
            }
            return (exePath, escapedMessage);
        }

        public void Show(string message, int? timeoutSeconds)
        {
            var (command, args) = CreateCommand(message, timeoutSeconds);
            Process.Start(command, args);
        }
    }
}
