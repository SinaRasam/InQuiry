using Infrastracture.Repository;
using InQuiry.Services;
using Quartz;

namespace InQuiry
{
    [DisallowConcurrentExecution]
    public class ServiceCall(IBalanceService balanceService) : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var Address = "TSTVYwFDp7SBfZk7Hrz3tucwQVASyJdwC7";
            await balanceService.GetApiAsync(Address);
        }
    }

}
