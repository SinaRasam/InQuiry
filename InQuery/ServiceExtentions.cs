using Microsoft.AspNetCore.Components;
using Quartz;

namespace InQuiry.Extentions
{
    public static class ServiceExtentions
    {
        public static void RegisterBackgroundServices(this IServiceCollection services)
        {
            services.AddQuartz(option =>
            {
                Type? _f = Type.GetType("InQuiry.ServiceCall");
                var jobKey = JobKey.Create("CronJob");
                option.AddJob(_f, jobKey).AddTrigger(t => t.ForJob(jobKey).WithSimpleSchedule(s => s.WithInterval(TimeSpan.FromMilliseconds(300000)).RepeatForever()));
            });
            services.AddQuartzHostedService(option =>{
                option.WaitForJobsToComplete=true;
                option.WaitForJobsToComplete=true;
            });
        }
    }
}
