using MaintenanceSchedulingApp.Models;
using MaintenanceSchedulingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceSchedulingApp.Services
{
    public class MaintenanceService
    {
        private readonly IRepository<Assets> _assetRepository;
        private readonly IRepository<MaintenanceTask> _taskRepository;

        public MaintenanceService(IRepository<Assets> assetRepository, IRepository<MaintenanceTask> taskRepository)
        {
            _assetRepository = assetRepository;
            _taskRepository = taskRepository;
        }

        // Method to schedule a maintenance task for an asset
        public async Task ScheduleMaintenanceForAsset(int assetId, DateTime scheduledDate)
        {
            var asset = await _assetRepository.GetByIdAsync(assetId);
            if (asset != null)
            {
                var task = new MaintenanceTask
                {
                    AssetId = assetId,
                    Description = $"Scheduled maintenance for {asset.Name}",
                    ScheduledDate = scheduledDate,
                    IsCompleted = false
                };
                await _taskRepository.AddAsync(task);
            }
        }

        // Method to complete a maintenance task and schedule the next one
        public async Task CompleteMaintenanceTask(int taskId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task != null && !task.IsCompleted)
            {
                task.MarkAsCompleted(taskId);
                await _taskRepository.UpdateAsync(task);

                // Schedule the next maintenance task based on frequency
                var asset = await _assetRepository.GetByIdAsync(task.AssetId);
                if (asset != null)
                {
                    asset.UpdateLastMaintenanceDate(task.ScheduledDate);
                    var nextScheduledDate = task.ScheduledDate.AddDays(asset.MaintenanceFrequencyInDays);
                    await ScheduleMaintenanceForAsset(asset.AssetsId, nextScheduledDate);
                }
            }
        }

        // Method to retrieve upcoming maintenance tasks
        public async Task<List<MaintenanceTask>> GetUpcomingMaintenanceTasks(DateTime fromDate)
        {
            var allTasks = await _taskRepository.GetAllAsync();
            return allTasks
                .Where(t => t.ScheduledDate >= fromDate && !t.IsCompleted)
                .OrderBy(t => t.ScheduledDate)
                .ToList();
        }
    }
}
