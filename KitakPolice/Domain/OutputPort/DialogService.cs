namespace KitakPolice.Domain.OutputPort
{
    public interface IDialogService
    {
        void Show(string message, int? timeoutSeconds);
    }
}
