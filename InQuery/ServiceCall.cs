using Infrastracture.Repository;
using InQuiry.Services;

namespace InQuiry
{

    public class ServiceCall : CronJobExtensions
    {
        public ServiceCall(IServiceProvider serviceProvider)
         : base(serviceProvider)
        {
        }

        public override async Task DoWork(IServiceScope scope, CancellationToken cancellationToken)
        {

            //var sp = scope.ServiceProvider;
            var balanceService = scope.ServiceProvider.GetRequiredService<IBalanceService>();
            var Address = "TSTVYwFDp7SBfZk7Hrz3tucwQVASyJdwC7";
            await balanceService.GetApiAsync(Address);

        }
    }

}
