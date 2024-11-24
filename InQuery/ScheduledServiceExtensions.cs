namespace InQuiry
{
    public static class ScheduledServiceExtensions
    {
        public static IServiceCollection AddCronJob<T>(this IServiceCollection services) where T : CronJobExtensions
        {
            services.AddHostedService<T>();

            return services;
        }
    }
}
