using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SDTur.Application.Services.Tour.Interfaces;
using SDTur.Application.Services.System.Interfaces;
using SDTur.Application.DTOs.Tour.Tour;

namespace SDTur.Application.Services.System.Implementations
{
    public class TourReminderService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<TourReminderService> _logger;
        private readonly TimeSpan _checkInterval = TimeSpan.FromHours(1);

        public TourReminderService(
            IServiceProvider serviceProvider,
            ILogger<TourReminderService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Tour Reminder Service started");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await ProcessTourRemindersAsync(stoppingToken);
                    await Task.Delay(_checkInterval, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    _logger.LogInformation("Tour Reminder Service stopped");
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in Tour Reminder Service");
                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                }
            }
        }

        private async Task ProcessTourRemindersAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var tourService = scope.ServiceProvider.GetRequiredService<ITourService>();

            try
            {
                // Yaklaşan turları kontrol et (24 saat içinde)
                var allTours = await tourService.GetAllToursAsync();
                var upcomingTours = allTours.Where(t => t.TourDate <= DateTime.Now.AddDays(1) && t.TourDate > DateTime.Now);
                
                foreach (var tour in upcomingTours)
                {
                    _logger.LogInformation("Processing reminder for tour: {TourName} on {TourDate}", 
                        tour.Name ?? "Unknown", tour.TourDate);
                    
                    // Burada e-posta gönderme, SMS gönderme gibi işlemler yapılabilir
                    await SendTourReminderAsync(tour);
                }

                _logger.LogDebug("Processed {Count} tour reminders", upcomingTours.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing tour reminders");
            }
        }

        private async Task SendTourReminderAsync(TourDto tour)
        {
            // Simüle edilmiş reminder gönderme
            await Task.Delay(100); // Simüle edilmiş işlem süresi
            
            _logger.LogInformation("Reminder sent for tour: {TourName}", tour.Name ?? "Unknown");
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Tour Reminder Service stopping");
            await base.StopAsync(cancellationToken);
        }
    }
} 