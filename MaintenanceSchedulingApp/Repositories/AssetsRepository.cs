using MaintenanceSchedulingApp.Data;
using MaintenanceSchedulingApp.Models;

namespace MaintenanceSchedulingApp.Repositories
{
    public class AssetsRepository : Repository<Assets>
    {
        public AssetsRepository(MaintenanceSchedulerContext context) : base(context) { }
    }
}
