using Cronos;

public abstract class CronJobExtensions : BackgroundService
{
    
    private readonly IServiceProvider _serviceProvider;

    protected CronJobExtensions(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
          
            var delay = 10000;//every 10 second

            if (cancellationToken.IsCancellationRequested) continue;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                await DoWork(scope, cancellationToken);
                await Task.Delay(delay, cancellationToken);
            }
            catch (Exception ex)
            {
                //log
            }
        }
    }

    public abstract Task DoWork(IServiceScope scope, CancellationToken cancellationToken);
}