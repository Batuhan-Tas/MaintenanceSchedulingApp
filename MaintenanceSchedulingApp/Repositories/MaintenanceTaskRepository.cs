using MaintenanceSchedulingApp.Data;
using MaintenanceSchedulingApp.Models;

namespace MaintenanceSchedulingApp.Repositories
{
    public class MaintenanceTaskRepository : Repository<MaintenanceTask>
    {
        public MaintenanceTaskRepository(MaintenanceSchedulerContext context) : base(context) { }
    }
}
