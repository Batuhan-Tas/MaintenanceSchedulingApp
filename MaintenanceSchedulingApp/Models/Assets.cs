﻿namespace MaintenanceSchedulingApp.Models
{
    public class Assets
    {

        public int AssetsId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public int MaintenanceFrequency { get; set; }

    }
}