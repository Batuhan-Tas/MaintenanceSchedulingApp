namespace MaintenanceSchedulingApp.Models
{
    public class MaintenanceTask
    {
        public int MaintenanceTaskId {  get; set; }
        public int AssetId {  get; set; }
        public string Description {  get; set; }
        public bool IsCompleted { get; set; }
        public DateTime ScheduledDate { get; set; }

        public Assets Assets { get; set; }

        public void MarkAsCompleted(int taskId)
        {
            IsCompleted = true;
        }

    }
}
