namespace KitakPolice.Domain.OutputPort
{
    public interface IScheduleService
    {
        void ApplySchedule(ShutdownPlan plan);
    }
}
