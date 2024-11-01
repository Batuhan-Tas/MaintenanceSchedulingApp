using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MaintenanceSchedulingApp.Models
{
    public class MaintenanceHistory
    {

        public int MaintenanceHistoryId { get; set; }
        public int TaskId { get; set; } 
        public DateTime CompletionDate { get; set; }
        public string TechnicianName { get; set; }

        public MaintenanceTask Task { get; set; } 

    }
}
